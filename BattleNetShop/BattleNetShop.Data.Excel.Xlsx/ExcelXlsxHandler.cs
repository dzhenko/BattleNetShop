namespace BattleNetShop.Data.Excel.Xlsx
{
    using System;
    using ClosedXML.Excel;

    using System.Collections.Generic;
    
    public class ExcelXlsxHandler
    {
        // Tuple<string, ICollection<Tuple<int, string, string, int, decimal>> will become a class
        // Task 6 output
        public void GenerateProductsReport(ICollection<Tuple<int, string, string, int, decimal>> allReports, string fileName)
        {
            throw new NotImplementedException();
        }

        public void GenerateVendorsFinancialResultsReport(ICollection<Tuple<string, decimal, decimal, decimal>> reportData, string fileName)
        {
            // TODO: Get expenses as well?
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Financial Balance");

            //Columns
            ws.Cell("B2").Value = "Vendor";
            ws.Cell("C2").Value = "Incomes";
            ws.Cell("D2").Value = "Taxes";
            ws.Cell("E2").Value = "Financial Result";

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
                string finacialResultCell = "E" + rowCount;
                ws.Cell(vendorCell).Value = row.Item1;
                ws.Cell(incomesCell).Value = row.Item2;
                ws.Cell(taxesCell).Value = row.Item3;
                ws.Cell(finacialResultCell).Value = row.Item4;
                ws.Cell(vendorCell).Value = row.Item1;

                rowCount++;
            }

            ws.Columns().AdjustToContents();
            wb.SaveAs(XlsxSettings.Default.GenerateReportDirectory + fileName);
        }
    }
}
