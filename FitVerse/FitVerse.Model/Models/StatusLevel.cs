using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    public class StatusLevel
    {
        public int Id { get; set; }

        public int Level { get; set; }
        public int Progress { get; set; }
        public int Goal { get; set; }
        
        public StatusLevel()
        {
            Level = 0;
            Progress = 0;
            Goal = 0;
            FinishLevel();
        }

        public void FinishLevel()
        {
            Level++;
            RecalculateGoals();
        }

        public void RecalculateGoals()
        {
            Progress = 0;
            Goal = Level * 10 + Level * 2;
        }
    }
}
