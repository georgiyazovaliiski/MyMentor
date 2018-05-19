using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitVerse.Model;
using FitVerse.Data.Infrastructure.IRepositories;
using FitVerse.Data.Infrastructure.Interfaces;

namespace Service.Services
{
    public class GadgetService : IGadgetService
    {
        private readonly IGadgetRepository gadgetsRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public GadgetService(IGadgetRepository gadgetsRepository, 
                             ICategoryRepository categoryRepository,
                             IUnitOfWork unitOfWork)
        {
            this.gadgetsRepository = gadgetsRepository;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IGadgetService Members
        public void CreateGadget(Gadget gadget)
        {
            gadgetsRepository.Add(gadget);
        }

        public IEnumerable<Gadget> GetCategoryGadgets(string categoryName, string gadgetName = null)
        {
            var category = categoryRepository.GetCategoryByName(categoryName);
            var gadgets = category.Gadgets.Where(g => g.Name.ToLower().Contains(gadgetName.ToLower().Trim()));
            return gadgets;
        }

        public Gadget GetGadget(int id)
        {
            var gadget = gadgetsRepository.GetById(id);
            return gadget;
        }

        public IEnumerable<Gadget> GetGadgets()
        {
            var gadgets = gadgetsRepository.GetAll();
            return gadgets;
        }

        public void SaveGadget()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
