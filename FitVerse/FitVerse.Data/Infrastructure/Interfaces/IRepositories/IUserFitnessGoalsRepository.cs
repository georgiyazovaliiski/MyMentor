using FitVerse.Data.Infrastructure.Interfaces;
using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Data.Infrastructure.IRepositories
{
    public interface IUserFitnessGoalsRepository : IRepository<UserFitnessGoals>
    {
        UserFitnessGoals GetByUserId(string UserId);
    }
}
