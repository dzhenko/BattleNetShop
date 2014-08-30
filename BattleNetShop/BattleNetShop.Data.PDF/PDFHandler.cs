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
        public void GenerateReport(ICollection<Tuple<DateTime, ICollection<Tuple<string, int, decimal, string, decimal>>>> salesByDate, string filePath)
        {
            throw new NotImplementedException();
        }

        public void TestPdfCreate()
        {
            Document document = new Document();
            document.Info.Title = "BattleNet Sales Report";
            document.Info.Author = "Stamat Georgiev";
            document.Info.Subject = "This is the description of the document";
            document.Info.Keywords = "Blizzard, BattleNet, Diablo, Warcraft, Sales, Items";

            DefineStyles(document);

            CreatePage(document);

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
            pdfRenderer.Document = document;

            pdfRenderer.RenderDocument();

            string fileName = "NzhulTestReport.pdf";
            pdfRenderer.PdfDocument.Save(fileName);

            Process.Start(fileName);

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


            //// Create the item table
            //Table mainTable = section.AddTable();
            //mainTable.Style = "Table";
            //mainTable.Borders.Color = Colors.Azure;
            //mainTable.Borders.Width = 0.25;
            //mainTable.Borders.Left.Width = 0.5;
            //mainTable.Borders.Right.Width = 0.5;
            //mainTable.Rows.LeftIndent = 0;

            //// Before you can add a row, you must define the columns
            //Column column = mainTable.AddColumn("1cm");
            //column.Format.Alignment = ParagraphAlignment.Center;

            //column = mainTable.AddColumn("2.5cm");
            //column.Format.Alignment = ParagraphAlignment.Right;

            //column = mainTable.AddColumn("3cm");
            //column.Format.Alignment = ParagraphAlignment.Right;

            //column = mainTable.AddColumn("3.5cm");
            //column.Format.Alignment = ParagraphAlignment.Right;

            //column = mainTable.AddColumn("2cm");
            //column.Format.Alignment = ParagraphAlignment.Center;

            //column = mainTable.AddColumn("4cm");
            //column.Format.Alignment = ParagraphAlignment.Right;

            //// Create the header of the table
            //Row row = mainTable.AddRow();
            //row.HeadingFormat = true;
            //row.Format.Alignment = ParagraphAlignment.Center;
            //row.Format.Font.Bold = true;
            //row.Shading.Color = Colors.Blue;
            //row.Cells[0].AddParagraph("Item");
            //row.Cells[0].Format.Font.Bold = false;
            //row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            //row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            //row.Cells[0].MergeDown = 1;
            //row.Cells[1].AddParagraph("Title and Author");
            //row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            //row.Cells[1].MergeRight = 3;
            //row.Cells[5].AddParagraph("Extended Price");
            //row.Cells[5].Format.Alignment = ParagraphAlignment.Left;
            //row.Cells[5].VerticalAlignment = VerticalAlignment.Bottom;
            //row.Cells[5].MergeDown = 1;

            //row = mainTable.AddRow();
            //row.HeadingFormat = true;
            //row.Format.Alignment = ParagraphAlignment.Center;
            //row.Format.Font.Bold = true;
            //row.Shading.Color = Colors.Blue;
            //row.Cells[1].AddParagraph("Quantity");
            //row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            //row.Cells[2].AddParagraph("Unit Price");
            //row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
            //row.Cells[3].AddParagraph("Discount (%)");
            //row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
            //row.Cells[4].AddParagraph("Taxable");
            //row.Cells[4].Format.Alignment = ParagraphAlignment.Left;

            //mainTable.SetEdge(0, 0, 6, 2, Edge.Box, BorderStyle.Single, 0.75, Color.Empty);
        }

        private void DefineStyles(Document document)
            {
              // Get the predefined style Normal.
              Style style = document.Styles["Normal"];
              // Because all styles are derived from Normal, the next line changes the 
              // font of the whole document. Or, more exactly, it changes the font of
              // all styles and paragraphs that do not redefine the font.
              style.Font.Name = "Verdana";
 
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
