using FitVerse.Model;
using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IChallengeService
    {
        IEnumerable<Challenge> GetChallenges(string name = null);
        Challenge GetChallenge(int id);
        Challenge GetChallenge(string name);
        Challenge CompleteChallenge(int id);
        void CreateChallenge(Challenge entity);
        void SaveChallenge();
    }
}
