using FitVerse.Model;
using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IDayService
    {
        IEnumerable<Day> GetDays(string name = null);
        Day GetDay(int id);
        Day GetDay(string name);
        List<Day> GetDaysByWeekId(int id);
        void CreateDay(Day entity);
        void UpdateDayById(Day entity);
        void SaveDay();
    }
}
