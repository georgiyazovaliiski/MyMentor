using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitVerse.Model;
using FitVerse.Data.Infrastructure.Interfaces;
using FitVerse.Data.Infrastructure.IRepositories;
using FitVerse.Model.Models;

namespace Service.Services
{
    public class UserFitnessGoalsService : IUserFitnessGoalsService
    {
        private readonly IUserFitnessGoalsRepository userFitnessGoalsRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserFitnessGoalsService(IUserFitnessGoalsRepository userFitnessGoalsRepository, IUnitOfWork unitOfWork)
        {
            this.userFitnessGoalsRepository = userFitnessGoalsRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateUserFitnessGoals(UserFitnessGoals entity)
        {
            this.userFitnessGoalsRepository.Add(entity);
        }

        public UserFitnessGoals GetUserFitnessGoals(int id)
        {
            return this.userFitnessGoalsRepository.GetById(id);
        }

        public UserFitnessGoals GetUserFitnessGoals(string name)
        {
            throw new NotImplementedException();
        }

        public UserFitnessGoals GetUserFitnessGoalsByUserId(string UserId)
        {
            return this.userFitnessGoalsRepository.GetByUserId(UserId);
        }

        public IEnumerable<UserFitnessGoals> GetUserFitnessGoalsList(string name = null)
        {
            throw new NotImplementedException();
        }

        public void SaveUserFitnessGoals()
        {
            this.unitOfWork.Commit();
        }
    }
}
