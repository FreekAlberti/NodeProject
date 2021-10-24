using Mapster;
using Microsoft.EntityFrameworkCore;
using NodeProject.DatabaseLayer.Models;
using NodeProject.Dtos;
using NodeProject.RepositoryLayer;
using NodeProject.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodeProject.ControllerLayer
{
    public class AmministratorService
    {
        private readonly IRepository<Vacancy> _repository;

        public AmministratorService(IRepository<Vacancy> repository)
        {
            _repository = repository;
        }
        internal async Task<PaginatedList<Vacancy>> GetAllVacancies(string searchString, int? pageNumber)
        {
            int pageSize = 8;
            IQueryable<Vacancy> queryVacancies = _repository.GetAll()
                .OrderByDescending(o => o.VacancyPublish)
                .AsNoTracking();
            if (!String.IsNullOrEmpty(searchString))
            {
                queryVacancies = queryVacancies.Where(w => w.VacancyTitle.Contains(searchString)
                                       || w.VacancyDescription.Contains(searchString)
                                       || w.VacancyBenefits.Contains(searchString));
            }
            return await PaginatedList<Vacancy>.CreateAsync(queryVacancies, pageNumber ?? 1, pageSize);
        }

        internal Task<Vacancy> GetVacancyById(int? id, bool include, bool noTracking)
        {
            if (id == null)
            {
                return Task.FromResult<Vacancy>(null);
            }
            var queryGetVacancy = _repository.GetAll().Where(w => w.VacancyID == id);
            if (include)
            {
                queryGetVacancy = queryGetVacancy
                    .Include(i => i.Company)
                    .Include(i => i.Amministrator)
                    .Include(i => i.Users);
            }
            if (noTracking)
            {
                queryGetVacancy = queryGetVacancy.AsNoTracking();
            }
            return queryGetVacancy.FirstOrDefaultAsync();
        }

        internal Task<Vacancy> CreateNewVacancy(int companyId, CreateNewVacancyDto newVacancyDto)
        {
            Vacancy newVacancy = newVacancyDto.Adapt<Vacancy>();
            newVacancy.VacancyPublish = DateTime.Now;
            newVacancy.AmministratorID = 1;
            newVacancy.CompanyID = companyId;
            return _repository.AddAsync(newVacancy);
        }

        internal Task<int> UpdateVacancy(Vacancy vacancyToUpdate)
        {
            return _repository.UpdateAsync(vacancyToUpdate);
        }

        internal Task<int> DeleteVacancy(Vacancy vacancyToDelete)
        {
            return _repository.DeleteAsync(vacancyToDelete);
        }
    }
}