namespace BattleNetShop.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<BattleNetShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            // TODO: Remove Data Loss Allowed on deploy
            AutomaticMigrationDataLossAllowed = true;

            ContextKey = "BattleNetShop.Data.BattleNetShopDbContext";
        }

        protected override void Seed(BattleNetShopDbContext context)
        {
            // TODO: Seed with initial data from excel AddOrUpdate()
        }
    }
}
