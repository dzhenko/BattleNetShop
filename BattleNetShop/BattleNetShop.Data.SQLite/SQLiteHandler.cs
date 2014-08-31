namespace BattleNetShop.Data.SQLite
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.IO;

    public class SQLiteHandler : IDisposable
    {
        private SQLiteConnection connection;

        public SQLiteConnection Connection
        {
            get
            {
                return this.connection;
            }
        }

        public SQLiteHandler()
        {
            string dbLocation = SQLiteDBSettings.Default.SQLiteDBLocation;
            if (!File.Exists(dbLocation))
            {
                SQLiteConnection.CreateFile(dbLocation);
            }

            string connectionString = String.Format(SQLiteDBSettings.Default.SQLiteConnectionString, dbLocation);
            this.connection = new SQLiteConnection(connectionString);
            this.connection.Open();
        }

        public void Dispose()
        {
            this.connection.Close();
        }
    }
}