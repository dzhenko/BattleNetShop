namespace BattleNetShop.Data.SqLite
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Linq;

    using BattleNetShop.Data.Excel.Xls;

    public class SqLiteDataSeeder
    {
        private static int maxTaxAmount = 30;

        private SqLiteHandler handler;

        public SqLiteDataSeeder()
            : this(new SqLiteHandler())
        {
        }

        public SqLiteDataSeeder(SqLiteHandler handler)
        {
            this.handler = handler;
        }

        public void CreateSQLiteTableProductsTaxesIfNotExist()
        {
            string createTableSql = "CREATE TABLE IF NOT EXISTS ProductsTaxes (ProductName NVARCHAR(50), Tax REAL)";
            SQLiteCommand createTableCommand = new SQLiteCommand(createTableSql, this.handler.Connection);
            createTableCommand.ExecuteNonQuery();
        }

        public void SeedTableProductsTaxes()
        {
            Random randomGen = new Random();
            string addCommandSql = "INSERT INTO ProductsTaxes(ProductName, Tax) VALUES(@productName, @tax)";
            SQLiteCommand command = new SQLiteCommand(addCommandSql, this.handler.Connection);
            var xlsHandler = new ExcelXlsHandler();
            var productNames = new HashSet<string>();
            xlsHandler.ReadInitialDataFile("Products$", r => productNames.Add(r["Product Name"].ToString()));
            foreach (var productName in productNames)
            {
                float tax = (float)randomGen.NextDouble() * maxTaxAmount;
                command.Parameters.AddWithValue("@productName", productName);
                command.Parameters.AddWithValue("@tax", tax);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteOldRecordsFromProductsTaxes()
        {
            string addCommandSql = "DELETE FROM ProductsTaxes";
            SQLiteCommand command = new SQLiteCommand(addCommandSql, this.handler.Connection);
            var xlsHandler = new ExcelXlsHandler();
            command.ExecuteNonQuery();
        }
    }
}