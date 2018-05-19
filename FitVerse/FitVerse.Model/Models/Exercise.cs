using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    public enum BodyPart
    {
        Chest,
        Back,
        Biceps,
        Triceps,
        Shoulders,
        Abs,
        Legs,
        Gluteus,
        Calves,
        Traps
    }
    public class Exercise
    {
        public Exercise()
        {

        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public BodyPart bodyPart { get; set; }
    }
}
