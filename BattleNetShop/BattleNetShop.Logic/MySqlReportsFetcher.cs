namespace BattleNetShop.Logic
{
    using System;
    using System.Collections.Generic;

    using BattleNetShop.Data.MySql;

    public class MySqlReportsFetcher
    {
        private readonly Lazy<MySqlHandler> mySqlHandler = new Lazy<MySqlHandler>();

        public IEnumerable<Salereport> GetSaleReport()
        {
            var report = new LinkedList<Salereport>();
            this.mySqlHandler.Value.ReadAllReports(s => report.AddLast(s));

            return report;
        }
    }
}
