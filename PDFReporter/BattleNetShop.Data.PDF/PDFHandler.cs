namespace BattleNetShop.Data.PDF
{

    using System;
    using System.Collections.Generic;
    using PdfSharp.Pdf;
    using MigraDoc.DocumentObjectModel;
    using MigraDoc.DocumentObjectModel.Tables;
    using System.Xml.XPath;
    using MigraDoc.Rendering;
    using System.Diagnostics;

    public class PDFHandler
    {
        // Tuple<string, ICollection<Tuple<DateTime, decimal>>> will become a class
        // Task 2 output

        private Table mainTable;

        public void TestPdfCreate(List<ReportRow> allReports)
        {
            Document document = new Document();
            document.Info.Title = "BattleNet Sales Report";
            document.Info.Author = "BattleNetShop Sales Report";
            document.Info.Subject = "This is the description of the document";
            document.Info.Keywords = "Blizzard, BattleNet, Diablo, Warcraft, Sales, Items";

            DefineStyles(document);

            CreatePage(document);

            FillData(allReports);

            RenderDocument(document);

        }

        private static void RenderDocument(Document document)
        {
            // Render The Document
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
            pdfRenderer.Document = document;

            pdfRenderer.RenderDocument();

            string fileName = "BattleNet-Sales-Report.pdf";
            pdfRenderer.PdfDocument.Save(fileName);

            Process.Start(fileName);
        }

        private void FillData(List<ReportRow> reportRows)
        {
            foreach (var reportRow in reportRows)
            {
                Row row = mainTable.AddRow();
                row.Height = "1cm";
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                row.Shading.Color = Colors.YellowGreen;
                row.Cells[0].AddParagraph(reportRow.ProductName);
                row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[1].AddParagraph(reportRow.Quantity.ToString());
                row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[2].AddParagraph(reportRow.UnitPrice.ToString());
                row.Cells[2].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[2].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[3].AddParagraph(reportRow.Vendor);
                row.Cells[3].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[3].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[4].AddParagraph(reportRow.Sum.ToString());
                row.Cells[4].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[4].VerticalAlignment = VerticalAlignment.Center;
            }

            double totalSum = FindTotalSum(reportRows);
            Row totalSumRow = mainTable.AddRow();
            totalSumRow.Height = "1cm";
            totalSumRow.HeadingFormat = true;
            totalSumRow.Format.Alignment = ParagraphAlignment.Center;
            totalSumRow.Format.Font.Bold = true;
            totalSumRow.Shading.Color = Colors.LightGray;
            totalSumRow.Cells[0].AddParagraph("Total: " + totalSum.ToString());
            totalSumRow.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            totalSumRow.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            totalSumRow.Cells[0].MergeRight = 4;
        }

        private double FindTotalSum(List<ReportRow> reportRows)
        {
            double totalSum = 0;
            for (int i = 0; i < reportRows.Count; i++)
            {
                totalSum += reportRows[i].Sum;
            }
            return totalSum;
        }


        private void CreatePage(Document document)
        {
            // Each MigraDoc document needs at least one section.
            Section section = document.AddSection();

            // Create footer
            Paragraph paragraph = section.Headers.Primary.AddParagraph();
            paragraph.AddText("Team SharpShooter - TelerikAcademy 2014");
            paragraph.Format.Font.Size = 18;
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            // Create the item table
            this.mainTable = section.AddTable();
            mainTable.Style = "Table";
            mainTable.Borders.Color = Colors.Azure;
            mainTable.Borders.Width = 0.25;
            mainTable.Borders.Left.Width = 0.5;
            mainTable.Borders.Right.Width = 0.5;
            mainTable.Rows.LeftIndent = 0;

            // Before you can add a row, you must define the columns
            Column column = mainTable.AddColumn("6.5cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = mainTable.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = mainTable.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = mainTable.AddColumn("3.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = mainTable.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            // Create the header of the table
            Row row = mainTable.AddRow();
            row.Height = "1cm";
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = Colors.LightGray;
            row.Cells[0].AddParagraph("BattleNetShop Aggregated Sales Report");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[0].MergeRight = 4;

            row = mainTable.AddRow();
            row.Height = "1cm";
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = Colors.YellowGreen;
            row.Cells[0].AddParagraph("Product");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[1].AddParagraph("Quantity");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[2].AddParagraph("Unit Price");
            row.Cells[2].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[2].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[3].AddParagraph("Vendor");
            row.Cells[3].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[3].VerticalAlignment = VerticalAlignment.Center;
            row.Cells[4].AddParagraph("Sum");
            row.Cells[4].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[4].VerticalAlignment = VerticalAlignment.Center;

            mainTable.SetEdge(0, 0, 5, 2, Edge.Box, BorderStyle.Single, 0.75, Color.Empty);
        }

        private void DefineStyles(Document document)
        {
            // Get the predefined style Normal.
            Style style = document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Arial";

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal
            style = document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
            style.Font.Name = "Times New Roman";
            style.Font.Size = 9;

            // Create a new style called Reference based on style Normal
            style = document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);
        }
    }
}
