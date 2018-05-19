using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IPrioritiesService
    {
        IEnumerable<Priorities> GetCollectivePriorities(string name = null);
        Priorities GetPriorities(int id);
        Priorities GetPriorities(string name);
        Priorities GetPrioritiesByUserId(string UserId);
        void CreatePriorities(Priorities entity);
        void UpdatePriorities(Priorities entity);
        void SavePriorities();
    }
}
