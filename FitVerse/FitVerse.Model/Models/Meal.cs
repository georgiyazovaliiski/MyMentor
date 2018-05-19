using FitVerse.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Eating> Eatings { get; set; }
    }
}
