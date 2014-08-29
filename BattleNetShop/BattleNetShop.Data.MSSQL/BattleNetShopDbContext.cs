namespace BattleNetShop.Data.MSSQL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using BattleNetShop.Model;
    using BattleNetShop.Data.MSSQL.Migrations;

    public class BattleNetShopDbContext : DbContext
    {
        public BattleNetShopDbContext()
            : base("BattleNetShopConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BattleNetShopDbContext, Configuration>());
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Vendor> Vendors { get; set; }

        public IDbSet<Details> Details { get; set; }

        public IDbSet<Purchase> Purchases { get; set; }

        public IDbSet<Date> Dates { get; set; }

        public IDbSet<Location> Locations { get; set; }
    }
}