namespace BattleNetShop.Data.PDF
{
    using System;
    using System.Collections.Generic;

    using BattleNetShop.ReportsModel;

    public class PDFHandler
    {
        public void GenerateAllProductsReportForDate(ProductsReport report)
        {
            //magic DATE (rows = all products names)
        }

        public void GenerateAllProductsReportForPeriod(IEnumerable<ProductsReport> reports)
        {
            //magic DATE (rows = all products names)
            PDFMagic.InitDocumentCreation();
            PDFMagic.TableHeader();
            PDFMagic.Columns(6);
            PDFMagic.HeaderRows("Specific Date");
            foreach (var report in reports)
            {
                PDFMagic.FillData(report.Products);
            }
            PDFMagic.RenderDocument();
        }

        public void GenerateProductInfoForDates(IEnumerable<ProductsReport> productSales)
        {
            // PRoduct (rows = dates)
        }

        public void GenerateProductInfoForLocations(IEnumerable<ProductsReport> productSales)
        {
            //product (rows = locations)
        }

        public void GenerateLocationReportForDate(ProductsReport report)
        {
            //magic

        }

        public void GenerateLocationReportForPeriod(IEnumerable<ProductsReport> reports)
        {
            //magic
        }
    }
}
