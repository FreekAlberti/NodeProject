using Microsoft.EntityFrameworkCore;
using NodeProject.DatabaseLayer.Models;
using NodeProject.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NodeProject.ServiceLayer
{
    public class RequestService
    {
        private readonly IRepository<Request> _repository;

        public RequestService(IRepository<Request> repository)
        {
            _repository = repository;
        }
        internal Task<List<Request>> GetAllRequest()
        {
            return _repository.GetAll().Include(i => i.Company).AsNoTracking().ToListAsync();
        }

        internal Task<Request> GetRequestById(int id)
        {
            return _repository.GetAll().FirstOrDefaultAsync(f => f.RequestID == id);
        }

        internal Task<int> DeleteRequest(Request requestToDelete)
        {
            return _repository.DeleteAsync(requestToDelete);
        }
    }
}
