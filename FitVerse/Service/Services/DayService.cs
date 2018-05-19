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
    public class DayService : IDayService
    {
        private readonly IDayRepository dayRepository;
        private readonly IUnitOfWork unitOfWork;

        public DayService(IDayRepository dayRepository,
                               IUnitOfWork unitOfWork)
        {
            this.dayRepository = dayRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateDay(Day Day)
        {
            dayRepository.Add(Day);
        }

        public Day GetDay(int id)
        {
            return dayRepository.GetById(id);
        }

        public Day GetDay(string name)
        {
            throw new NotImplementedException();
        }

        public List<Day> GetDaysByWeekId(int id)
        {
            return dayRepository.getByWeekId(id);
        }

        public IEnumerable<Day> GetDays(string name = null)
        {
            throw new NotImplementedException();
        }

        public void UpdateDayById(Day entity)
        {
            this.dayRepository.Update(entity);
        }

        public void SaveDay()
        {
            unitOfWork.Commit();
        }
    }
}
