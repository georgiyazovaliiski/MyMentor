using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitVerse;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitVerse.Model.Models
{
    public class Week
    {
        public Week()
        {
            if(Days == null)
            {
                Days = new List<Day>();
            }
        }

        public int Id { get; set; }
                
        public virtual List<Day> Days { get; set; }

    }
}
