namespace GenerateXlsxReportTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BattleNetShop.Data.Excel.Xlsx;
    using BattleNetShop.Data.SqLite;
    using BattleNetShop.Data.MySql;
    using BattleNetShop.Model;
    
    class Program
    {
        static void Main()
        {
            //Get SQLite data
            SqLiteDataSeeder seeder = new SqLiteDataSeeder();
            seeder.CreateSQLiteTableProductsTaxes();
            seeder.SeedTableProductsTaxes();
            SqLiteData sqliteData = new SqLiteData();
            var productsTaxes = sqliteData.ReadProductTaxes();
            //Get MySQL data
            var salesReport = new List<Salereport>();
            for (int i = 0; i < productsTaxes.Count; i++)
            {
                salesReport.Add(new Salereport()
                {
                    Product_id = i,
                    ProductName = productsTaxes.ElementAt(i).ProductName,
                    VendorName = "Vendor#" + i.ToString(),
                    TotalQuantitySold = i + 10,
                    TotalIncomes = i * 10
                });
            }

            //Get VendorExpensses <string, decimal>
            //magic
            var expensesReport = new List<VendorExpense>();
            for (int i = 0; i < productsTaxes.Count; i++)
            {
                expensesReport.Add(new VendorExpense()
                {
                    VendorName = "Vendor#" + i.ToString(),
                    Ammount = i * 10
                });
            }

            var xlsxHandler = new ExcelXlsxHandler();
            var reportData = xlsxHandler.GenerateVendorsFinancialResultReport(productsTaxes, salesReport, expensesReport);
            xlsxHandler.GenerateVendorsFinancialResultFile(reportData, "FinancialBalanceResults.xlsx");
        }
    }
}
