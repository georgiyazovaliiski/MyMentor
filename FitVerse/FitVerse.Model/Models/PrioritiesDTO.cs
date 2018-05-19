namespace FitVerse.Model.Models
{
    public class PrioritiesDTO
    {
        public PrioritiesDTO()
        {

        }
        public PrioritiesDTO(int EducationParam, int FitnessParam, int SocialParam)
        {
            this.EducationParam = EducationParam;
            this.FitnessParam = FitnessParam;
            this.SocialParam = SocialParam;
        }

        public int EducationParam { get; set; }
        public int FitnessParam { get; set; }
        public int SocialParam { get; set; }
    }
}