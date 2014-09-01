namespace SQLiteDBGenerationTest
{
    using System;
    using BattleNetShop.Data.SqLite;

    class SQLiteDBGenerationTest
    {
        static void Main()
        {
            SqLiteDataSeeder seeder = new SqLiteDataSeeder();
            seeder.CreateSQLiteTableProductsTaxes();
            seeder.SeedTableProductsTaxes();
            SqLiteData sqliteData = new SqLiteData();
            var productsTaxes = sqliteData.ReadProductTaxes();
            foreach (var item in productsTaxes)
            {
                Console.WriteLine(item.Item1 + "\t" + item.Item2);
            }
        }
    }
}