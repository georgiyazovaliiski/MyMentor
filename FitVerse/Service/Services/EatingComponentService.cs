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

namespace Service.Services
{
    public class EatingComponentService : IEatingComponentService
    {
        private readonly IEatingComponentRepository EatingComponentRepository;
        private readonly IUnitOfWork unitOfWork;

        public EatingComponentService(IEatingComponentRepository EatingComponentRepository,
                               IUnitOfWork unitOfWork)
        {
            this.EatingComponentRepository = EatingComponentRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateEatingComponent(EatingComponent EatingComponent)
        {
            throw new NotImplementedException();
        }

        public EatingComponent GetEatingComponent(int id)
        {
            throw new NotImplementedException();
        }

        public EatingComponent GetEatingComponent(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EatingComponent> GetEatingComponents(string name = null)
        {
            throw new NotImplementedException();
        }

        public ThingToEat GetThingToEat(TypeOfFood TypeOfFood)
        {
            return EatingComponentRepository.PickThingToEat(TypeOfFood);
        }

        public void SaveEatingComponent()
        {
            throw new NotImplementedException();
        }
    }
}
