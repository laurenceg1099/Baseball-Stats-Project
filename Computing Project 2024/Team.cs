using System.Dynamic;

namespace Computing_Project_2024
{
    public class Team
    {
        public string Name;
        public List<int> Batters;
        public List<int> Pitchers;
        public List<Batter> BattingRoster;
        public List<Pitcher> PitchingRoster;
        public List<Batter> FullBattingRoster;
        private int rosterPos = 0;
        private int pitcherpos = 0;
        public Pitcher currentPitcher;

        public Team(string name, List<int> pitchers, List<int> batters)
        {
            Name = name;
            Batters = batters;
            Pitchers = pitchers;
        }

        public void sortPlayers(List<Batter> battersTable, List<Pitcher> pitchersTables) //sorts teams to initizlize starting lineups 
        {
            BattingRoster = SortBatters(battersTable).Take(9).ToList();
            PitchingRoster = SortPitchers(pitchersTables).Take(13).ToList();
            currentPitcher = PitchingRoster[0]; 
        }
        private List<Batter> SortBatters(List<Batter> batterstable)
        {
            return GetBatters(batterstable).OrderByDescending(x => x.AbilityScore).ToList();
        }

        private List<Pitcher> SortPitchers(List<Pitcher> pitcherstable)
        {
            return GetPitchers(pitcherstable).OrderByDescending(x => x.AbilityScore).ToList();
        }
        private List<Batter> GetBatters(List<Batter> batterstable)
        {
            var newlist = batterstable.Where(x => Batters.Contains(x.Id)).ToList();
            FullBattingRoster = newlist;
            return newlist;
        }

        private List<Pitcher> GetPitchers(List<Pitcher> pitcherstable)
        {
            var newlist = pitcherstable.Where(x => Pitchers.Contains(x.Id)).ToList();
            return newlist;
        }


        

        public Player nextbatter()
        {
            if (rosterPos > 8)
            {
                rosterPos = 0;
            }
            var next = BattingRoster[rosterPos];
            rosterPos++;
            return next;
        }

        public void nextPitcher()
        {
            if (rosterPos > 8)
            {
                rosterPos = 0;
            }
            var next = PitchingRoster[rosterPos];
            rosterPos++;
            currentPitcher = next;
        }


    }

}
