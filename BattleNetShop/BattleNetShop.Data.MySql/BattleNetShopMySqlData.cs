namespace BattleNetShop.Data.MySql
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BattleNetShopMySqlData
    {
        private IBattleNetShopMySqlGenericRepository salesReportRepository;

        public BattleNetShopMySqlData(IBattleNetShopMySqlGenericRepository salesReportRepositoryToUse)
        {
            this.salesReportRepository = salesReportRepositoryToUse;
        }

        public BattleNetShopMySqlData()
            : this(new BattleNetShopMySqlGenericRepository())
        {
        }

        public IQueryable<Salereport> LoadReports()
        {
            return this.salesReportRepository.All();
        }

        public void SaveReports(IEnumerable<Salereport> reports)
        {
            this.salesReportRepository.AddMany(reports);
        }
    }
}
