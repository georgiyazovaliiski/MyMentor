using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    public enum TypeOfComponent
    {
        Workout,
        Eating,
        EduTime,
        FreeTime
    }

    public class ComponentDTO
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime   { get; set; }
        public String   Name      { get; set; }
        public int      Priority  { get; set; }
        public bool     Completed { get; set; }
        public string   EduType   { get; set; }

        public List<EatingComponentDTO> MealPieces { get; set; }
        public WorkoutDTO Workout { get; set; }

        //DETERMINATOR
        public TypeOfComponent DETERMINATOR { get; set; }

        public ComponentDTO()
        {

        }

        public ComponentDTO(Component componentToDraw)
        {
            Id = componentToDraw.Id;
            StartTime = componentToDraw.StartTime;
            EndTime = componentToDraw.EndTime;
            Name = componentToDraw.Name;
            Priority = componentToDraw.Priority;
            Completed = componentToDraw.Completed;
        }
    }
}
