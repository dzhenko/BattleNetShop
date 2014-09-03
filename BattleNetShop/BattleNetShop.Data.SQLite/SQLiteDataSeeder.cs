namespace BattleNetShop.Data.SqLite
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Linq;

    using BattleNetShop.Data.Excel.Xls;
    using System.IO;

    public class SqLiteDataSeeder
    {
        private Lazy<SQLiteConnection> connection = new Lazy<SQLiteConnection>(() =>
            {
                var dbLocation = SqLiteDbSettings.Default.SQLiteDBLocation;
                if (!File.Exists(dbLocation))
                {
                    SQLiteConnection.CreateFile(dbLocation);
                }
                var connection = new SQLiteConnection(SqLiteDbSettings.Default.SqLiteConnectionString);
                connection.Open();
                return connection;
            });

        public void Seed()
        {
            this.CreateSQLiteTableProductsTaxesIfNotExist();
            this.DeleteOldRecordsFromProductsTaxes();
            this.SeedTableProductsTaxes(200);
        }

        public void CreateSQLiteTableProductsTaxesIfNotExist()
        {
            string createTableSql = "CREATE TABLE IF NOT EXISTS ProductsTaxes (ProductName NVARCHAR(50), Tax REAL)";
            SQLiteCommand createTableCommand = new SQLiteCommand(createTableSql, this.connection.Value);
            createTableCommand.ExecuteNonQuery();
        }

        public void SeedTableProductsTaxes(int maxTaxValue)
        {
            Random randomGen = new Random();
            string addCommandSql = "INSERT INTO ProductsTaxes(ProductName, Tax) VALUES(@productName, @tax)";
            SQLiteCommand command = new SQLiteCommand(addCommandSql, this.connection.Value);
            var xlsHandler = new ExcelXlsHandler();
            var productNames = new HashSet<string>();
            xlsHandler.ReadInitialDataFile("Products$", r => productNames.Add(r["Product Name"].ToString()));
            foreach (var productName in productNames)
            {
                float tax = (float)randomGen.NextDouble() * maxTaxValue;
                command.Parameters.AddWithValue("@productName", productName);
                command.Parameters.AddWithValue("@tax", tax);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteOldRecordsFromProductsTaxes()
        {
            string addCommandSql = "DELETE FROM ProductsTaxes";
            SQLiteCommand command = new SQLiteCommand(addCommandSql, this.connection.Value);
            command.ExecuteNonQuery();
        }
    }
}