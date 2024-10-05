
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
            var kx = 1.0;
            if (strikes > balls) 
            {
                kx = 1.5;
            }

            else if (strikes < balls)
            {
                kx = 0.5;
            }
            var choice = new Random().NextDouble();

            if  (choice < 0.15)
            {
                return 'b';
            }

            if (choice < 0.6 * kx)
            {
                return 'k';
            }


            else
            {
                var choice2 = new Random().NextDouble();
                if (choice2 < 0.67) return '1';
                if (choice2 < 0.9) return '2';
                if (choice2 < 0.95) return '3';
                else return '4';
            }
            
           
        }


    }
}
