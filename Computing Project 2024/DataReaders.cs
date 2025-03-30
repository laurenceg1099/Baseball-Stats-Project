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
            return list;
        }       
            
        static public List<Pitcher> ReadPitchers()
        {
            var list = File.ReadLines(pitching_data).Skip(1).Select(x => new Pitcher(x)).ToList();
            list = list.OrderByDescending(x => x.AbilityScore).ToList();
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

            
            

            var namesalary = getsalarys();
            setValues(bTable, pTable,namesalary);

            return teams;   
        }

        private static void setValues(List<Batter> bTable, List<Pitcher> pTable, List<Tuple<string, int>> namesalary)
        {
            foreach(var batter in bTable)
            {
                var name = $"{batter.FirstName.Trim()} {batter.LastName}";
                var s = namesalary.Where(x => x.Item1 == name).ToList(); 
                if (s.Count() == 1)
                {
                    batter.setValue(s[0].Item2);
                }
                else
                {
                    double v = 500000;
                    var approx = bTable.Where(x => Math.Round(x.AbilityScore, 1) == Math.Round(batter.AbilityScore, 1)).Where(x => x.Value != 0).ToList();
                    if (approx.Count() >= 1)
                    {
                         v = approx.Select(x => x.Value).Average();
                    }
                    
                    batter.setValue((int)v);
                }

            }

            foreach (var pitcher in pTable)
            {
                var name = $"{pitcher.FirstName.Trim()} {pitcher.LastName}";
                var s = namesalary.Where(x => x.Item1 == name).ToList();
                if (s.Count() == 1)
                {
                    pitcher.setValue(s[0].Item2);
                }
                else
                {
                    double v = 500000;
                    var approx = bTable.Where(x => Math.Round(x.AbilityScore, 1) == Math.Round(pitcher.AbilityScore, 1)).Where(x => x.Value != 0).ToList();
                    if (approx.Count() >= 1)
                    {
                        v = approx.Select(x => x.Value).Average();
                    }

                    pitcher.setValue((int)v);
                }
            }
        }

        private static List<Tuple<string,int>> getsalarys()
        {
            var output = new List<Tuple<string, int>>();
            var path = @"C:\Users\Laurence\source\repos\Computing Project 2024\Computing Project 2024\Data\NameSalaryData.csv";
            var salary = File.ReadAllLines(path).Select(x => x.Split(",")).ToList();
            foreach (var line in salary)
            {
                output.Add(new Tuple<string, int>(line[0], int.Parse(line[2])));
            }

            return output;
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
