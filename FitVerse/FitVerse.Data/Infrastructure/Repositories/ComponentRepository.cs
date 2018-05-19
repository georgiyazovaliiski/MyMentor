using FitVerse.Data.Infrastructure;
using FitVerse.Data.Infrastructure.Interfaces;
using FitVerse.Data.Infrastructure.IRepositories;
using FitVerse.Model;
using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Data
{
    public class ComponentRepository : RepositoryBase<Component>, IComponentRepository
    {
        public ComponentRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public Component completeComponent(Component component)
        {
            component.Completed = true;
            return component;
        }

        public List<Component> getByDayId(int id)
        {
            return this.DbContext.Components.Where(a=>a.DayID == id).ToList();
        }

        public List<EatingComponent> GetMealPieces(int id)
        {
            return this.DbContext.EatingComponents.Include(g=>g.Food).Where(a=>a.EatingId == id).ToList();
        }

        public FitnessTime GetWorkout(int id)
        {
            return this.DbContext.FitnessTimes.Include(g => g.ExerciseInWorkouts.Select(e=>e.Exercise)).Where(a => a.Id == id).FirstOrDefault();
        }

        /*public override Component GetById(int id)
        {
            try
            {
                var comp = this.DbContext.Components.Include("MealPieces").FirstOrDefault(a => a.Id == id);
                return comp;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }*/
    }
}
