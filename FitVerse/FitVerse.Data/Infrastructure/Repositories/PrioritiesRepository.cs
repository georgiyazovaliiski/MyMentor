using FitVerse.Data.Infrastructure.Interfaces.IRepositories;
using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Data.Infrastructure.Repositories
{
    public class PrioritiesRepository : RepositoryBase<Priorities>, IPrioritiesRepository
    {
        public PrioritiesRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public Priorities GetPrioritiesByUserId(string UserId)
        {
            return this.DbContext.Users.Where(a => a.priorities.Id == UserId).Select(a => a.priorities).FirstOrDefault();
        }
    }
}
