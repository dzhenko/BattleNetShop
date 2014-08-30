namespace BattleNetShop.Data.MongoDb
{
    using System;
    using System.Collections.Generic;

    using MongoDB.Driver;

    using BattleNetShop.Model;

    class MongoDBHandler
    {
        private Lazy<MongoDatabase> database = new Lazy<MongoDatabase>(CreateConnection);

        public void ReadCollection<T>(string collectionName, Action<T> action)
        {
            var cursor = database.Value.GetCollection(collectionName).FindAllAs<T>();

            foreach (var category in cursor)
            {
                action(category);
            }
        }

        public void WriteCollection<T>(string collectionName, ICollection<T> collectionItems)
        {
            MongoCollection<T> collection = database.Value.GetCollection<T>(collectionName);

            foreach (var item in collectionItems)
            {
                collection.Insert(item);
            }
        }

        private static MongoDatabase CreateConnection() 
        {
            // Create server settings to pass connection string, timeout, etc.
            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress(MongoDBSettings.Default.MongoDBAddress, MongoDBSettings.Default.MongoDBPort);

            // Create server object to communicate with our server
            MongoServer server = new MongoServer(settings);

            // Get our database instance to reach collections and data
            var database = server.GetDatabase(MongoDBSettings.Default.MongoDBName);

            return database;
        }
    }
}
