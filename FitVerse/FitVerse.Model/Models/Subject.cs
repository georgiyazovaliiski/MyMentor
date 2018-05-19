using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public ICollection<StudyHour> StudyHours { get; set; }
    }
}
