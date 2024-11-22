using System.Threading.Tasks.Dataflow;

namespace Computing_Project_2024
{
    public abstract class Player
    {
        public string FirstName;
        public string LastName;
        public float[] StatLine;
        public int Id;
        public double AbilityScore;
        public Player(string data)
        {
            var fields = data.Split(',').Select(x => x.Trim('\"')).ToList();
            FirstName = fields[1];
            LastName = fields[0];
            Id = int.Parse(fields[2]);
            StatLine = fields[4..].Select(x => float.Parse(x)).ToArray();

        }

        public override string ToString()
        {
            return $"{FirstName},{LastName}";
        }

        protected abstract void CalculatetAbilityScore();

    }

    public class Batter : Player
    {
        // statline (ab,Home_runs,k%,bb%,avg,slg,onbase,ops,woba)
        public Batter(string data) : base(data)
        {
            CalculatetAbilityScore();
        }

        protected override void CalculatetAbilityScore()
        {
            AbilityScore = StatLine[8] * StatLine[1]* Math.Log2(StatLine[0]);
        }
    }

    public class Pitcher : Player
    {
        // statline (ab,k%,bb%,avg,slg,obp,ops,era,woba,whiff%,swing%)
        public Pitcher(string data) : base(data)
        {
            CalculatetAbilityScore();
        }

        protected override void CalculatetAbilityScore()
        {
            if (StatLine[0] < 250)
            {
                AbilityScore = -3+0.2*0.5-5;
            }
            else if (StatLine[0] < 350)
            {
                AbilityScore = (-(3.2 + StatLine[8]) / 2)+(0.2+StatLine[1])/4 - (5+StatLine[7])/2 ;
            }
            else
            {
                AbilityScore = -StatLine[8]+StatLine[1]*0.5-StatLine[7];
            }
        }
    }


    public class Team
    {
        public string Name;
        public List<int> Batters;
        public List<int> Pitchers;
        public List<Batter> BattingRoster;
        public List<Pitcher> PitchingRoster;
        private int rosterPos = 0;
        public Pitcher currentPitcher;

        public Team(string name, List<int> pitchers, List<int> batters)
        {
            Name = name;
            Batters = batters;
            Pitchers = pitchers;
        }

        public void sortPlayers(List<Batter> battersTable, List<Pitcher> pitchersTables)
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


    }

}
