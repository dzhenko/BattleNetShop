namespace BattleNetShop.Data.SqLite
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.IO;
    using System.Linq;

    using BattleNetShop.Model;

    public class SqLiteData
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

        // Task 6 input
        public IEnumerable<ProductTax> ReadProductTaxes()
        {
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM ProductsTaxes", this.connection.Value);
            SQLiteDataReader reader = command.ExecuteReader();

            var productsWithTaxes = new LinkedList<ProductTax>();
            using (reader)
            {
                while (reader.Read())
                {
                    productsWithTaxes.AddLast(new ProductTax(reader[0].ToString(), float.Parse(reader[1].ToString())));
                }
            }

            return productsWithTaxes;
        }
    }
}