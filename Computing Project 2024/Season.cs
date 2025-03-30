using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computing_Project_2024
{
    public class Season
    {
        private Team _team;
        private int length = 185;
        public List<Team> _teams;
        public Season(List<Team> teams)
        {
            _teams = teams;

        }

        public void TestStartSeaon()
        {
            //for (int i = 0; i < _teams.Count; i++)
            //{
            //    Console.WriteLine($"{i + 1} : {_teams[i].Name}");
            //}
            //Console.WriteLine();
            //var choice = Convert.ToInt32(Console.ReadLine());
            //_team = _teams[choice - 1];

            //for (int i = 0; i < 100000; i++)
            //{
            //    long startTime = Stopwatch.GetTimestamp();
            //    CreateSchedule2();
            //    var time = Stopwatch.GetElapsedTime(startTime).TotalMilliseconds;
            //    File.AppendAllText("timedata2.csv", $"{time}\n");
            //}

            while (new FileInfo("Schedule.csv").Length != 0 && new FileInfo("Schedule.csv").Length != 40986) //40986
            {
                CreateSchedule2();
            }

            var calendar = AssignDays("Schedule.csv");
            validate(calendar); 

            foreach (var game in calendar)
            {
                //Console.CursorLeft = 0;
                //Console.Write(game.ToString() + "                                 ");
                game.playGame();

            }
            Console.WriteLine();
            _teams.ForEach(x => x.CalcRatio());
            var table = _teams.OrderByDescending(x => x.WinLoss).ToList();
            foreach (var team in table)
            {
                Console.WriteLine($"{team.Name,-15}{team._wins}-{team._losses}");
            }

            var sum = 0;
            var mlbStandings = new Dictionary<string, int[]>
            {
                // AL East
                { "Yankees", new[] { 94, 68 } },
                { "Orioles", new[] { 91, 71 } },
                { "Red-Sox", new[] { 81, 81 } },
                { "Rays", new[] { 80, 82 } },
                { "Blue-Jays", new[] { 74, 88 } },

                // AL Central
                { "Guardians", new[] { 92, 69 } },
                { "Tigers", new[] { 86, 76 } },
                { "Royals", new[] { 86, 76 } },
                { "Twins", new[] { 82, 80 } },
                { "White-Sox", new[] { 41, 121 } },

                // AL West
                { "Astros", new[] { 88, 73 } },
                { "Mariners", new[] { 85, 77 } },
                { "Rangers", new[] { 78, 84 } },
                { "Athletics", new[] { 69, 93 } },
                { "Angels", new[] { 63, 99 } },

                // NL East
                { "Phillies", new[] { 95, 67 } },
                { "Braves", new[] { 89, 73 } },
                { "Mets", new[] { 89, 73 } },
                { "Nationals", new[] { 71, 91 } },
                { "Marlins", new[] { 62, 100 } },

                // NL Central
                { "Brewers", new[] { 93, 69 } },
                { "Cubs", new[] { 83, 79 } },
                { "Cardinals", new[] { 83, 79 } },
                { "Reds", new[] { 77, 85 } },
                { "Pirates", new[] { 76, 86 } },

                // NL West
                { "Dodgers", new[] { 98, 64 } },
                { "Padres", new[] { 93, 69 } },
                { "Diamondbacks", new[] { 89, 73 } },
                { "Giants", new[] { 80, 82 } },
                { "Rockies", new[] { 61, 101 } }
            };  
            //var r = mlbStandings.OrderBy(x => Random.Shared.Next()).ToList();
            
            for (int i = 0; i < table.Count; i++)
            {
                var i2 = mlbStandings[table[i].Name];
                sum += Math.Abs(i2[0] - table[i]._wins);
                sum += Math.Abs(i2[1] - table[i]._losses);
            }
            Console.WriteLine(sum);
        }

        private List<Game> AssignDays(string path)
        {
            var lines = File.ReadAllLines(path).ToList();
            List<Game> result = lines.Select(line =>
            {
                var parts = line.Split(',');
                var team1 = _teams.FirstOrDefault(x => x.Name == parts[0]);
                var team2 = _teams.FirstOrDefault(x => x.Name == parts[1]);
                return new Game(team1, team2);
            }).ToList();

            for(int i=0; i<result.Count; i++)   
            {
                var day = 0;
                
                while (true)
                {
                    var newlist = result.Where(x => x.getDay() == day).ToList();
                    bool isGame = CheckGame(result[i], newlist);
                    if (!isGame)
                    {
                        result[i].setDay(day);
                        break;
                    }
                    day++;
                }
                
                
            }
            
            //Console.WriteLine(result.Where(x=> x.getDay() == 0 ).ToList().Count());
            //Console.WriteLine(result.Max(x=> x.getDay()));
            return result;
            

        }

        private List<Game> testAssignDays(string path)
        {
            var lines = File.ReadAllLines(path).ToList();
            List<Game> result = lines.Select(line =>
            {
                var parts = line.Split(',');
                var team1 = _teams.FirstOrDefault(x => x.Name == parts[0]);
                var team2 = _teams.FirstOrDefault(x => x.Name == parts[1]);
                return new Game(team1, team2);
            }).ToList();

            return result;

 


        }

        private bool CheckGame(Game game,List<Game> currentDays)
        {
            var prevteams = currentDays.SelectMany(x => new[] { x.HomeTeam, x.AwayTeam }).Cast<Team>().ToList();
            if (prevteams.Contains(game.HomeTeam) || prevteams.Contains(game.AwayTeam))
            {
                return true;
            }

            return false;
        }
        private void CreateSchedule()
        {
            int Divmax = 76 / 2;
            int Leaguemax = 66 / 2;
            int Intermax = 20 / 2;

            var teamDict = new Dictionary<string, string> { { "Orioles", "AL East" }, { "Red-Sox", "AL East" }, { "Yankees", "AL East" }, { "Rays", "AL East" }, { "Blue-Jays", "AL East" }, { "White-Sox", "AL Central" }, { "Guardians", "AL Central" }, { "Tigers", "AL Central" }, { "Royals", "AL Central" }, { "Twins", "AL Central" }, { "Astros", "AL West" }, { "Angels", "AL West" }, { "Athletics", "AL West" }, { "Mariners", "AL West" }, { "Rangers", "AL West" }, { "Braves", "NL East" }, { "Marlins", "NL East" }, { "Mets", "NL East" }, { "Phillies", "NL East" }, { "Nationals", "NL East" }, { "Cubs", "NL Central" }, { "Reds", "NL Central" }, { "Brewers", "NL Central" }, { "Pirates", "NL Central" }, { "Cardinals", "NL Central" }, { "Diamondbacks", "NL West" }, { "Rockies", "NL West" }, { "Dodgers", "NL West" }, { "Padres", "NL West" }, { "Giants", "NL West" } };
            var random = new Random();
            var schedule = new List<Series> { };

            var totalgames = new Dictionary<Team,int> { };
            foreach(var team in _teams)
            {
                totalgames.Add(team,0);
            }
            foreach (var hometeam in _teams)
            {
                int Divisional = 0;
                int League = 0;
                int InterLeague = 0;


                while (Divisional < Divmax || League < Leaguemax || InterLeague < Intermax)
                {
                    int randomIndex = random.Next(_teams.Count);
                    var awayteam = _teams[randomIndex];

                    teamDict.TryGetValue(hometeam.Name, out var homeDiv); 
                    teamDict.TryGetValue(awayteam.Name, out var awayDiv);

                    if (hometeam == awayteam) continue;

                    //if (totalgames.GetValueOrDefault(awayteam) > 162) continue;

                    //var maxGames = Math.Min(162 - totalgames[hometeam], 162 - totalgames[awayteam]);
                    //if (maxGames <= 0) continue;

                    //var remainingAway = 162 - totalgames[awayteam];
                    if (homeDiv == awayDiv && Divisional < Divmax)
                    {
                        int games = random.Next(2) == 0 ? 3 : 4;
                        games = Math.Min(games, Divmax - Divisional);
                        //games = Math.Min(games, maxGames);
                        Divisional += games;
                        schedule.Add(new Series(hometeam, awayteam, games));
                        //totalgames[awayteam] += games;
                        //totalgames[hometeam] += games;
                        //continue;
                    }

                    if (homeDiv.Substring(0, 2) == awayDiv.Substring(0, 2) && League < Leaguemax)
                    {
                        int games = random.Next(2) == 0 ? 3 : 4;
                        games = Math.Min(games, Leaguemax - League);
                        //games = Math.Min(games, maxGames);
                        League += games;
                        schedule.Add(new Series(hometeam, awayteam, games));
                        //totalgames[awayteam]+= games;
                        //totalgames[hometeam] += games;
                        //continue;
                    }

                    if (homeDiv.Substring(0, 2) != awayDiv.Substring(0, 2) && InterLeague < Intermax)
                    {
                        int games = random.Next(2) == 0 ? 2 : 3; ;
                        games = Math.Min(games, Intermax - InterLeague);
                        //games = Math.Min(games, maxGames);
                        InterLeague += games;
                        schedule.Add(new Series(hometeam, awayteam, games));
                        //totalgames[awayteam]+= games;
                        //totalgames[hometeam] += games;
                        //continue;
                    }

                    //throw new Exception("fuvk");



                }

                //Console.WriteLine(Divisional + League + InterLeague);



            }

            schedule = ShuffleGames(schedule);
            writeGames(schedule);




        }

        private void CreateSchedule2()
        {
 

            int Leaguemax = 66; //66
            int Intermax = 20; //20

            var teamDict = new Dictionary<string, string> { { "Orioles", "AL East" }, { "Red-Sox", "AL East" }, { "Yankees", "AL East" }, { "Rays", "AL East" }, { "Blue-Jays", "AL East" }, { "White-Sox", "AL Central" }, { "Guardians", "AL Central" }, { "Tigers", "AL Central" }, { "Royals", "AL Central" }, { "Twins", "AL Central" }, { "Astros", "AL West" }, { "Angels", "AL West" }, { "Athletics", "AL West" }, { "Mariners", "AL West" }, { "Rangers", "AL West" }, { "Braves", "NL East" }, { "Marlins", "NL East" }, { "Mets", "NL East" }, { "Phillies", "NL East" }, { "Nationals", "NL East" }, { "Cubs", "NL Central" }, { "Reds", "NL Central" }, { "Brewers", "NL Central" }, { "Pirates", "NL Central" }, { "Cardinals", "NL Central" }, { "Diamondbacks", "NL West" }, { "Rockies", "NL West" }, { "Dodgers", "NL West" }, { "Padres", "NL West" }, { "Giants", "NL West" } };
            var random = new Random();
            var schedule = new List<Series> { };

            var totalgames = new Dictionary<Team, List<int>> { };
            foreach (var team in _teams)
            {
                //{LeaugeGames,InterLeaugeGames}
                totalgames.Add(team, new List<int> {0, 0});
            }

            var divs = teamDict.Select(x=> x.Value).Distinct().ToList();
            foreach(var div in divs)
            {
                var divlist = teamDict.Where(x => x.Value == div).Select(x => x.Key).ToList();
                var teamsindiv = _teams.Where(x=> divlist.Contains(x.Name)).ToList();

                for(int i=0; i<teamsindiv.Count; i++)
                {
                    for(int j=i+1 ; j<teamsindiv.Count; j++)
                    {
                        var team = teamsindiv[i];
                        var opponent = teamsindiv[j];

                        if (team != opponent)
                        {
                            for (int s = 0; s < 5; s++)
                            {
                                bool isHome = s % 2 == 0; 
                                if (isHome) schedule.Add(new Series(team, opponent,3));
                                else schedule.Add(new Series(opponent,team,3));
             

                            }

                            for (int s = 0; s < 2; s++)
                            {
                                bool isHome = (s+3) % 2 == 0; 
                                if (isHome) schedule.Add(new Series(team, opponent, 2));
                                else schedule.Add(new Series(opponent, team, 2));

                            }
                        }
                    }
                }
            }

            var count = 0;
            while (true)
            {
                count++;
                if (count > 1000) 
                {
                    return; 
                }
                var teamsleft = totalgames.Where(x => x.Value[0] < Leaguemax ||  x.Value[1] < Intermax).ToDictionary(x => x.Key, x => x.Value);
                if (teamsleft.Count() == 0)
                {
                    break;
                }

                totalgames = teamsleft;

                var hometeam = totalgames.ElementAt(random.Next(totalgames.Count)).Key;
                var awayteam = totalgames.ElementAt(random.Next(totalgames.Count)).Key;

                if (hometeam == awayteam) continue;
                teamDict.TryGetValue(hometeam.Name, out var homeDiv);
                teamDict.TryGetValue(awayteam.Name, out var awayDiv);

                if (homeDiv == awayDiv) continue;

                if (homeDiv.Substring(0, 2) == awayDiv.Substring(0, 2) && teamsleft[hometeam][0] < Leaguemax && teamsleft[awayteam][0] <Leaguemax)
                {
                    var games = random.Next(2) == 0 ? 3 : 4;
                    var maxgames = Math.Min(Leaguemax - teamsleft[hometeam][0], Leaguemax - teamsleft[awayteam][0]);
                    games = Math.Min(games, maxgames);
                    teamsleft[hometeam][0] += games;
                    teamsleft[awayteam][0] += games;
                    schedule.Add(new Series(hometeam, awayteam, games));
                }

                if (homeDiv.Substring(0, 2) != awayDiv.Substring(0, 2) && teamsleft[hometeam][1] < Intermax && teamsleft[awayteam][1] < Intermax) 
                {
                    var games = random.Next(2) == 0 ? 3 : 4;
                    var maxgames = Math.Min(Intermax - teamsleft[hometeam][1], Intermax - teamsleft[awayteam][1]);
                    games = Math.Min(games, maxgames);
                    teamsleft[hometeam][1] += games;
                    teamsleft[awayteam][1] += games;
                    schedule.Add(new Series(hometeam,awayteam,games));
                }



            }
            

            schedule = ShuffleGames(schedule);
            writeGames(schedule);
            
        }

        private List<Series> ShuffleGames(List<Series> schedule)
        {
            int lookback = 15;
            List<Series> result = new List<Series>();
            var random = new Random();
            while (schedule.Count > 0)
            {
                var prevteams = result.TakeLast(lookback).SelectMany(x => new[] { x.Hometeam, x.Awayteam }).Cast<Team>().ToList();
                var available = schedule.Select((series,idx) => new { series, idx }).Where(x => !prevteams.Contains(x.series.Hometeam) && !prevteams.Contains(x.series.Awayteam)).ToList();
                
                if (available.Count != 0)
                {
                    var r = random.Next(available.Count);
                    var nextseries = available[r];
                    var index = nextseries.idx;
                    result.Add(nextseries.series);
                    schedule.RemoveAt(index);
                    lookback = 15;
                }
                else
                {
                    lookback--;
                }
                
       

            }

            return result;

        }

        private void writeGames(List<Series> schedule)
        {
            string filePath = "Schedule.csv";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Series s in schedule)
                {
                    for (int i = 0; i < s._Games; i++)
                    {
                        writer.WriteLine($"{s.Hometeam.Name},{s.Awayteam.Name}");

                    }
                }
            }
        }


        private void validate(List<Game> calendar)
        {
            foreach(Game game in calendar)
            {
                if (game.HomeTeam == game.AwayTeam) throw (new Exception("teams are the same "));
                
            }

            var teams = calendar.Select(x=>x.HomeTeam).Distinct().ToList();

            foreach (var team in teams)
            {
                var h = calendar.Where(x => x.HomeTeam == team).Count();
                var A = calendar.Where(x => x.AwayTeam == team).Count();

                if (h + A != 162) throw new Exception("Team does not have 162 games");

            }
        }

        public void setuserTeam(Team team)
        {
            _team = team;
        }
    }
}
