using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    public class UserFitnessGoals
    {
        public UserFitnessGoals(double MassInKG, double HeightInCM, double BodyFat, string Goal, int CaloriesForDay, int ProteinGoalForDay, int FatGoalForDay, int CarbsGoalForDay)
        {
            this.MassInKG = MassInKG;
            this.HeightInCM = HeightInCM;
            this.BodyFat = BodyFat;
            this.Goal = Goal;
            this.CaloriesForDay = CaloriesForDay;
            this.ProteinGoalForDay = ProteinGoalForDay;
            this.FatGoalForDay = FatGoalForDay;
            this.CarbsGoalForDay = CarbsGoalForDay;
        }
        public UserFitnessGoals()
        {

        }

        [Key,ForeignKey("User")]
        public string Id { get; set; }

        public double MassInKG { get; set; }

        public double HeightInCM { get; set; }

        public double BodyFat { get; set; }

        public string Goal { get; set; }

        public int CaloriesForDay { get; set; }

        public int ProteinGoalForDay { get; set; }

        public int FatGoalForDay { get; set; }

        public int CarbsGoalForDay { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
