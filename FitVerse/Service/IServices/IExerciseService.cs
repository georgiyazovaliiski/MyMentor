using FitVerse.Model;
using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IExerciseService
    {
        IEnumerable<Exercise> GetExercises(string name = null);
        Exercise GetExercise(int id);
        Exercise GetExercise(string name);
        Exercise GetRandomExercise(BodyPart targetPart);
        void CreateExercise(Exercise entity);
        void SaveExercise();
    }
}
