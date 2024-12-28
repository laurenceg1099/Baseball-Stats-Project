using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computing_Project_2024
{
    public class TeamEditor
    {
        private Team _Team ;
        public TeamEditor(Team team) 
        {
            _Team = team;
        }

        public void EditTeam()
        {
            //replace with gui insted of text interface 
            while (true)
            {

                var edit = true;

                for (int i = 0; i < _Team.BattingRoster.Count; i++) 
                {
                    Console.WriteLine($"[{i+1}] {_Team.BattingRoster[i].ToString()}");
                }

                var  item = Convert.ToInt32(Console.ReadLine());

                switch (item)
                {
                    case 0:
                        edit = false; break;
                    default: edit = true; break;
                }
                
                if (!edit)
                {
                    break;
                }

                
                switchBatter(item);

                


            }
        }

        private void switchBatter(int i) 
        {
            Console.WriteLine();
            var newlist = _Team.FullBattingRoster.Where(x => x.Id != _Team.BattingRoster[i - 1].Id).OrderBy(x => x.FirstName).ToList();
            for (int y = 0; y < newlist.Count; y++)
            {
                Console.WriteLine($"[{y + 1}] {newlist[y].ToString()}");
            }

             var newplayer = Convert.ToInt32(Console.ReadLine());
            _Team.BattingRoster[i-1] = newlist[newplayer - 1];
            
            Console.WriteLine();
        }

        public void changePitcher()
        {

        }
    }
}
