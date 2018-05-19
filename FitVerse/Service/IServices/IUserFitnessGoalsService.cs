using FitVerse.Model;
using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IUserFitnessGoalsService
    {
        IEnumerable<UserFitnessGoals> GetUserFitnessGoalsList(string name = null);
        UserFitnessGoals GetUserFitnessGoals(int id);
        UserFitnessGoals GetUserFitnessGoalsByUserId(string UserId);
        UserFitnessGoals GetUserFitnessGoals(string name);
        void CreateUserFitnessGoals(UserFitnessGoals entity);
        void SaveUserFitnessGoals();
    }
}
