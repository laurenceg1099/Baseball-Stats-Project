using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
       public Player(string data)
        {
            var fields = data.Split(',').Select(x => x.Trim('\"')).ToList();
            string firstname = fields[1];
            string lastname = fields[0];
            int id = int.Parse(fields[2]);
            float[] statline = fields[3..].Select(x => float.Parse(x)).ToArray();
        }

    }

    public class Batter : Player
    {
        // statline (ab,Home_runs,k%,bb%,avg,slg,onbase,ops,woba)
        public Batter(string data) : base(data)
        {

        }
    }

    public class Pitcher : Player
    {
        // statline (pa,k%,bb%,avg,slg,obp,ops,era,woba,whiff%,swing%)
        public Pitcher(string data) : base(data)
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
