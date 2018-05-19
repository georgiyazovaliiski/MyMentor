using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitVerse.Model.Models
{
    public enum TypeOfFood
    {
        Meat,
        Vegetable,
        Fruit,
        Dairy
    }
    public class ThingToEat
    {
        public ThingToEat()
        {

        }

        public ThingToEat(string Name, double Calories, double Protein, double Fat, double Carbs)
        {
            this.Name = Name;
            this.Calories = Calories;
            this.Protein = Protein;
            this.Fat = Fat;
            this.Carbs = Carbs;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Carbs { get; set; }
        public TypeOfFood TypeOfFood { get; set; }
    }
}