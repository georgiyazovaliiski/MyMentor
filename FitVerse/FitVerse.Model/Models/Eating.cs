using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    [Table("Eatings")]
    public class Eating:Component
    {
        public Eating()
        {

        }
        public Eating(TimeSpan StartTime, TimeSpan EndTime, String Name, int Priority, List<EatingComponent> MealPieces) :base(StartTime,EndTime,Name,Priority)
        {
            /*this.MealId = MealId;*/
            this.MealPieces = MealPieces;
        }
        /*[ForeignKey("Meal")]
        public int MealId { get; set; }

        public Meal Meal { get; set; }*/

        public List<EatingComponent> MealPieces { get; set; }
    }
}
