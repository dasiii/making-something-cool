using System;
using MongoDB.Driver;

namespace NewNest.Models
{
    public class NewNestContext: INewNestContext
    {
        private readonly IMongoDatabase _db;
        public NewNestContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }
        public IMongoCollection<Person> People => _db.GetCollection<Person>("People");
    }
}