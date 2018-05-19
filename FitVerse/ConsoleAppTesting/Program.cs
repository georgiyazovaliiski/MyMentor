using FitVerse.Data;
using FitVerse.Data.Infrastructure;
using FitVerse.Web.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.IServices;
using Service.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTesting
{
   public class Program
    {
        public static void Main(string[] args)
        {
            DbFactory dbFactory = new DbFactory();
            dbFactory.Init();
            UnitOfWork unitOfWork = new UnitOfWork(dbFactory);

            CategoryRepository categoryRepository = new CategoryRepository(dbFactory);
            GadgetRepository gadgetRepository = new GadgetRepository(dbFactory);

            CategoryService categoryService = new CategoryService(categoryRepository,unitOfWork);
            GadgetService gadgetService = new GadgetService(gadgetRepository,categoryRepository,unitOfWork);
            

            Console.WriteLine(categoryService.GetCategories().Count());
        }
    }
}
