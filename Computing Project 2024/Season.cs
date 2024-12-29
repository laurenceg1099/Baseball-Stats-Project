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
            var teamDict = new Dictionary<string, string> { { "Orioles", "AL East" }, { "Red-Sox", "AL East" }, { "Yankees", "AL East" }, { "Rays", "AL East" }, { "Blue-Jays", "AL East" }, { "White-Sox", "AL Central" }, { "Guardians", "AL Central" }, { "Tigers", "AL Central" }, { "Royals", "AL Central" }, { "Twins", "AL Central" }, { "Astros", "AL West" }, { "Angels", "AL West" }, { "Athletics", "AL West" }, { "Mariners", "AL West" }, { "Rangers", "AL West" }, { "Braves", "NL East" }, { "Marlins", "NL East" }, { "Mets", "NL East" }, { "Phillies", "NL East" }, { "Nationals", "NL East" }, { "Cubs", "NL Central" }, { "Reds", "NL Central" }, { "Brewers", "NL Central" }, { "Pirates", "NL Central" }, { "Cardinals", "NL Central" }, { "Diamondbacks", "NL West" }, { "Rockies", "NL West" }, { "Dodgers", "NL West" }, { "Padres", "NL West" }, { "Giants", "NL West" } };
            var random = new Random();
            var schedule = new List<Series> { };
            foreach (var hometeam in _teams)
            {
                int Divisional = 0;
                int League = 0;
                int InterLeague = 0;

                foreach (var awayteam in _teams)
                {
                    if (hometeam == awayteam) continue;
                    teamDict.TryGetValue(hometeam.Name, out var homeDiv); teamDict.TryGetValue(awayteam.Name, out var awayDiv);
                    if (homeDiv == awayDiv && Divisional < 19)
                    {
                        int games = random.Next(2) == 0 ? 3 : 4;
                        Divisional += games;
                        schedule.Add(new Series(hometeam, awayteam, games));
                    }

                    if (homeDiv.Take(2) == awayDiv.Take(2) && League < 24)
                    {
                        int games = random.Next(2) == 0 ? 3 : 4; ;
                        Divisional += games;
                        schedule.Add(new Series(hometeam, awayteam, games));
                    }

                    if (homeDiv.Take(2) != awayDiv.Take(2) && InterLeague < 20)
                    {
                        int games = random.Next(2) == 0 ? 2 : 3; ;
                        Divisional += games;
                        schedule.Add(new Series(hometeam, awayteam, games));
                    }
                }
            }

            for (int i = 0; i < schedule.Count; i++)
                (schedule[i], schedule[random.Next(schedule.Count)]) = (schedule[random.Next(schedule.Count)], schedule[i]);

            writeGames(schedule);

        }

        private void writeGames(List<Series> schedule)
        {
            string filePath = "Schedule.csv";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Series s in schedule)
                {
                    for (int i = 0; i <= s._Games; i++)
                    {

                        writer.WriteLine($"{s.Hometeam.Name},{s.Awayteam.Name}");
                    }
                }
            }
        }

    }
}
