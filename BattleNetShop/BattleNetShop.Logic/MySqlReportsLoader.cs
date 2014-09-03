namespace BattleNetShop.Logic
{
    using System;
    using System.Linq;

    using BattleNetShop.Data.MySql;

    public class MySqlReportsLoader
    {
        private readonly Lazy<MsSqlReportsFetcher> msSqlReportsFetcher = new Lazy<MsSqlReportsFetcher>();
        private readonly Lazy<BattleNetShopMySqlData> mySqlHandler = new Lazy<BattleNetShopMySqlData>();

        public void Load()
        {
            Console.WriteLine("Loading data into MySQL...");

            var allProductsReports = msSqlReportsFetcher.Value.GetAllProductInformations().Select(p => 
            {
                return new Salereport()
                {
                    Product_id = p.ProductId,
                    ProductName = p.Name,
                    TotalIncomes = (int)p.Total,
                    TotalQuantitySold = p.Quantity,
                    VendorName = p.Vendor
                };
            });

            mySqlHandler.Value.SaveReports(allProductsReports);
        }
    }
}
