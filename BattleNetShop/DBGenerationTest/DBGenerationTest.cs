namespace DBGenerationTest
{
    using System;
    using System.Linq;

    using BattleNetShop.Data;
    using BattleNetShop.Model;

    public class Tests
    {
        public static void Main()
        {
            var db = new BattleNetShopDbContext();

            Console.WriteLine(db.Products.FirstOrDefault());

            BattleNetShop.Initial.MongoDBSeed.MongoDBSeed.SeedData();

            BattleNetShop.Initial.ZippedExcelFilesSeed.ZippedExcelFilesSeed.SeedData();
        }
    }
}
