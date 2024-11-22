using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computing_Project_2024
{
    public class Bases
    {
        public static event Action<Team> IncreaseScore;

        private Player[] bases = new Player[4];

        //[1,2,3]
        private Team team;
        public Bases(Team team)
        {
            this.team = team;
        }

        private void OnScore(Team team)
        {
            IncreaseScore?.Invoke(team);
        }

        public void advanceRunners(int hits)
        {
            Player[] nextbases = new Player[4];
            for (int i = 0; i < bases.Length; i++)
            {
                if (i + hits > 3) OnScore(team);

                else nextbases[i + hits] = bases[i];
            }

            bases = nextbases;
        }

        public void walk(int baseNum)
        {
            if (baseNum + 1 > 3)
            {
                OnScore(team);
                bases[baseNum] = null;
                return;
            }


            if (bases[baseNum + 1] != null)
            {
                walk(baseNum + 1);
            }

            if (bases[baseNum + 1] == null)
            {
                bases[baseNum + 1] = bases[baseNum];
                bases[baseNum] = null;
                return;
            }

        }

        public void PrintBases()
        {
            var baseout = new StringBuilder();
            for (int i = 0; i < bases.Length; i++)
            {
                if (bases[i] == null) baseout.Append('0');
                else baseout.Append('1');
            }

            Console.WriteLine(baseout.ToString());
        }

        public Player GetAtPlate() { return bases[0]; }

        public void SetAtPlate(Player p) { bases[0] = p; }


    }

}
