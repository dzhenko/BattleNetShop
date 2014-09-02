namespace BattleNetShop.Data.Excel.Xlsx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ClosedXML.Excel;

    using BattleNetShop.Data.MySql;
    using BattleNetShop.Data.SqLite;
    using BattleNetShop.Model;
    using BattleNetShop.ReportsModel;

    /// <summary>
    /// Uses ClosedXML library from nuget to generate xlsx files
    /// </summary>
    public class ExcelXlsxHandler
    {
        public void GenerateVendorsFinancialResultFile(FinancialResultReport reportData, string fileName)
        {            
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Financial Balance");

            //Columns
            ws.Cell("B2").Value = "Vendor";
            ws.Cell("C2").Value = "Incomes";
            ws.Cell("D2").Value = "Expenses";
            ws.Cell("E2").Value = "Taxes";
            ws.Cell("F2").Value = "Financial Balance";

            int rowCount = 3;
            foreach (var row in reportData.Report)
            {
                string vendorCell = "B" + rowCount;
                string incomesCell = "C" + rowCount;
                string expensesCell = "D" + rowCount;
                string taxesCell = "E" + rowCount;
                string finacialBalanceCell = "F" + rowCount;

                ws.Cell(vendorCell).Value = row.VendorName;
                ws.Cell(incomesCell).Value = row.Incomes;
                ws.Cell(expensesCell).Value = row.Expenses;
                ws.Cell(taxesCell).Value = row.Taxes;
                ws.Cell(finacialBalanceCell).Value = row.FinancialBalance;

                rowCount++;
            }

            var tableRange = ws.Range("B2", "F" + rowCount);
            var finBalanceTable = tableRange.CreateTable();
            finBalanceTable.Theme = XLTableTheme.TableStyleMedium16;

            ws.Columns().AdjustToContents();
            wb.SaveAs(XlsxSettings.Default.GenerateReportDirectory + fileName);
        }
    }
}
