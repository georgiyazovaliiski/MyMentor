using FitVerse.Data.Infrastructure;
using FitVerse.Data.Infrastructure.Interfaces;
using FitVerse.Data.Infrastructure.Interfaces.IRepositories;
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
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public ApplicationUser getUserById(string UserId)
        {
            return this.DbContext.Users
                .Include(a => a.stats)
                .Include(a => a.priorities)
                .Include(a => a.userFitnessGoals)
                .Where(a => a.Id.Equals(UserId))
                .Select(a => a)
                .FirstOrDefault();
        }

        public Week getUsersEatings(string UserId)
        {
            return this.DbContext.Users
                .Include(a => a.schedule.Days.Select(b=>b.Components))
                .Where(a => a.Id.Equals(UserId))
                .Select(a => a)
                .FirstOrDefault().schedule;
        }

        public Week getUsersWorkouts(string UserId)
        {
            var compo = this.DbContext.Users
                   .Include(a => a.schedule.Days.Select(b => b.Components))
                   .Where(a => a.Id.Equals(UserId))
                   .Select(a => a)
                   .FirstOrDefault().schedule;
            foreach (var item in compo.Days)
            {
                item.Components = item.Components.Where(a => a is FitnessTime).ToList();
            }

            return compo;
        }
    }
}
