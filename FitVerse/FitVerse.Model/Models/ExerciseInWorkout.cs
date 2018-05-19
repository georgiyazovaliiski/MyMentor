using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    public class ExerciseInWorkout
    {
        public int Id { get; set; }

        public int FitnessTimeId { get; set; }

        public int ExerciseId { get; set; }
        [ForeignKey("ExerciseId")]
        public virtual Exercise Exercise { get; set; }

        public int Sets { get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; }

        public ExerciseInWorkout()
        {

        }

        public ExerciseInWorkout(
            int Sets,
            int Reps,
            double Weight,
            Exercise exercise,
            FitnessTime fitnessTime
            )
        {
            this.Sets = Sets;
            this.Reps = Reps;
            this.Weight = Weight;
            this.ExerciseId = exercise.Id;
            this.Exercise = exercise;
            this.FitnessTimeId = fitnessTime.Id;
        }
    }
}
