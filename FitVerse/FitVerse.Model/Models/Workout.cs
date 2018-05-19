using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    public class Workout
    {
        public Workout()
        {
            this.ExerciseInWorkouts = new List<ExerciseInWorkout>();
        }

        public Workout(string Name, WorkoutType workoutType)
        {
            this.Name = Name;
            this.WorkoutType = WorkoutType;
            this.ExerciseInWorkouts = new List<ExerciseInWorkout>();
        }

        [ForeignKey("FitnessTime")]
        public int Id { get; set; }
        public String Name { get; set; }

        public WorkoutType WorkoutType { get; set; }
        
        
        public virtual FitnessTime FitnessTime { get; set; }

        public ICollection<ExerciseInWorkout> ExerciseInWorkouts { get; set; }
    }
}
