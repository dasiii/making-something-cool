using System.Collections.Generic;
using System.Threading.Tasks;
namespace NewNest.Models
{
    public interface INewNestRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(long id);
        Task Create(T t);
        Task<bool> Update(T t);
        Task<bool> Delete(long id);
        Task<long> GetNextId();
    }
}