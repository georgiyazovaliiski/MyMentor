using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitVerse.Model.Models
{
    public class EatingComponent
    {
        public int Id { get; set; }
        public int PortionMassInGrams { get; set; }

        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Carbs { get; set; }
        public double Calories { get; set; }

        public int EatingId { get; set; }
        [ForeignKey("EatingId")]
        public virtual Eating Eating { get; set; }  // BELONGS TO CERTAIN MEAL TO EAT

        [ForeignKey("Food")]    // Actual Food Generic Item
        public int FoodId { get; set; }
        public virtual ThingToEat Food { get; set; }

        public EatingComponent()
        {

        }

        public EatingComponent(int portionMassInGrams, ThingToEat product)  // ThingToEat is being taken from DB
        {
            Food = product;
            FoodId = product.Id;
            CalculateNutrients(portionMassInGrams, product);
        }

        private void CalculateNutrients(int portionMassInGrams, ThingToEat product)
        {
            this.PortionMassInGrams = portionMassInGrams;
            this.Protein = portionMassInGrams * product.Protein / 100;
            this.Fat = portionMassInGrams * product.Fat / 100;
            this.Carbs = portionMassInGrams * product.Carbs / 100;
            this.Calories = Protein * 4 + Fat * 9 + Carbs * 4;
        }
    }
}