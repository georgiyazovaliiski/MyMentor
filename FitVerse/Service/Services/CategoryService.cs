using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitVerse.Model;
using FitVerse.Data.Infrastructure.Interfaces;
using FitVerse.Data.Infrastructure.IRepositories;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository,
                               IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateCategory(Category category)
        {
            categoryRepository.Add(category);
        }

        public IEnumerable<Category> GetCategories(string name = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                return categoryRepository.GetAll();
            }
            else
                return categoryRepository.GetAll().Where(a => a.Name == name);
        }

        public Category GetCategory(int id)
        {
            var category = categoryRepository.GetById(id);
            return category;
        }

        public Category GetCategory(string name)
        {
            var category = categoryRepository.GetCategoryByName(name);
            return category;
        }

        public void UpdateCategory(Category category)
        {
            this.categoryRepository.Update(category);
        }

        public void SaveCategory()
        {
            unitOfWork.Commit();
        }
    }
}
