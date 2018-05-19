using FitVerse.Model;
using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface INewsService
    {
        IEnumerable<News> GetNewss(string name = null);
        News GetNews(int id);
        News GetNews(string name);
        bool FindIfNewsHadBeenReadRecently(News entity);
        void CreateNews(News entity);
        void SaveNews();
    }
}
