namespace BattleNetShop.Initial.MongoDBSeed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MongoDB.Bson;
    using MongoDB.Driver;

    /// <summary>
    /// Class used to initialize the data in the MongoDB used as input for task one.
    /// The data is retrieved from an excel file in the Project directory.
    /// </summary>
    public static class MongoDBSeed
    {
        // TODO: Write some magic
        public static void SeedData()
        {
            var mongoClient = new MongoClient(MongoDBSettings.Default.MongoDBLocalConnection);
            var mongoServer = mongoClient.GetServer();
            var database = mongoServer.GetDatabase(MongoDBSettings.Default.MongoDBName);


        }
    }
}
