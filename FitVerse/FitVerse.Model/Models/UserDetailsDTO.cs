using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    public class UserDetailsDTO
    {
        public UserDetailsDTO()
        {

        }

        public UserDetailsDTO(
            string FirstName,
            string LastName,
            string Email,
            Priorities Priorities,
            UserFitnessGoals UserFitnessGoals
            )
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Priorities = MatchPriorities(Priorities);
            this.UserFitnessGoals = MatchUserFitnessGoals(UserFitnessGoals);
        }

        private UserFitnessGoalsDTO MatchUserFitnessGoals(UserFitnessGoals userFitnessGoals)
        {
            UserFitnessGoalsDTO UFGDTO = new UserFitnessGoalsDTO(
                userFitnessGoals.MassInKG,
                userFitnessGoals.HeightInCM,
                userFitnessGoals.BodyFat,
                userFitnessGoals.Goal,
                userFitnessGoals.CaloriesForDay,
                userFitnessGoals.ProteinGoalForDay,
                userFitnessGoals.FatGoalForDay,
                userFitnessGoals.CarbsGoalForDay
                );
            return UFGDTO;
        }

        private PrioritiesDTO MatchPriorities(Priorities priorities)
        {
            PrioritiesDTO PDTO = new PrioritiesDTO(
                priorities.educationParam,
                priorities.fitnessParam,
                priorities.socialParam
                );
            return PDTO;
        }

        //Formal Details
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string Email     { get; set; }

        public PrioritiesDTO Priorities { get;set; }

        //Fitness Details
        public UserFitnessGoalsDTO UserFitnessGoals { get; set; }

        //Stats Details ADD LATER
        //public StatsDTO Stats { get; set; }
    }
}
