namespace BattleNetShop.Data.SqLite
{
    using BattleNetShop.Model;
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
        public IEnumerable<ProductTax> ReadProductTaxes()
        {
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM ProductsTaxes", this.handler.Connection);
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