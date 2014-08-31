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
            var folderLocation = PdfSettings.Default.ReportsFolder;
        }

        public void GenerateAllProductsReportForPeriod(ICollection<ProductsReport> reports)
        {
            //magic DATE (rows = all products names)
        }

        public void GenerateProductInfoForDates(ICollection<ProductsReport> productSales)
        {
            // PRoduct (rows = dates)
        }

        public void GenerateProductInfoForLocations(ICollection<ProductsReport> productSales)
        {
            //product (rows = locations)
        }

        public void GenerateLocationReportForDate(ProductsReport report)
        {
            //magic
        }

        public void GenerateLocationReportForPeriod(ICollection<ProductsReport> reports)
        {
            //magic
        }
    }
}
