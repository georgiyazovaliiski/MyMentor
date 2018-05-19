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
    public class ChallengeService : IChallengeService
    {
        private readonly IChallengeRepository challengeRepository;
        private readonly IUnitOfWork unitOfWork;

        public ChallengeService(IChallengeRepository challengeRepository,
                               IUnitOfWork unitOfWork)
        {
            this.challengeRepository = challengeRepository;
            this.unitOfWork = unitOfWork;
        }

        public Challenge CompleteChallenge(int id)
        {
            var c = this.challengeRepository.GetById(id);
            c.Completed = true;
            this.challengeRepository.Update(c);
            this.unitOfWork.Commit();
            return c;
        }

        public void CreateChallenge(Challenge entity)
        {
            this.challengeRepository.Add(entity);
        }

        public Challenge GetChallenge(int id)
        {
            return this.challengeRepository.GetById(id);
        }

        public Challenge GetChallenge(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Challenge> GetChallenges(string name = null)
        {
            if(name != null)
            return this.challengeRepository.GetAll().Where(a => a.Name == name);
            else
            {
                return this.challengeRepository.GetAll();
            }
        }

        public void SaveChallenge()
        {
            unitOfWork.Commit();
        }
    }
}
