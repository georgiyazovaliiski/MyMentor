using FitVerse.Model;
using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IEatingComponentService
    {
        IEnumerable<EatingComponent> GetEatingComponents(string name = null);
        ThingToEat GetThingToEat(TypeOfFood TypeOfFood);
        EatingComponent GetEatingComponent(int id);
        EatingComponent GetEatingComponent(string name);
        void CreateEatingComponent(EatingComponent entity);
        void SaveEatingComponent();
    }
}
