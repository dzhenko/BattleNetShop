namespace SQLiteDBGenerationTest
{
    using System;
    using BattleNetShop.Data.SQLite;

    class SQLiteDBGenerationTest
    {
        static void Main()
        {
            SQLiteDataSeeder seeder = new SQLiteDataSeeder();
            seeder.CreateSQLiteTableProductsTaxes();
            seeder.SeedTableProductsTaxes();
            SQLiteData sqliteData = new SQLiteData();
            var productsTaxes = sqliteData.ReadProductTaxes();
            foreach (var item in productsTaxes)
            {
                Console.WriteLine(item.Item1 + "\t" + item.Item2);
            }
        }
    }
}