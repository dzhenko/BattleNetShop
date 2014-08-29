namespace DBGenerationTest
{
    using System;
    using System.Linq;

    using BattleNetShop.Data.MSSQL;
    using BattleNetShop.Model;
    using BattleNetShop.Data.Excel.Xls;

    public class DBGenerationTest
    {
        public static void Main()
        {
            //var db = new BattleNetShopDbContext();

            //Console.WriteLine(db.Products.FirstOrDefault());

            //BattleNetShop.Initial.MongoDBSeed.MongoDBSeed.SeedData();

            //BattleNetShop.Initial.ZippedExcelFilesSeed.ZippedExcelFilesSeed.SeedData();

            var oldExcel = new ExcelXlsHandler();
            var zipSeeder = new ExcelZippedDataSeeder();
            zipSeeder.Seed(@"testMe", 200);
        }
    }
}
