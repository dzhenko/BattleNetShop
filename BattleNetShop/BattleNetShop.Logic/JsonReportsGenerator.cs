namespace BattleNetShop.Logic
{
    using System;
    using System.Linq;

    using BattleNetShop.Data.Json;

    public class JsonReportsGenerator
    {
        private Lazy<MsSqlReportsFetcher> msSqlReportsFetcher = new Lazy<MsSqlReportsFetcher>();

        private Lazy<JsonHandler> jsonHandler = new Lazy<JsonHandler>();

        public void Generate()
        {
            var allProductsInformation = msSqlReportsFetcher.Value.GetAllProductInformations();

            foreach (var report in allProductsInformation)
            {
                jsonHandler.Value.GenerateJsonFileReport(report);
            }
        }
    }
}
