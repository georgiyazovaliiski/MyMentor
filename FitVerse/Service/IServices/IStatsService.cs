using FitVerse.Model;
using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IStatsService
    {
        IEnumerable<Stats> GetStatss(string name = null);
        Stats GetStats(int id);
        Stats GetStats(string userId);
        void UpdateStats(int fitIncrement, int socIncrement, int eduIncrement, string UserId);
        void CreateStats(Stats entity);
        void SaveStats();
    }
}
