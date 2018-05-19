using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitVerse.Model.Models
{
    public class Priorities
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        private int EducationParam;
        private int FitnessParam;
        private int SocialParam;

        public int socialParam
        {
            get { return SocialParam; }
            set { SocialParam = value; }
        }

        public int fitnessParam
        {
            get { return FitnessParam; }
            set { FitnessParam = value; }
        }

        public int educationParam
        {
            get { return EducationParam; }
            set { EducationParam = value; }
        }

        public Priorities()
        {
            educationParam = 0;
            fitnessParam = 0;
            socialParam = 0;
        }

        public Priorities(int EducationProp, int FitnessProp, int SocialProp)
        {
            educationParam = EducationParam;
            fitnessParam = FitnessProp;
            socialParam = SocialProp;
        }

        public virtual ApplicationUser User { get; set; }
    }
}