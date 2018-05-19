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
using FitVerse.Data.Infrastructure.Interfaces.IRepositories;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository UserRepository,
                               IUnitOfWork unitOfWork)
        {
            this.UserRepository = UserRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateUser(ApplicationUser entity)
        {
            UserRepository.Add(entity);
        }

        public ApplicationUser GetUser(string id)
        {
            return UserRepository.getUserById(id);
        }

        public ApplicationUser GetUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetUsers(string name = null)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(ApplicationUser user)
        {
            UserRepository.Update(user);
        }

        public void SaveUser()
        {
            unitOfWork.Commit();
        }

        public List<Component> getUsersEatings(string id)
        {
            List<Component> usersEatings = new List<Component>();

            var weekDays = UserRepository.getUsersEatings(id).Days;
            

            foreach (var day in weekDays)
            {
                usersEatings.AddRange(day.Components.Where(a =>
                    a.Name.Equals("Breakfast") ||
                    a.Name.Equals("Lunch") ||
                    a.Name.Equals("Dinner") ||
                    a.Name.Equals("Snack")
                    ).ToList());
            }

            return usersEatings;
        }

        public List<Component> getUsersWorkouts(string id)
        {
            List<Component> returning = new List<Component>();
            var UsersWorkouts = UserRepository.getUsersWorkouts(id).Days;
            //throw new Exception("TRENIROVKI: " + UsersWorkouts.Count.ToString());

            foreach (var workoutDay in UsersWorkouts)
            {
                returning.AddRange(workoutDay.Components);
            }

            return returning;
        }
    }
}
