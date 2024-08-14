using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Computing_Project_2024
{
     public class Player
    {
        public string FirstName;
        public string LastName ;
        public float[] StatLine;
       public Player(string firstname , string lastname , float[] Statline)
        {
            FirstName = firstname;
            LastName = lastname;
            StatLine = Statline;
        }

    }

    public class Batter : Player
    {
        // statline (ab,Home_runs,k%,bb%,avg,slg,onbase,ops,woba)
        public Batter(string firstName, string lastName, float[] Statline) : base(firstName, lastName, Statline)
        {

        }
    }

    public class Pitcher : Player
    {
        // statline (pa,k%,bb%,avg,slg,obp,ops,era,woba,whiff%,swing%)
        public Pitcher(string firstName, string lastName, float[] Statline) : base(firstName, lastName, Statline)
        {

        }
    }


    public class Team 
    { 
       

        public string Name;
        public List<int> Batters;
        public List <int> Pitchers;
        public Team(string name, List<int> batters , List<int> pitchers )
        {
            Name = name;  
            Batters = batters;
            Pitchers = pitchers;
        }   
    }
            
}
