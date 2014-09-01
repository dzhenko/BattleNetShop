namespace BattleNetShop.Data.Excel.Xlsx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ClosedXML.Excel;

    using BattleNetShop.Data.MySql;
    using BattleNetShop.Data.SqLite;

    /// <summary>
    /// Uses ClosedXML library from nuget to generate xlsx files
    /// </summary>
    public class ExcelXlsxHandler
    {
        // TODO: move to main logic, use IQueryable?
        public ICollection<FinancialResultReportRecord> GenerateVendorsFinancialResultReport(ICollection<ProductsTaxes> productsTaxes, ICollection<Salereport> salesReport)
        {
            var salesJoinedWithTaxesGroupedByVendor = salesReport
                    .Join(productsTaxes,
                        (s => s.ProductName),
                        (pt => pt.ProductName),
                        (s, pt) => new { VendorName = s.VendorName, TotalIncome = s.TotalIncomes, TotalIncomeWithTax = s.TotalIncomes * (pt.Tax / 100) })
                    .GroupBy(s => s.VendorName)
                    .Select(sg => new { VendorName = sg.Key, TotalIncomes = sg.Sum(s => s.TotalIncome), TotalIncomeWithTax = sg.Sum(s => s.TotalIncomeWithTax)});

            var result = new LinkedList<FinancialResultReportRecord>();
            foreach (var row in salesJoinedWithTaxesGroupedByVendor)
            {
                var reportRecord = new FinancialResultReportRecord();
                reportRecord.VendorName = row.VendorName;
                reportRecord.Incomes = row.TotalIncomes;
                reportRecord.Taxes = (decimal)row.TotalIncomeWithTax;
                reportRecord.FinancialBalance = (decimal)(reportRecord.Incomes - reportRecord.Taxes);

                result.AddLast(reportRecord);
            }

            return result;
        }

        // Task 6 output
        public void GenerateVendorsFinancialResultFile(ICollection<FinancialResultReportRecord> reportData, string fileName)
        {            
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Financial Balance");

            //Columns
            ws.Cell("B2").Value = "Vendor";
            ws.Cell("C2").Value = "Incomes";
            ws.Cell("D2").Value = "Taxes";
            ws.Cell("E2").Value = "Financial Balance";

            var rngTable = ws.Range("B2:E2");
            rngTable
                .Style
                .Font.SetBold()
                .Fill.SetBackgroundColor(XLColor.IndiaGreen)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            int rowCount = 3;
            foreach (var row in reportData)
            {
                string vendorCell = "B" + rowCount;
                string incomesCell = "C" + rowCount;
                string taxesCell = "D" + rowCount;
                string finacialBalanceCell = "E" + rowCount;

                ws.Cell(vendorCell).Value = row.VendorName;
                ws.Cell(incomesCell).Value = row.Incomes;
                ws.Cell(taxesCell).Value = row.Taxes;
                ws.Cell(finacialBalanceCell).Value = row.FinancialBalance;

                rowCount++;
            }

            ws.Columns().AdjustToContents();
            wb.SaveAs(XlsxSettings.Default.GenerateReportDirectory + fileName);
        }
    }
}
