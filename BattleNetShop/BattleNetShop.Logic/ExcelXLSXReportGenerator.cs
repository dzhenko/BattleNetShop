namespace BattleNetShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BattleNetShop.Data.MySql;
    using BattleNetShop.Data.Excel.Xlsx;
    using BattleNetShop.ReportsModel;
    using BattleNetShop.Data.SqLite;
    using BattleNetShop.Model;

    public class ExcelXLSXReportGenerator
    {
        private readonly Lazy<MySqlReportsFetcher> mySqlFetcher = new Lazy<MySqlReportsFetcher>();
        private readonly Lazy<SqLiteData> sqliteData = new Lazy<SqLiteData>();
        private readonly Lazy<ExcelXlsxHandler> xlsxHandler = new Lazy<ExcelXlsxHandler>();

        public void GenerateVendorsFinancialResultReport()
        {
            var salesReport = this.mySqlFetcher.Value.GetSaleReport();
            var productsTaxes = this.sqliteData.Value.ReadProductTaxes();
            // TODO: get expenses
            var vendorsExpenses = new LinkedList<VendorExpense>();
            int i = 0;
            foreach (var sale in salesReport)
            {
                vendorsExpenses.AddLast(new VendorExpense()
                {
                    VendorName = sale.VendorName,
                    Ammount = i * 10
                });

                i++;
            }

            var salesJoinedWithTaxesGroupedByVendor = salesReport
                    .Join(productsTaxes,
                        (s => s.ProductName),
                        (pt => pt.ProductName),
                        (s, pt) => new { VendorName = s.VendorName, TotalIncome = s.TotalIncomes, TotalIncomeWithTax = s.TotalIncomes * (pt.Tax / 100) })
                    .GroupBy(s => s.VendorName)
                    .Select(sg => new { VendorName = sg.Key, TotalIncomes = sg.Sum(s => s.TotalIncome), TotalIncomeWithTax = sg.Sum(s => s.TotalIncomeWithTax) });

            var vendorFinancialInfoJoinedWithExpenses = salesJoinedWithTaxesGroupedByVendor
                    .Join(vendorsExpenses,
                        (f => f.VendorName),
                        (e => e.VendorName),
                        (f, e) => new { VendorName = f.VendorName, TotalIncomes = f.TotalIncomes, TotalIncomeWithTax = f.TotalIncomeWithTax, Expenses = e.Ammount });

            var reportEntries = new LinkedList<FinancialResultReportEntry>();
            foreach (var row in vendorFinancialInfoJoinedWithExpenses)
            {
                var reportRecord = new FinancialResultReportEntry();
                reportRecord.VendorName = row.VendorName;
                reportRecord.Incomes = row.TotalIncomes;
                reportRecord.Expenses = (decimal)row.Expenses;
                reportRecord.Taxes = (decimal)row.TotalIncomeWithTax;
                reportRecord.FinancialBalance = (decimal)(reportRecord.Incomes - reportRecord.Taxes - reportRecord.Expenses);

                reportEntries.AddLast(reportRecord);
            }

            var reportData = new FinancialResultReport();
            reportData.Report = reportEntries;

            this.xlsxHandler.Value.GenerateVendorsFinancialResultFile(reportData, "FinancialBalanceResults.xlsx");
        }
    }
}
