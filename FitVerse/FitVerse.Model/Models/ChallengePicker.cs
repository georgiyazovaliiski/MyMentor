using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FitVerse.Model.Models
{
    public class ChallengePicker
    {
        public string[] ChallengeNames { get; set; }
        public int[] Rewards {get;set;}

        public ChallengePicker()
        {
            this.ChallengeNames = new string[] {
                "Избери си книга за четене-Education",
                "Прочети 1 нова статия-Education",
                "Гледай емисия новини-Education",
                "Сготви любимото си ястие-Education",
                "Тичай 10 минути-Fitness",
                "Излез с приятели-Social",
                "Свържи се с приятел, който не си виждал отдавна-Social",
                "Направи 3 комплимента на различни хора-Social",
                "Направи 2 комплимента на различни хора-Social",
                "Направи 4 комплимента на различни хора-Social",
                "Направи 7 комплимента на различни хора-Social",
                "Тичай 20 минути-Fitness",
                "Скачай на въже-Fitness",
                "Карай колело-Fitness"
            };
            this.Rewards = new int[] { 1,2,3,4,5 };
        }

        public string PickAChallenge()
        {
            Random rnd1 = new Random();
            Random rnd2 = new Random();
            string challengeName = this.ChallengeNames[rnd1.Next(0, this.ChallengeNames.Length)];
            int reward = this.Rewards[rnd2.Next(0, this.Rewards.Length)];
            string finalAssignment = $"{challengeName}-{reward}";
            return finalAssignment;
        }
    }
}
