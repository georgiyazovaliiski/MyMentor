using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace FitVerse.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        FitVerseEntities dbContext;

        public FitVerseEntities Init()
        {
            return dbContext ?? (dbContext = new FitVerseEntities());
        }

        protected override void DisposeCore()
        {
            if(dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
