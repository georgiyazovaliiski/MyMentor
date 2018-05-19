using System;

namespace FitVerse.Model.Models
{
    public class ExerciseInWorkoutDTO
    {
        public ExerciseInWorkoutDTO()
        {

        }

        public ExerciseInWorkoutDTO(ExerciseInWorkout exercise)
        {
            this.Sets = exercise.Sets;
            this.Reps = exercise.Reps;
            this.Weight = exercise.Weight;
            mapExercise(exercise);
        }

        private void mapExercise(ExerciseInWorkout exercise)
        {
            this.Exercise.Name = exercise.Exercise.Name;
            this.Exercise.Description = exercise.Exercise.Description;
            this.Exercise.BodyPartName = exercise.Exercise.bodyPart.ToString();
        }

        public int Sets { get; set; }

        public int Reps { get; set; }

        public double Weight { get; set; }

        ExerciseDTO Exercise { get; set; }
    }
}