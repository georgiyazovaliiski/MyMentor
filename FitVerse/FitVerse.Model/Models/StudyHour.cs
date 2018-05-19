using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    [Table("StudyHours")]
    public class StudyHour:Component
    {
        public StudyHour()
        {

        }
        public StudyHour(TimeSpan StartTime, TimeSpan EndTime, String Name, int Priority, int SubjectId) 
            :base(StartTime,EndTime,Name,Priority)
        {
            this.SubjectId = SubjectId;
        }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }
    }
}
