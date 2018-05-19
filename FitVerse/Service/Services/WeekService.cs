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
    public class WeekService : IWeekService
    {
        private readonly IWeekRepository weekRepository;
        private readonly IUnitOfWork unitOfWork;

        public WeekService(IWeekRepository weekRepository,
                               IUnitOfWork unitOfWork)
        {
            this.weekRepository = weekRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateWeek(Week week)
        {
            weekRepository.Add(week);
        }

        public Week GetWeek(int id)
        {
            var week = weekRepository.GetById(id);
            return week;
        }

        public void DeleteWeekByUser(int id)
        {
            weekRepository.Delete(weekRepository.GetById(id));
        }

        public Week GetWeekByUserId(string id)
        {
            return weekRepository.GetWeekByUserId(id);
        }

        public void UpdateWeek(Week entity)
        {
            weekRepository.Update(entity);
        }

        public void SaveWeek()
        {
            unitOfWork.Commit();
        }
    }
}
