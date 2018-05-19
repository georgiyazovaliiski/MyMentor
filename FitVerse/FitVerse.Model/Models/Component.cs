using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    public abstract class Component
    {
        public Component()
        {

        }
        public Component(TimeSpan StartTime, TimeSpan EndTime, String Name, int Priority)
        {
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.Name = Name;
            this.Priority = Priority;
            this.Completed = false;
        }

        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public String Name { get; set; }
        public int Priority { get; set; }
        public bool Completed { get; set; }

        [ForeignKey("Day")]
        [Required]
        public int DayID { get; set; }
        public Day Day{ get; set; }
    }
}
