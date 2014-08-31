namespace BattleNetShop.Logic
{
    using System;

    using BattleNetShop.Data.Excel.Xls;
    using BattleNetShop.Data.MongoDb;

    public class DataSeeder
    {
        public void Seed()
        {
            Console.WriteLine("Seeding mongo data...");
            new MongoDataSeeder().Seed();

            Console.WriteLine("Seeding excel data...");
            new ExcelZippedDataSeeder().Seed(3);
        }
    }
}