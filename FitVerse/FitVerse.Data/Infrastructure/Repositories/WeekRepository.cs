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
    public class WeekRepository : RepositoryBase<Week>, IWeekRepository
    {
        public WeekRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public Week GetWeekByUserId(string UserId)
        {
            Week week = this.DbContext.Users.Where(a => a.Id == UserId).Select(a => a.schedule).FirstOrDefault();
            return week;
        }
    }
}
