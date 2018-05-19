using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IUserService
    {
        IEnumerable<ApplicationUser> GetUsers(string name = null);
        ApplicationUser GetUser(string id);
        ApplicationUser GetUserByName(string name);
        List<Component> getUsersEatings(string id);
        List<Component> getUsersWorkouts(string id);
        void CreateUser(ApplicationUser entity);
        void UpdateUser(ApplicationUser user);
        void SaveUser();
    }
}
