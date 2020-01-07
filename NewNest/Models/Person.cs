using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NewNest.Models
{
    public class Person
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}