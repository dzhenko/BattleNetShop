﻿namespace BattleNetShop.Data.SQLite
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Linq;

    public class SQLiteData
    {
        private SQLiteHandler handler;

        public SQLiteData()
            : this(new SQLiteHandler())
        {
        }

        public SQLiteData(SQLiteHandler handler)
        {
            this.handler = handler;
        }

        // Tuple<string, ICollection<Tuple<string, decimal>> will become a class
        // Task 6 input
        public ICollection<Tuple<string, float>> ReadProductTaxes()
        {
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM ProductsTaxes", this.handler.Connection);
            SQLiteDataReader reader = command.ExecuteReader();

            var productsWithTaxes = new LinkedList<Tuple<string, float>>();
            using (reader)
            {
                while (reader.Read())
                {
                    productsWithTaxes.AddLast(new Tuple<string, float>(reader[0].ToString(), float.Parse(reader[1].ToString())));
                }
            }

            return productsWithTaxes;
        }
    }
}