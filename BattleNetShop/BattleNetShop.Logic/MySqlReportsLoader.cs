namespace BattleNetShop.Logic
{
    using System;

    using BattleNetShop.Data.MySql;

    public class MySqlReportsLoader
    {
        private readonly Lazy<MsSqlReportsFetcher> msSqlReportsFetcher = new Lazy<MsSqlReportsFetcher>();
        private readonly Lazy<MySqlHandler> mySqlHandler = new Lazy<MySqlHandler>();

        public void Load()
        {
            Console.WriteLine("Loading data into MySQL...");
            var allProductsInformation = msSqlReportsFetcher.Value.GetAllProductInformations();

            foreach (var report in allProductsInformation)
            {
                Salereport salesReportRecord = new Salereport();
                salesReportRecord.Product_id = report.ProductId;
                salesReportRecord.ProductName = report.Name;
                // TODO: fix to decimal, fix db generation script
                salesReportRecord.TotalIncomes = (int)report.Total;
                salesReportRecord.TotalQuantitySold = report.Quantity;
                salesReportRecord.VendorName = report.Vendor;
                mySqlHandler.Value.WriteReport(salesReportRecord);
            }
        }
    }
}
