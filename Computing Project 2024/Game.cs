using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
            HomeTeam = hometeam;
            AwayTeam = awayteam;

            Bases.IncreaseScore += Bases_IncreaseScore;
            //change team lineups 
            for (int i = 0; i < length; i++)
            {
              
               var currentinning = new Inning(hometeam,awayteam);
               Console.WriteLine($"{HomeScore},{AwayScore}");
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
            Console.WriteLine();
            DoInning(home,away,new Bases(home));    
        }

        private void DoInning(Team batting, Team pitching,Bases bases)
        {
           
            outs = 0;
            while (outs < 3)
            {
                bases.SetAtPlate(batting.nextbatter());
                var result = AtBat.New((Batter)bases.GetAtPlate(), pitching.currentPitcher);
                switch (result)
                {
                    case 0: outs++; bases.SetAtPlate(null); break;
                    case -1: bases.walk(0); break;
                    default: bases.advanceRunners(result); break;
                }
                    
                bases.PrintBases();

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
            while (strikes < 3  && balls < 4)
            {
                char outcome = Pitch.Pitchball(strikes, balls, batter, pitcher);
                switch (outcome) //k,b,1,2,3,4
                {
                    case 'k': strikes++; break;
                    case 'b': balls++; break;
                    default: return outcome - '0'; 
                }
            }

            if (strikes == 3) return 0;
            if(balls == 4) return -1;

            throw new Exception("unexpected outcome");
                
        }  
    }

}
