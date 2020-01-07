using MongoDB.Driver;

namespace NewNest.Models
{
    public interface INewNestContext
    {
        IMongoCollection<Person> People { get; }
    }
}