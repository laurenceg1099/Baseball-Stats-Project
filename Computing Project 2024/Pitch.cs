
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Computing_Project_2024
{
    public static class Pitch
    {
        
        public static char Pitchball(int strikes, int balls , Player pitcher , Player batter) //returns k,b,1,2,3,4
        {
            var random = new  Random();

            double pKPercent = pitcher.StatLine[1] / 100.0;
            double pBBPercent = pitcher.StatLine[2] / 100.0;
            double PAvg = pitcher.StatLine[3];
            double bKPercent = batter.StatLine[2] / 100.0;
            double bAvg = batter.StatLine[4];

            var strikechance = 0.45 + ((pKPercent + bKPercent)/2 + 0.05 * strikes);
            var ballchance = 0.20 + (pBBPercent - 0.05 * balls);
            var hitchance = 0.33*(bAvg + PAvg)/2;

            var total = strikechance + ballchance + hitchance;
            strikechance /= total;
            ballchance /= total;
            hitchance /= total;

            var rand = random.NextDouble();

            if (rand < strikechance)
            {
                return 'k';
            }

            if (rand < ballchance+strikechance) 
            {
                return 'b';
            }

            else
            {
                return HitOutcome(bAvg);
            }

        }

        private static char HitOutcome(double bAvg)
        {
            var random = new Random();
            double randValue = random.NextDouble();

            double singleWeight = 0.5 + bAvg * 0.3; 
            double doubleWeight = 0.20 + bAvg * 0.2;
            double tripleWeight = 0.05 + bAvg * 0.1; 
            double homeRunWeight = 0.05 + bAvg * 0.2;
            double totalWeight = singleWeight + doubleWeight + tripleWeight + homeRunWeight;
            
            
            if (randValue < (singleWeight / totalWeight))
                return '1'; 
            if (randValue < (singleWeight + doubleWeight) / totalWeight)
                return '2'; 
            if (randValue < (singleWeight + doubleWeight + tripleWeight) / totalWeight)
                return '3'; 
            return '4';  

        }


    }
}
