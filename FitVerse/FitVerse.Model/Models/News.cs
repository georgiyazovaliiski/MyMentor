using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model
{
    public class News
    {
        public News()
        {

        }
        public int Id { get; set; }
        
        public String HrefAttribute { get; set; }
        public DateTime MomentOfReading { get; set; }

        [ForeignKey("User")]
        public string ReadByUser { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
