using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model
{
    public class NewsDTO
    {
        public NewsDTO()
        {

        }

        public String Header { get; set; }
        public String ShortDescription { get; set; }
        public String HrefAttribute { get; set; }
        public String PictureAttribute { get; set; }
    }
}
