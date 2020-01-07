using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;

namespace NewNest.Models
{
    public class NewNestRepository : INewNestRepository
    {
        private readonly INewNestContext _context;
        public NewNestRepository(INewNestContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            return await _context
                            .People
                            .Find(_ => true)
                            .ToListAsync();
        }
        public Task<Person> GetPerson(long id)
        {
            FilterDefinition<Person> filter = Builders<Person>.Filter.Eq(m => m.Id, id);
            return _context.People
                .Find(filter)
                .FirstOrDefaultAsync();
        }
        public async Task Create(Person person)
        {
            await _context.People.InsertOneAsync(person);
        }
        public async Task<bool> Update(Person person)
        {
            ReplaceOneResult updateResult = await _context.People
                .ReplaceOneAsync(
                    filter: g => g.Id == person.Id,
                    replacement: person);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> Delete(long id)
        {
            FilterDefinition<Person> filter = Builders<Person>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _context.People
                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
        public async Task<long> GetNextId()
        {
            return await _context.People.CountDocumentsAsync(new BsonDocument()) + 1;
        }
    }
}
