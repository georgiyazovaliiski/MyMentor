using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    public class Challenge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PointsAward { get; set; }
        public string TypeOfChallenge { get; set; } // Social, Fitness or Educational Challenge
        public string UserId { get; set; }
        public DateTime dateCreated { get; set; }
        public bool Completed { get; set; }

        public Challenge()
        {

        }
        public Challenge(string Name, int PointsAward, string TypeOfChallenge, string UserId)
        {
            this.Name = Name;
            this.PointsAward = PointsAward;
            this.TypeOfChallenge = TypeOfChallenge;
            this.UserId = UserId;
            this.dateCreated = DateTime.Now;
            this.Completed = false;
        }
    }
}
