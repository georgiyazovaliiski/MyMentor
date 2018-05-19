using FitVerse.Data.Infrastructure;
using FitVerse.Data.Infrastructure.Interfaces;
using FitVerse.Data.Infrastructure.IRepositories;
using FitVerse.Model;
using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Data

{
    public class EatingComponentRepository : RepositoryBase<EatingComponent>, IEatingComponentRepository
    {
        public EatingComponentRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public ThingToEat PickThingToEat(TypeOfFood TypeOfFood)
        {
            return DbContext.ThingsToEat
                .Where(a => a.TypeOfFood == TypeOfFood)
                .OrderBy(r => Guid.NewGuid())
                .FirstOrDefault();
        }
    }
}
