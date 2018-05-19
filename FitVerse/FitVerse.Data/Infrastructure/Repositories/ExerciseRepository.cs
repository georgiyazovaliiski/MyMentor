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
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public Exercise GetRandomExercise(BodyPart BodyPart)
        {
            return this.DbContext.Exercises
                 .Where(a => a.bodyPart == BodyPart)
                 .OrderBy(r => Guid.NewGuid())
                 .FirstOrDefault();
        }
    }
}
