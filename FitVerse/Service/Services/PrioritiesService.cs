using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitVerse.Model;
using FitVerse.Data.Infrastructure.Interfaces;
using FitVerse.Data.Infrastructure.IRepositories;
using FitVerse.Model.Models;
using FitVerse.Data.Infrastructure.Interfaces.IRepositories;

namespace Service.Services
{
    public class PrioritiesService : IPrioritiesService
    {
        private readonly IPrioritiesRepository prioritiesRepository;
        private readonly IUnitOfWork unitOfWork;

        public PrioritiesService(IPrioritiesRepository prioritiesRepository,
                               IUnitOfWork unitOfWork)
        {
            this.prioritiesRepository = prioritiesRepository;
            this.unitOfWork = unitOfWork;
        }

        public void UpdatePriorities(Priorities entity)
        {
            prioritiesRepository.Update(entity);
        }

        public void CreatePriorities(Priorities entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Priorities> GetCollectivePriorities(string name = null)
        {
            throw new NotImplementedException();
        }

        public Priorities GetPriorities(int id)
        {
            return prioritiesRepository.GetById(id);
        }

        public Priorities GetPriorities(string name)
        {
            throw new NotImplementedException();
        }

        public void SavePriorities()
        {
            unitOfWork.Commit();
        }

        public Priorities GetPrioritiesByUserId(string UserId)
        {
            return prioritiesRepository.GetPrioritiesByUserId(UserId);
        }
    }
}
