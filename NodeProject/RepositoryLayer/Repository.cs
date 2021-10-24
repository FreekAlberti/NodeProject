using NodeProject.DatabaseLayer;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NodeProject.RepositoryLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly NodeProjectDbContext _context;

        public Repository(NodeProjectDbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entityToAdd)
        {
            try
            {
                await _context.AddAsync(entityToAdd);
                await _context.SaveChangesAsync();
                return entityToAdd;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entityToAdd)} could not be added: {ex.Message}");
            }
        }

        public async Task<int> DeleteAsync(T entityToDelete)
        {
            try
            {
                _context.Set<T>().Remove(entityToDelete);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entityToDelete)} could not be updated: {ex.Message}");
            }
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return _context.Set<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<int> UpdateAsync(T entityToUpdate)
        {
            try
            {
                _context.Update(entityToUpdate);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entityToUpdate)} could not be updated: {ex.Message}");
            }
        }
    }
}
