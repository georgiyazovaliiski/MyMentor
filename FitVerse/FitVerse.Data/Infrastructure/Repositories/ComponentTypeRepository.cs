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
    public class ComponentTypeRepository : RepositoryBase<ComponentType>, IComponentTypeRepository
    {
        public ComponentTypeRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
