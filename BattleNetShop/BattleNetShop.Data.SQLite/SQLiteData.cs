namespace BattleNetShop.Data.SqLite
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Linq;

    public class SqLiteData
    {
        private SqLiteHandler handler;

        public SqLiteData()
            : this(new SqLiteHandler())
        {
        }

        public SqLiteData(SqLiteHandler handler)
        {
            this.handler = handler;
        }

        // Task 6 input
        public ICollection<ProductsTaxes> ReadProductTaxes()
        {
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM ProductsTaxes", this.handler.Connection);
            SQLiteDataReader reader = command.ExecuteReader();

            var productsWithTaxes = new LinkedList<ProductsTaxes>();
            using (reader)
            {
                while (reader.Read())
                {
                    productsWithTaxes.AddLast(new ProductsTaxes(reader[0].ToString(), float.Parse(reader[1].ToString())));
                }
            }

            return productsWithTaxes;
        }
    }
}