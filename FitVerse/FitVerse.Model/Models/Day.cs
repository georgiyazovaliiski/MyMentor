using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    public class Day
    {
        public Day()
        {
        }
        public int Id { get; set; }
                
        public string DayInWeek { get; set; }

        public virtual List<Component> Components { get; set; }


        [ForeignKey("Week")]
        [Required]
        public int WeekID { get; set; }
        public Week Week { get; set; }
    }
}
