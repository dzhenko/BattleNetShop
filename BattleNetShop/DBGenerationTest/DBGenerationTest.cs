namespace DBGenerationTest
{
    using System;
    using System.Linq;

    using BattleNetShop.Data.MSSQL;
    using BattleNetShop.Model;
    using BattleNetShop.Data.Excel.Xls;
    using BattleNetShop.Data.MongoDb;
    using BattleNetShop.Logic;

    public class DBGenerationTest
    {
        public static void Main()
        {
            new ExcelReportsLoader().Load();

            //var db = new BattleNetShopMSSQLDbContext();

            //Console.WriteLine(db.Categories.FirstOrDefault());

            // new MongoDataSeeder().Seed();

            //var coll = new MongoDbData().GetAllProducts();

            //Console.WriteLine();

            //var mongo = new MongoDBHandler();

            //mongo.ReadCollection<Product>("Products", p => Console.WriteLine(p.Name));

            //var excelXlsData = new ExcelXlsData();
            //
            //var zipSeeder = new ExcelZippedDataSeeder();
            //
            //zipSeeder.Seed(1);
            //
            //var excelXlsHander = new ExcelXlsHandler();
            //
            //excelXlsHander.ReadInitialDataFile("Categories$", row => Console.WriteLine(row[1]));
        }
    }
}
