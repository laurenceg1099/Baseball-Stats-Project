using Computing_Project_2024;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class HomeScreen : Form
    {
        Season season;
        private Game SelectedGame;
        public HomeScreen(Season season)
        {
            InitializeComponent();
            this.season = season;

            season.startSeason();
            var Callength = 30;

            var curent = season.calendar.Where(x => x.getDay() >= season.day && x.getDay() < season.day + Callength).ToList();
            var relevant = curent.Where(x => x.HomeTeam == season._team || x.AwayTeam == season._team).ToList();
            for (int i = 0; i < Callength; i++)
            {
                var games = curent.Where(x => x.getDay() == i).ToList();
                var teamgames = games.Where(x => x.HomeTeam == season._team || x.AwayTeam == season._team).ToList();
                if (teamgames.Count() != 0)
                {
                    Calendar.Items.Add($"{i} \n {teamgames[0].HomeTeam.Name} : {teamgames[0].AwayTeam.Name}");
                }
                else
                {
                    Calendar.Items.Add("N/A", "N/A");
                }
            }


        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {

        }

        private void Calendar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Calendar.SelectedItems.Count != 0)
            {
                var a = Calendar.SelectedItems[0];
                var day = int.Parse(a.Text.Split(' ')[0]);
                var team1 = a.Text.Split(' ')[2];
                var team2 = a.Text.Split(' ')[4];

                var games = season.calendar.Where(x => x.getDay() == day);
                SelectedGame = games.Where(x => x.HomeTeam.Name == team1 || x.HomeTeam.Name == team2).First();

                UpdateHomeTeam();
                UpdateAwayTeam();
            }


        }

        private void UpdateHomeTeam()
        {
            HomeTeam.Text = SelectedGame.HomeTeam.Name;
            HomeRecord.Text = $"{SelectedGame.HomeTeam._wins} - {SelectedGame.HomeTeam._losses}";
        }

        private void UpdateAwayTeam()
        {
            AwayTeam.Text = SelectedGame.AwayTeam.Name;
            AwayRecord.Text = $"{SelectedGame.AwayTeam._wins} - {SelectedGame.AwayTeam._losses}";
        
        }

        private void HomeTeam_Click(object sender, EventArgs e)
        {

        }

        private void HomeRecord_Click(object sender, EventArgs e)
        {

        }

        private void AwayRecord_Click(object sender, EventArgs e)
        {

        }
    }
}
