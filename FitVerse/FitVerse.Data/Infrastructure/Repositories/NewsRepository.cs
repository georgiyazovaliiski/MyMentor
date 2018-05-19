using FitVerse.Data.Infrastructure;
using FitVerse.Data.Infrastructure.Interfaces;
using FitVerse.Data.Infrastructure.IRepositories;
using FitVerse.Model;
using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Data
{
    public class NewsRepository : RepositoryBase<News>, INewsRepository
    {
        public NewsRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public int FindRecent(String link, String UserId, DateTime date)
        {
            var check = DbContext.NewsReadByUsers
                .Where(a => a.HrefAttribute.Equals(link)
                         && a.ReadByUser.Equals(UserId)).Select(a => a.MomentOfReading).FirstOrDefault();
            if (check == null)
                return 0;
            else
            {
                check = check.AddDays(1);
                if (check > date)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
