namespace SQLiteDBGenerationTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BattleNetShop.Data.SQLite;
    using System.IO;

    class SQLiteDBGenerationTest
    {
        static void Main()
        {
            SQLiteHandler sqliteHandler = new SQLiteHandler();
            //Uncomment if for the 1st time
            //sqliteHandler.CreateSQLiteDB();
            sqliteHandler.SeedData();
            var productsTaxes = sqliteHandler.ReadProductTaxes();
            foreach (var item in productsTaxes)
            {
                Console.WriteLine(item.Item1 + "\t" + item.Item2);
            }
        }
    }
}