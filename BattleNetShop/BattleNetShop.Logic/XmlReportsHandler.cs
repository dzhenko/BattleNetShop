namespace BattleNetShop.Logic
{
    using System;
    using System.Linq;

    using BattleNetShop.Data.MongoDb;
    using BattleNetShop.Data.SqlServer;
    using BattleNetShop.Data.Xml;

    public class XmlReportsHandler
    {
        private readonly IXmlData xmlData;
        private readonly IBattleNetShopSqlServerData msSqlData;
        private readonly IMongoDbData mongoData;

        private readonly Lazy<MsSqlReportsFetcher> msSqlReportsFetcher = new Lazy<MsSqlReportsFetcher>();

        public XmlReportsHandler()
            : this(new XmlData(), new BattleNetShopSqlServerData(), new MongoDbData())
        {
        }

        public XmlReportsHandler(IXmlData xmlDataToUse, IBattleNetShopSqlServerData msSqlDataToUse, IMongoDbData mongoDbDataToUse)
        {
            this.xmlData = xmlDataToUse;
            this.msSqlData = msSqlDataToUse;
            this.mongoData = mongoDbDataToUse;
        }

        public void Load()
        {
            var vendorExpenses = this.xmlData.GetAllVendorExpenses();

            this.mongoData.SaveExpenses(vendorExpenses);

            foreach (var expense in vendorExpenses)
            {
                this.msSqlData.VendorExpenses.Add(expense);
            }

            this.msSqlData.SaveChanges();
        }

        public void Generate()
        {
            var locationsReport = this.msSqlReportsFetcher.Value.GetAllLocationsReport().ToList();

            this.xmlData.GenerateAllLocationsReport(locationsReport);
        }
    }
}
