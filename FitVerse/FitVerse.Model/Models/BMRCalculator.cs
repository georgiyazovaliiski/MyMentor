using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitVerse.Model.Models
{
    public class BMRCalculator
    {
        public BMRCalculator()
        {

        }

        public double Calculate(Gender Gender, double Weight, double Height, int Age)
        {
            double BMR = 0;
            if (Gender.Equals(Gender.Male))
            {
                BMR = 66 + (13.7 * Weight) + (5 * Height) - (6.8 * Age);
            }
            else if(Gender.Equals(Gender.Female))
            {
                BMR = 655 + (9.6 * Weight) + (1.8 * Height) - (4.7 * Age);
            }
            return BMR;
        }
    }
}
