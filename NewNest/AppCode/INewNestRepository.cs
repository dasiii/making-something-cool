using System.Collections.Generic;
using System.Threading.Tasks;
namespace NewNest.Models
{
    public interface INewNestRepository
    {
        // api/[GET]
        Task<IEnumerable<Person>> GetAllPeople();
        // api/1/[GET]
        Task<Person> GetPerson(long id);
        // api/[POST]
        Task Create(Person person);
        // api/[PUT]
        Task<bool> Update(Person person);
        // api/1/[DELETE]
        Task<bool> Delete(long id);
        Task<long> GetNextId();
    }
}