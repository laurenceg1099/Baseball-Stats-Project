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
        public int rank;

        public int Value;
        public Player(string data)
        {
            var fields = data.Split(',').Select(x => x.Trim('\"')).ToList();
            FirstName = fields[1];
            LastName = fields[0];
            Id = int.Parse(fields[2]);
            StatLine = fields[4..].Select(x => float.Parse(x)).ToArray();

        }

        public void calcuteRank(List<Player> players)
        {
            var table = players.OrderByDescending(x => x.AbilityScore).ToList();
            rank = table.IndexOf(this);
            CalculateValue();
        }

        public override string ToString()
        {
            return $"{FirstName},{LastName} : ${Value}";
        }

        protected abstract void CalculatetAbilityScore();

        protected abstract void CalculateValue();
    

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
            AbilityScore = 1-0.01*StatLine[2] + StatLine[8] + 0.01 * StatLine[1] + Math.Log2(StatLine[0]); 
        } 

        protected override void CalculateValue()
        {
            var v = -1 * Math.Pow(10, 7) * Math.Log(rank + .1) + 5 * Math.Pow(10, 7);
            Value = Math.Max(500000, (int)v);
            }
    }

    public class Pitcher : Player
    {
        // statline (ab,k%,bb%,avg,slg,obp,ops,era,woba,whiff%,swing%)

        private int Fatigue;
        public Pitcher(string data) : base(data)
        {
            CalculatetAbilityScore();
            Fatigue = 0;
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

        public void IncreaseFatigue() { Fatigue++; }
 
        public void DecreaseFatigue() { Fatigue--; }

        public int GetFatigue() {  return Fatigue; }

        protected override void CalculateValue()
        {
            var v = -9*Math.Pow(10,6)*Math.Log(rank+.3)+ 4* Math.Pow(10,7);
            Value = Math.Max(500000, (int) v);
        }
    }

}
