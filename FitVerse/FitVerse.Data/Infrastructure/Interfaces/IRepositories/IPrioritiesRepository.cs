using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Data.Infrastructure.Interfaces.IRepositories
{
    public interface IPrioritiesRepository : IRepository<Priorities>
    {
        Priorities GetPrioritiesByUserId(string UserId);
    }
}
