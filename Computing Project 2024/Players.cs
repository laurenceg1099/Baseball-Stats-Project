using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Computing_Project_2024
{
    public abstract class Player
    {
        public string FirstName;
        public string LastName ;
        public float[] StatLine;
        public int Id;
        public float AbilityScore;
       public Player(string data)
        {
            var fields = data.Split(',').Select(x => x.Trim('\"')).ToList();
            FirstName = fields[1];
            LastName = fields[0];
            Id = int.Parse(fields[2]);
            StatLine = fields[4..].Select(x => float.Parse(x)).ToArray();

        }

        public override string ToString()
        {
            return $"{FirstName},{LastName} ,{Id} ,{StatLine}";
        }

        protected abstract void CalculatetAbilityScore();
     
    }

    public class Batter : Player
    {
        // statline (ab,Home_runs,k%,bb%,avg,slg,onbase,ops,woba)
        public Batter(string data) : base(data)
        {
            CalculatetAbilityScore();
        }

        protected override void CalculatetAbilityScore()
        {
            AbilityScore = StatLine[4];
        }
    }

    public class Pitcher : Player
    {
        // statline (ab,k%,bb%,avg,slg,obp,ops,era,woba,whiff%,swing%)
        public Pitcher(string data) : base(data)
        {
            CalculatetAbilityScore();
        }

        protected override void CalculatetAbilityScore()
        {
            AbilityScore = StatLine[2];
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
