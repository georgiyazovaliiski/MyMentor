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
    public class StatsService : IStatsService
    {
        private readonly IStatsRepository statsRepository;
        private readonly IStatusLevelRepository statusLevelRepository;
        private readonly IUnitOfWork unitOfWork;

        public StatsService(IStatsRepository statsRepository,
                            IStatusLevelRepository statusLevelRepository,
                               IUnitOfWork unitOfWork)
        {
            this.statusLevelRepository = statusLevelRepository;
            this.statsRepository = statsRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateStats(Stats entity)
        {
            this.statsRepository.Add(entity);
        }

        public Stats GetStats(int id)
        {
            return this.statsRepository.GetById(id);
        }

        public Stats GetStats(string userId)
        {
            return this.statsRepository.GetByUserId(userId);
        }

        public IEnumerable<Stats> GetStatss(string name = null)
        {
            throw new NotImplementedException();
        }

        public void UpdateStats(int fitIncrement, int socIncrement, int eduIncrement, string UserId)
        {
            var stats = this.statsRepository.GetByUserId(UserId);

            var statsLevels = new List<StatusLevel>();

            statsLevels.Add(this.statusLevelRepository.GetById(int.Parse(stats.EducationStatusLevelId.ToString())));
            statsLevels.Add(this.statusLevelRepository.GetById(int.Parse(stats.SocialStatusLevelId.ToString())));
            statsLevels.Add(this.statusLevelRepository.GetById(int.Parse(stats.FitnessStatusLevelId.ToString())));

            stats.EducationStatusLevel.Progress += eduIncrement;
            stats.SocialStatusLevel.Progress += socIncrement;
            stats.FitnessStatusLevel.Progress += fitIncrement;

            if (stats.EducationStatusLevel.Goal < stats.EducationStatusLevel.Progress)
            {
                stats.EducationStatusLevel.FinishLevel();
            }
            if (stats.FitnessStatusLevel.Goal < stats.FitnessStatusLevel.Progress)
            {
                stats.FitnessStatusLevel.FinishLevel();
            }
            if (stats.SocialStatusLevel.Goal < stats.SocialStatusLevel.Progress)
            {
                stats.SocialStatusLevel.FinishLevel();
            }
            this.statsRepository.Update(stats);
        }

        public void SaveStats()
        {
            unitOfWork.Commit();
        }
    }
}
