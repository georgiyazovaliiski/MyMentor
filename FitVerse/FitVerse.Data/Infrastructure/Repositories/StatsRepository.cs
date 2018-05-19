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
    public class StatsRepository : RepositoryBase<Stats>, IStatsRepository
    {
        public StatsRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public Stats GetByUserId(string UserId)
        {
            return this.DbContext.Stats.Find(UserId);
        }
    }
}
