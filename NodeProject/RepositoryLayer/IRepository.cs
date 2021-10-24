using System.Linq;
using System.Threading.Tasks;

namespace NodeProject.RepositoryLayer
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
