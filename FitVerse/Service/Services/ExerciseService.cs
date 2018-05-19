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
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository ExerciseRepository;
        private readonly IUnitOfWork unitOfWork;

        public ExerciseService(IExerciseRepository ExerciseRepository,
                               IUnitOfWork unitOfWork)
        {
            this.ExerciseRepository = ExerciseRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateExercise(Exercise Exercise)
        {
            this.ExerciseRepository.Add(Exercise);
        }

        public Exercise GetExercise(int id)
        {
            return this.ExerciseRepository.GetById(id);
        }

        public Exercise GetExercise(string name)
        {
            throw new NotImplementedException();
        }

        public Exercise GetRandomExercise(BodyPart targetPart)
        {
            return ExerciseRepository.GetRandomExercise(targetPart);
        }

        public IEnumerable<Exercise> GetExercises(string name = null)
        {
            throw new NotImplementedException();
        }

        public void SaveExercise()
        {
            unitOfWork.Commit();
        }
    }
}
