using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    public class Programs
    {
        public string[] programForMorningSchool { get; set; }
        public string[] programForEveningSchool { get; set; }
        public string[] programForNoSchool { get; set; }
        public Programs()
        {
            programForMorningSchool = new string[]
            {
                "Breakfast-7:00-8:00", // Eating Generator
                "School-8:00-13:30",
                "Lunch-14:00-14:30", // Eating Generator
                "SecondPriority-14:40-16:00", // Fitness/Education Generator
                "FreeTime-16:00-16:30",
                "ThirdPriority-16:30-17:30", // Fitness/Education Generator
                "Snack-17:30-17:45", // Eating Generator
                "FirstPriority-17:45-18:00",
                "StudyTime-18:00-19:30",
                "Dinner-19:30-20:00", // Eating Generator
                "FreeTime-20:00-01:00"
            };
            programForEveningSchool = new string[]
            {
                "Breakfast-7:45-8:00",
                "FirstPriority-8:00-9:30",
                "FreeTime-9:30-10:00",
                "StudyTime-10:00-12:00",
                "FreeTime-12:00-12:30",
                "Lunch-12:30-13:00",
                "School-13:00-19:30",
                "Dinner-20:00-20:30",
                "GamesAndSocialLife-20:30-01:00"
            };
            programForNoSchool = new string[]
            {

            };
        }
    }
}
