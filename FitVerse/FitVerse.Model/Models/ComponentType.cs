using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    public class ComponentType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Component> Components { get; set; }
    }
}
