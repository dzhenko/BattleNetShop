namespace BattleNetShop.Data.SqLite
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.IO;

    public class SqLiteHandler : IDisposable
    {
        private SQLiteConnection connection;

        public SQLiteConnection Connection
        {
            get
            {
                return this.connection;
            }
        }

        public SqLiteHandler()
        {
            string dbLocation = SqLiteDbSettings.Default.SQLiteDBLocation;
            if (!File.Exists(dbLocation))
            {
                SQLiteConnection.CreateFile(dbLocation);
            }

            string connectionString = String.Format(SqLiteDbSettings.Default.SQLiteConnectionString, dbLocation);
            this.connection = new SQLiteConnection(connectionString);
            this.connection.Open();
        }

        public void Dispose()
        {
            this.connection.Close();
        }
    }
}