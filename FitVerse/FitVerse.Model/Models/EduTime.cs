using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    [Table("EduTimes")]
    public class EduTime:Component
    {
        public EduTime()
        {

        }
        public EduTime(TimeSpan StartTime, TimeSpan EndTime, String Name, int Priority, string EduType) 
            :base(StartTime,EndTime,Name,Priority)
        {
            this.EduType = EduType;
        }

        public string EduType;
    }
}
