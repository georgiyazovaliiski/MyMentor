namespace FitVerse.Model.Models
{
    public class EatingComponentDTO
    {
        public EatingComponentDTO()
        {

        }

        public EatingComponentDTO(
            int PortionMassInGrams,
            string Name           ,
            double Protein        ,
            double Fat            ,
            double Carbs          ,
            double Calories
            )
        {
            this.PortionMassInGrams = PortionMassInGrams;
            this.Name = Name;
            this.Protein = Protein;
            this.Fat = Fat;
            this.Carbs = Carbs;
            this.Calories = Calories;
        }

        public int PortionMassInGrams { get; set; }
        public string Name              { get; set; }
        public double Protein            { get; set; }
        public double Fat                       { get; set; }
        public double Carbs              { get; set; }
        public double Calories          { get; set; }
    }
}