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
    public class NewsService : INewsService
    {
        private readonly INewsRepository NewsRepository;
        private readonly IUnitOfWork unitOfWork;

        public NewsService(INewsRepository NewsRepository,
                               IUnitOfWork unitOfWork)
        {
            this.NewsRepository = NewsRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateNews(News News)
        {
            NewsRepository.Add(News);
        }

        public bool FindIfNewsHadBeenReadRecently(News entity)
        {
            if(NewsRepository.FindRecent(entity.HrefAttribute, entity.ReadByUser, entity.MomentOfReading) > 0)
                return true;
            else
            {
                return false;
            }
        }

        public News GetNews(int id)
        {
            return NewsRepository.GetById(id);
        }

        public News GetNews(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<News> GetNewss(string name = null)
        {
            throw new NotImplementedException();
        }

        public void SaveNews()
        {
            unitOfWork.Commit();
        }
    }
}
