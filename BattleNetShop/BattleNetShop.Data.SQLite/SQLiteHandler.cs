namespace BattleNetShop.Data.SqLite
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.IO;

    public class SqLiteHandler : IDisposable
    {
        private SQLiteConnection connection;

        public SqLiteHandler()
        {
            var dbLocation = SqLiteDbSettings.Default.SQLiteDBLocation;
            if (!File.Exists(dbLocation))
            {
                SQLiteConnection.CreateFile(dbLocation);
            }

            var connectionString = string.Format(SqLiteDbSettings.Default.SQLiteConnectionString, dbLocation);
            this.connection = new SQLiteConnection(connectionString);
            this.connection.Open();
        }

        public SQLiteConnection Connection
        {
            get
            {
                return this.connection;
            }
        }

        public void Dispose()
        {
            this.connection.Close();
        }
    }
}