using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computing_Project_2024
{
    class Season
    {
        private Team _team;
        private int length = 185;
        private List<Team> _teams;
        public Season(List<Team> teams)
        {
            _teams = teams;
            for (int i = 0; i < teams.Count; i++)
            {
                Console.WriteLine($"{i + 1} : {teams[i].Name}");
            }
            Console.WriteLine();
            var choice = Convert.ToInt32(Console.ReadLine());
            _team = teams[choice - 1];

            CreateSchedule();


        }

        private void CreateSchedule()
        {
            int Divmax = 76 / 2;
            int Leaguemax = 66 / 2;
            int Intermax = 20 / 2;

            var teamDict = new Dictionary<string, string> { { "Orioles", "AL East" }, { "Red-Sox", "AL East" }, { "Yankees", "AL East" }, { "Rays", "AL East" }, { "Blue-Jays", "AL East" }, { "White-Sox", "AL Central" }, { "Guardians", "AL Central" }, { "Tigers", "AL Central" }, { "Royals", "AL Central" }, { "Twins", "AL Central" }, { "Astros", "AL West" }, { "Angels", "AL West" }, { "Athletics", "AL West" }, { "Mariners", "AL West" }, { "Rangers", "AL West" }, { "Braves", "NL East" }, { "Marlins", "NL East" }, { "Mets", "NL East" }, { "Phillies", "NL East" }, { "Nationals", "NL East" }, { "Cubs", "NL Central" }, { "Reds", "NL Central" }, { "Brewers", "NL Central" }, { "Pirates", "NL Central" }, { "Cardinals", "NL Central" }, { "Diamondbacks", "NL West" }, { "Rockies", "NL West" }, { "Dodgers", "NL West" }, { "Padres", "NL West" }, { "Giants", "NL West" } };
            var random = new Random();
            var schedule = new List<Series> { };

            foreach (var hometeam in _teams)
            {
                int Divisional = 0;
                int League = 0;
                int InterLeague = 0;


                while (Divisional < Divmax || League < Leaguemax || InterLeague < Intermax)
                {
                    int randomIndex = random.Next(_teams.Count);
                    var awayteam = _teams[randomIndex];

                    teamDict.TryGetValue(hometeam.Name, out var homeDiv); teamDict.TryGetValue(awayteam.Name, out var awayDiv);

                    if (hometeam == awayteam) continue;

                    else if (homeDiv == awayDiv && Divisional < Divmax)
                    {
                        int games = random.Next(2) == 0 ? 3 : 4;
                        games = Math.Min(games, Divmax - Divisional);
                        Divisional += games;
                        schedule.Add(new Series(hometeam, awayteam, games));
                    }

                    else if (homeDiv.Substring(0, 2) == awayDiv.Substring(0, 2) && League < Leaguemax)
                    {
                        int games = random.Next(2) == 0 ? 3 : 4;
                        games = Math.Min(games, Leaguemax - League);
                        League += games;
                        schedule.Add(new Series(hometeam, awayteam, games));
                    }

                    else if (homeDiv.Substring(0, 2) != awayDiv.Substring(0, 2) && InterLeague < Intermax)
                    {
                        int games = random.Next(2) == 0 ? 2 : 3; ;
                        games = Math.Min(games, Intermax - InterLeague);
                        InterLeague += games;
                        schedule.Add(new Series(hometeam, awayteam, games));
                    }

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

    }
}
