namespace BattleNetShop.Data.MSSQL.Repositories
{
    using System;
    using System.Linq;
    using System.Text;
    using BattleNetShop.Model;

    public class BulkOperationsGenericRepository : GenericRepository<Purchase>, IGenericRepository<Purchase>
    {
        public BulkOperationsGenericRepository(IBattleNetShopMSSQLDbContext battleNetShopMSSQLDbContext)
            : base(battleNetShopMSSQLDbContext)
        {
        }

        public BulkOperationsGenericRepository()
            : base()
        {
        }

        public void BulkAddPurchases(Purchase[] purchases)
        {
            if (purchases.Length == 0)
            {
                return;
            }

            var sqlBuilder = new StringBuilder();
            sqlBuilder.Append("INSERT INTO Purchases(ProductId, Quantity, UnitPrice, [Date], LocationId) VALUES ");

            foreach (var purchase in purchases)
            {
                sqlBuilder.AppendFormat(" ({0}, {1}, {2}, {3}, {4}),", 
                    purchase.ProductId, purchase.Quantity, purchase.UnitPrice, purchase.Date, purchase.LocationId);
            }

            sqlBuilder.Length--;

            var tran = this.Context.Database.BeginTransaction();

            try
            {
                this.Context.Database.ExecuteSqlCommand(sqlBuilder.ToString(), null);
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
        }
    }
}
