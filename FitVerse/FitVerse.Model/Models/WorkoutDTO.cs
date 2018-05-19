using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    public class WorkoutDTO
    {
        public WorkoutDTO()
        {
            ExercisesInWorkout = new List<ExerciseInWorkoutDTO>();
        }
        public WorkoutDTO(FitnessTime Workout)
        {
            this.Name = Workout.Name;
            this.ExercisesInWorkout = new List<ExerciseInWorkoutDTO>();
            foreach (var item in Workout.ExerciseInWorkouts)
            {
                ExerciseInWorkoutDTO exercise = new ExerciseInWorkoutDTO(item);
            }
        }
        public String Name { get; set; }
        public List<ExerciseInWorkoutDTO> ExercisesInWorkout { get; set; }
    }
}
