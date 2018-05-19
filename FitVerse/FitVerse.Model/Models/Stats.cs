using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    public class Stats
    { 

        [Key,ForeignKey("User")]
        public string Id { get; set; }

        public int? EducationStatusLevelId { get; set; }
        public int? SocialStatusLevelId { get; set; }
        public int? FitnessStatusLevelId { get; set; }

        [ForeignKey("EducationStatusLevelId")]
        public virtual StatusLevel EducationStatusLevel { get; set; }
        [ForeignKey("SocialStatusLevelId")]
        public virtual StatusLevel SocialStatusLevel { get; set; }
        [ForeignKey("FitnessStatusLevelId")]
        public virtual StatusLevel FitnessStatusLevel { get; set; }


        public Stats()
        {

        }

        public Stats(StatusLevel fit, StatusLevel soc, StatusLevel edu)
        {
            this.FitnessStatusLevel = fit;
            this.SocialStatusLevel = soc;
            this.EducationStatusLevel = edu;
        }

        public virtual ApplicationUser User { get; set; }
    }
}
