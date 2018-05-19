using FitVerse.Model;
using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IComponentService
    {
        IEnumerable<Component> GetComponents(string name = null);
        Component GetComponent(int id);
        Component GetComponent(string name);
        List<Component> GetComponentsByDayId(int id);
        void UpdateComponents(List<Component> UpdatingComponents);
        void CompleteComponent(int id);
        void CreateComponent(Component entity);
        void SaveComponent();
    }
}
