using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Enumeration;
using System.Runtime.CompilerServices;

namespace Computing_Project_2024
{
    public static class DataReaders
    {

        private const string dataDir = @"C:\Users\Laurence\source\repos\Computing Project 2024\Computing Project 2024\Data";
        private const string TeamDataDir = @"C:\Users\Laurence\source\repos\Computing Project 2024\Computing Project 2024\Teams";
        private static string batting_data => Path.Combine(dataDir,"BattingStats1.csv");
        private static string pitching_data => Path.Combine(dataDir, "PitchingStats1.csv");

        static public List<Batter> ReadBatters()
        {
            var list= File.ReadLines(batting_data).Skip(1).Select(x => new Batter(x)).ToList();
            list = list.OrderByDescending(x => x.AbilityScore).ToList();
            var newlist = list.Cast<Player>().ToList();
            list.ForEach(x => x.calcuteRank(newlist));
            return list;
        }       
            
        static public List<Pitcher> ReadPitchers()
        {
            var list = File.ReadLines(pitching_data).Skip(1).Select(x => new Pitcher(x)).ToList();
            list = list.OrderByDescending(x => x.AbilityScore).ToList();
            var newlist = list.Cast<Player>().ToList();
            list.ForEach(x => x.calcuteRank(newlist));
            return list;
        }


        //doc format = teamname_type 
        static public List<Team> CreateTeams()
        {
            var bTable = DataReaders.ReadBatters();
            var pTable = DataReaders.ReadPitchers();
            var teams = new List<Team>();

            foreach (string team in GetTeamNames())
            {
                var battersFile = Path.Combine(TeamDataDir, $"{team}_b.csv");
                var pitchersFile = Path.Combine(TeamDataDir, $"{team}_p.csv");

                var pitchers = File.ReadAllLines(pitchersFile).Skip(1).Select(x => int.Parse(x.Split(",")[2].Trim('\"'))).ToList();

                var batters = File.ReadAllLines(battersFile).Skip(1).Select(x => int.Parse(x.Split(",")[2].Trim('\"'))).ToList();

                var newteam = new Team(team, pitchers, batters);
                newteam.sortPlayers(bTable,pTable);
                teams.Add(newteam);
  
            }
            return teams;   
        }

        private static IEnumerable<string> GetTeamNames()
        {
            var files = Directory.GetFiles(TeamDataDir, "*");
            return files.Select(x => x.Split('_').First().Split('\\').Last()).Distinct();

        }

        static public List<Batter> ReadBatters(string file)
        {
            List<Batter> list = new List<Batter>();
            var lines = File.ReadAllLines(file);
            {
                foreach( var line in lines.Skip(1) ) 
                {
                    list.Add(new Batter(line)); 
                }
            }
            return list;
        }

        static public List<Pitcher> ReadPitchers(string file)
        {
            List<Pitcher> list = new List<Pitcher>();
            var lines = File.ReadAllLines(file);
            {
                foreach (var line in lines.Skip(1))
                {
                    list.Add(new Pitcher(line));
                }
            }
            return list;
        }


    }
}
