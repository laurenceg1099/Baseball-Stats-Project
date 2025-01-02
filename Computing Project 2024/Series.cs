using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computing_Project_2024
{
     class Series
    {
        public Team Hometeam;
        public Team Awayteam;
        public int _Games;
        
        public Series(Team hometeam , Team awayteam , int games) 
        {
           Hometeam = hometeam;
           Awayteam = awayteam;
           _Games = games;
        }



    }
}
