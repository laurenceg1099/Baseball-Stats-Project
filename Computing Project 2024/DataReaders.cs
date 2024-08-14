using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Enumeration;

namespace Computing_Project_2024
{
    public static class DataReaders
    {

        private const string dataDir = @"C:\Users\Laurence\source\repos\Computing Project 2024\Computing Project 2024\Data";
        private static string data => Path.Combine(dataDir, "Battingstats1.csv");

       
        static public List<Player> ReadPlayers()
        {
            List<Player> list = new List<Player>();
            using (var reader = new StreamReader(data))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().ToString().Split(",");
                    list.Add(new Player(line[1], line[0], Array.ConvertAll(line[1..-1], x => float.Parse(x))));
                }
            }
            return list;
        }


        //doc format = teamname_type 
        static public List<Team> CreateTeams()
        {
            var teams = new List<Team>();
            foreach (string team in GetTeamNames())
            {
                var battersFile = $"{dataDir}\\{team}_b.csv";
                var pitchersFile = $"{dataDir}\\{team}_p.csv";
                var pitchers = File.ReadAllLines(pitchersFile).Cast<int>().ToList();
                var batters = File.ReadAllLines(battersFile).Cast<int>().ToList();
                teams.Add(new Team(team,pitchers,batters));
                    
            }
            return teams;
        }

        private static IEnumerable<string> GetTeamNames()
        {
            var files = Directory.GetFiles(dataDir, "*");

            return files.Select(x => x.Split("_").First()).Distinct();
        }

        static public List<Batter> ReadBatters(string file)
        {
            List<Batter> list = new List<Batter>();
            var lines = File.ReadAllLines(file);
            {
                foreach( var line in lines.Skip(1) ) 
                {
                    var temp = line.Split(",");   
                    var fields = temp.Select(x => x.Trim('"')).ToArray();
                    list.Add(new Batter(fields[1].Trim(), fields[0].Trim(), fields[4..].Select(x => float.Parse(x)).ToArray())); 
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
                    var temp = line.Split(",");
                    var fields = temp.Select(x => x.Trim('"')).ToArray();
                    list.Add(new Pitcher(fields[1].Trim(), fields[0].Trim(), fields[4..].Select(x => float.Parse(x)).ToArray()));
                }
            }
            return list;
        }


    }
}
