using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    public class EnglishToBGParser
    {
        public EnglishToBGParser()
        {

        }

        public string ParseLanguages(string ParseItem)
        {
            if (ParseItem.Equals("StudyTime"))
            {
                return "Домашно";
            }
            else if (ParseItem.Equals("Breakfast"))
            {
                return "Закуска";
            }
            else if (ParseItem.Equals("FreeTime"))
            {
                return "Безгрижие";
            }
            else if (ParseItem.Equals("FirstPriority"))
            {
                return "Главна задача";
            }
            else if (ParseItem.Equals("SecondPriority"))
            {
                return "Втора задача";
            }
            else if (ParseItem.Equals("ThirdPriority"))
            {
                return "Трета задача";
            }
            else if (ParseItem.Equals("Lunch"))
            {
                return "Обяд";
            }
            else if (ParseItem.Equals("School"))
            {
                return "Училище";
            }
            else if (ParseItem.Equals("Snack"))
            {
                return "Малка закуска";
            }
            else if (ParseItem.Equals("Dinner"))
            {
                return "Вечеря";
            }
            return "";
        }
    }
}
