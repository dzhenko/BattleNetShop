namespace BattleNetShop.Data.MSSQL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using BattleNetShop.Model;
    using BattleNetShop.Data.MSSQL.Migrations;

    public class BattleNetShopMSSQLDbContext : DbContext, IBattleNetShopMSSQLDbContext
    {
        public BattleNetShopMSSQLDbContext()
            : base(MSSQLSettings.Default.ConnectionStringExpress)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BattleNetShopMSSQLDbContext, Configuration>());
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<ProductCategory> Categories { get; set; }

        public IDbSet<Vendor> Vendors { get; set; }

        public IDbSet<ProductDetails> Details { get; set; }

        public IDbSet<Purchase> Purchases { get; set; }

        public IDbSet<PurchaseLocation> Locations { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}