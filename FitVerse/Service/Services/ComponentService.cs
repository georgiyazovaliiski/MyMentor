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
using System.Reflection;

namespace Service.Services
{
    public class ComponentService : IComponentService
    {
        private readonly IComponentRepository componentRepository;
        private readonly IUnitOfWork unitOfWork;

        public ComponentService(IComponentRepository componentRepository,
                               IUnitOfWork unitOfWork)
        {
            this.componentRepository = componentRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateComponent(Component component)
        {
            componentRepository.Add(component);
        }

        public void CompleteComponent(int id)
        {
            var component = componentRepository.GetById(id);
            component.Completed = true;
            componentRepository.Update(component);
        }

        public Component GetComponent(int id)
        {
            var comp = componentRepository.GetById(id);

            Type t = comp.GetType();
            if(t == typeof(Eating))
            {
                Eating returning = (Eating)comp;
                returning.MealPieces = componentRepository.GetMealPieces(id);
                return returning;
            }
            else if (t == typeof(FitnessTime))
            {
                FitnessTime returning = (FitnessTime)comp;
                return returning;
            }

            return componentRepository.GetById(id);
        }

        public Component GetComponent(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Component> GetComponents(string name = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                return componentRepository.GetAll();
            }
            else
                return componentRepository.GetAll().Where(a => a.Name == name);
        }

        public List<Component> GetComponentsByDayId(int id)
        {
            return componentRepository.getByDayId(id);
        }

        public void UpdateComponents(List<Component> UpdatingComponents)
        {
            foreach (var comp in UpdatingComponents)
            {
                componentRepository.Update(comp);
            }
        }

        public void SaveComponent()
        {
            unitOfWork.Commit();
        }
    }
}
