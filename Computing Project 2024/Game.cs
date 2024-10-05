using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Computing_Project_2024
{
    public  class Game
    {

        public Team HomeTeam;
        public Team AwayTeam;

        private int HomeScore;
        private int AwayScore;

        public Game(Team hometeam,Team awayteam,int length) 
        {
            Bases.IncreaseScore += Bases_IncreaseScore;
            //change team lineups 
            for (int i = 0; i < length; i++)
            {
               var currentinning = new Inning(hometeam,awayteam);
            }

            if (HomeScore == AwayScore)
            {
                //do extra innings
            }

            Bases.IncreaseScore -= Bases_IncreaseScore;
        }

        private void Bases_IncreaseScore(Team obj)
        {
            if (obj == HomeTeam) HomeScore++;
            else if(obj == AwayTeam) AwayScore++;
        }

    }

    public class Inning
    {
        
        private int outs = 0;

        public Inning(Team home, Team away)
        {
            DoInning(away,home,new Bases(away));
            DoInning(home,away,new Bases(home));    
        }

        private void DoInning(Team batting, Team pitching,Bases bases)
        {
           
            outs = 0;
            while (outs < 3)
            {
                //bases.SetAtPlate = batting.nextbatter();
                //int result = AtBat.New(bases.GetAtPlate, pitching.pitcher);
                int result = 0;
                switch (result)
                {
                    case 0: outs++; bases.SetAtPlate(null); break;
                    case -1: bases.walk(0); break;
                    default: bases.advanceRunners(result); break;
                }
            }

        }


        public void Addout() { outs++; }
    }

    public static class AtBat
    {
        public static int New(Batter batter, Pitcher pitcher)
        {
            var balls = 0;
            var strikes = 0;
            var hit = false;
            while (strikes < 3 && hit == false && balls < 4)
            {
                //var outcome = Pitchball(strikes, balls, batter, pitcher);
                var outcome = "k";
                switch (outcome) //k,b,1,2,3,4
                {
                    case "k": strikes++; break;
                    case "B": balls++; break;
                    default: return int.Parse(outcome); break;
                }
            }

            if (strikes == 3) return 0;
            if(balls == 4) return -1;

            throw new Exception("unexpected outcome");
                
        }  
    }


    public class Bases
    {
        public static event Action<Team> IncreaseScore; 

        private Player[] bases = new Player[4];

        //[1,2,3]
        private Team team;
        public Bases(Team team)
        {
            this.team = team;
        }
        
        public void advanceRunners(int hits)
        {
            Player[] nextbases = new Player[4];
            for (int i = 0; i < bases.Length; i++)
            {
                if (i + hits > 3) IncreaseScore.Invoke(team);

                else nextbases[i + hits] = bases[i];
            }
        }

        public void walk(int baseNum)
        {
            if (baseNum+1 > 3)
            {
                IncreaseScore.Invoke(team);   
                bases[baseNum] = null;
                return;
            }
   

            if (bases[baseNum+1] != null)
            {
                walk(baseNum + 1);
            }
            
            if (bases[baseNum + 1] == null)
            {
                bases[baseNum + 1] = bases[baseNum];
                bases[baseNum] = null;
                return;
            }

        }

        public void PrintBases()
        {
            var baseout = new StringBuilder();
            for(int i = 0;i < bases.Length;i++)
            {
                if (bases[i] == null) baseout.Append('0');
                else baseout.Append('1');
            }

            Console.WriteLine(baseout.ToString());
        }

        public Player GetAtPlate() { return bases[0]; }

        public void SetAtPlate(Player p ) { bases[0] = p; }

        
    }

}
