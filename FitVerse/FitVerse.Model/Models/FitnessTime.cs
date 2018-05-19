using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    public enum WorkoutType
    {
        FullBody,
        Upper,
        Lower
    }
    [Table("FitnessTimes")]
    public class FitnessTime:Component
    {
        public FitnessTime()
        {
        }
        public FitnessTime(TimeSpan StartTime, TimeSpan EndTime, String Name, int Priority, List<ExerciseInWorkout> exercises ) :base(StartTime,EndTime,Name,Priority)
        {
            this.WorkoutType = WorkoutType.FullBody;
            this.ExerciseInWorkouts = exercises;
        }
        
        public ICollection<ExerciseInWorkout> ExerciseInWorkouts { get; set; }

        public WorkoutType WorkoutType { get; set; }
    }
}
