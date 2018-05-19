using FitVerse.Model;
using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IWeekService
    {
        Week GetWeekByUserId(string id);
        Week GetWeek(int id);
        void CreateWeek(Week entity);
        void UpdateWeek(Week entity);
        void SaveWeek();
    }
}
