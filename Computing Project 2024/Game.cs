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

        public int HomeScore;
        public int AwayScore;
        private int length = 9;
        private int _Day = -1;
        public Game(Team hometeam,Team awayteam) 
        {
            HomeTeam = hometeam;
            AwayTeam = awayteam;

        }

        public void setDay(int day)
        {
            _Day = day;
        }
        public int getDay()
        {
            return _Day;
        }

        public void playGame()
        {

            Bases.IncreaseScore += Bases_IncreaseScore;
            //change team lineups 


            for (int i = 0; i < length; i++)
            {

                var currentinning = new Inning(HomeTeam, AwayTeam);
                //Console.WriteLine($"{HomeScore}:{AwayScore}");
            }

            while (HomeScore == AwayScore) //extra innings 
            {
                var currentinning = new Inning(HomeTeam, AwayTeam);
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
            //Console.WriteLine();
            DoInning(home,away,new Bases(home));    
        }

        private void DoInning(Team batting, Team pitching,Bases bases)
        {
            checkFatigue(pitching);
           
            outs = 0;
            while (outs < 3)
            {
                bases.SetAtPlate(batting.nextbatter());
                //bases.PrintBases();
                var result = AtBat.New((Batter)bases.GetAtPlate(), pitching.currentPitcher);
                //Console.WriteLine(result);
                switch (result)
                {
                    case 0: outs++; bases.SetAtPlate(null); break;
                    case -1: bases.walk(0); break;
                    default: bases.advanceRunners(result); break;
                }


            }

        }

        private void checkFatigue(Team pitchingTeam)
        {
            int maxFatigue = 75;
            if(pitchingTeam.currentPitcher.GetFatigue() > maxFatigue)
            {
                pitchingTeam.nextPitcher();
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
                pitcher.IncreaseFatigue();

                char outcome = Pitch.Pitchball(strikes, balls, pitcher,batter);
                //Console.WriteLine(outcome);
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
