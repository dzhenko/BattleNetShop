namespace BattleNetShop.Data.MSSQL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<BattleNetShopMSSQLDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // TODO: Remove Data Loss Allowed on deploy
            this.AutomaticMigrationDataLossAllowed = true;

            this.ContextKey = "BattleNetShop.Data.BattleNetShopDbContext";
        }

        protected override void Seed(BattleNetShopMSSQLDbContext context)
        {
            // TODO: Seed with initial data from excel AddOrUpdate()
        }
    }
}
