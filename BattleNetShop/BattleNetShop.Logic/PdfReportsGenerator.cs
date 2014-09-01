namespace BattleNetShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BattleNetShop.Data.SqlServer;
    using BattleNetShop.Data.Pdf;

    using BattleNetShop.Model;
    using BattleNetShop.ReportsModel;

    public class PdfReportsGenerator
    {
        private Lazy<MsSqlReportsFetcher> msSqlReportsFetcher = new Lazy<MsSqlReportsFetcher>();
        private Lazy<PdfHandler> pdfHandler = new Lazy<PdfHandler>();

        public void Generate()
        {
           this.GenerateAllProductsReportForDate(new DateTime(2014, 1, 1));

           this.GenerateAllProductsReportForPeriod(new[] { new DateTime(2014, 1, 1), new DateTime(2014, 1, 2), new DateTime(2014, 1, 3) });

           this.GenerateProductInfoForDates("Shako");

           this.GenerateProductInfoForLocations("Shako");
           
           this.GenerateLocationReportForDate(1, new DateTime(2014, 1, 1));
           
           this.GenerateLocationReportForPeriod(1, new[] { new DateTime(2014, 1, 1), new DateTime(2014, 1, 2), new DateTime(2014, 1, 3) });
        }

        public void GenerateAllProductsReportForDate(DateTime date)
        {
            var reports = msSqlReportsFetcher.Value.GetAllProductsReportForDate(date);
            pdfHandler.Value.GenerateAllProductsReportForDate(reports);
        }

        public void GenerateAllProductsReportForPeriod(IEnumerable<DateTime> dates)
        {
            var reports = msSqlReportsFetcher.Value.GetAllProductsReportForPeriod(dates);
            pdfHandler.Value.GenerateAllProductsReportForPeriod(reports);
        }

        public void GenerateProductInfoForDates(int productId)
        {
            var reports = msSqlReportsFetcher.Value.GetProductInformationForDates(productId);
            pdfHandler.Value.GenerateProductInfoForDates(reports);
        }

        public void GenerateProductInfoForDates(Product product)
        {
            var reports = msSqlReportsFetcher.Value.GetProductInformationForDates(product);
            pdfHandler.Value.GenerateProductInfoForDates(reports);
        }

        public void GenerateProductInfoForDates(string productName)
        {
            var reports = msSqlReportsFetcher.Value.GetProductInformationForDates(productName);
            pdfHandler.Value.GenerateProductInfoForDates(reports);
        }

        public void GenerateProductInfoForLocations(int productId)
        {
            var reports = msSqlReportsFetcher.Value.GetProductInformationForLocations(productId);
            pdfHandler.Value.GenerateProductInfoForLocations(reports);
        }

        public void GenerateProductInfoForLocations(Product product)
        {
            var reports = msSqlReportsFetcher.Value.GetProductInformationForLocations(product);
            pdfHandler.Value.GenerateProductInfoForLocations(reports);
        }

        public void GenerateProductInfoForLocations(string productName)
        {
            var reports = msSqlReportsFetcher.Value.GetProductInformationForLocations(productName);
            pdfHandler.Value.GenerateProductInfoForLocations(reports);
        }

        public void GenerateLocationReportForDate(PurchaseLocation location, DateTime date)
        {
            var reports = msSqlReportsFetcher.Value.GetLocationReportForDate(location, date);
            pdfHandler.Value.GenerateLocationReportForDate(reports);
        }

        public void GenerateLocationReportForDate(int locationId, DateTime date)
        {
            var reports = msSqlReportsFetcher.Value.GetLocationReportForDate(locationId, date);
            pdfHandler.Value.GenerateLocationReportForDate(reports);
        }

        public void GenerateLocationReportForDate(string locationName, DateTime date)
        {
            var reports = msSqlReportsFetcher.Value.GetLocationReportForDate(locationName, date);
            pdfHandler.Value.GenerateLocationReportForDate(reports);
        }

        public void GenerateLocationReportForPeriod(PurchaseLocation location, IEnumerable<DateTime> dates)
        {
            var reports = msSqlReportsFetcher.Value.GetLocationReportForPeriod(location, dates);
            pdfHandler.Value.GenerateLocationReportForPeriod(reports);
        }

        public void GenerateLocationReportForPeriod(int LocationId, IEnumerable<DateTime> dates)
        {
            var reports = msSqlReportsFetcher.Value.GetLocationReportForPeriod(LocationId, dates);
            pdfHandler.Value.GenerateLocationReportForPeriod(reports);
        }

        public void GenerateLocationReportForPeriod(string locationName, IEnumerable<DateTime> dates)
        {
            var reports = msSqlReportsFetcher.Value.GetLocationReportForPeriod(locationName, dates);
            pdfHandler.Value.GenerateLocationReportForPeriod(reports);
        }
    }
}