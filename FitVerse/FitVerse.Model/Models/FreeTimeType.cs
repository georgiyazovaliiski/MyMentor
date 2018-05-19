using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    public class FreeTimeType
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public ICollection<FreeTime> FreeTimes { get; set; }
    }
}
