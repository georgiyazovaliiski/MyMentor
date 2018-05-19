using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    [Table("FreeTimes")]
    public class FreeTime:Component
    {
        public FreeTime()
        {

        }
        public FreeTime(TimeSpan StartTime, TimeSpan EndTime, String Name, int Priority) 
            :base(StartTime,EndTime,Name,Priority)
        {
        }
    }
}
