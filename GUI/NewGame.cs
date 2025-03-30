using Computing_Project_2024;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class NewGame : Form
    {

        private string selectedTeam;
        private Season season;
        public NewGame(Season season)
        {
            this.season = season;
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            TeamList.MultiSelect = false;
            for (int i = 0; i < 30; i++)
            {
                TeamList.Items.Add(season._teams[i].Name);
            }
        }

        private void NewGame_Load(object sender, EventArgs e)
        {

        }

        private void TeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TeamList.SelectedItems.Count != 0)
            {
                var selectedItem = TeamList.SelectedItems[0];
                selectedTeam = selectedItem.Text;

                var t = season._teams.Where(x => x.Name == selectedTeam).FirstOrDefault();
                UpdatebatteringBox(t);
                UpdatePitchingBox(t);
                TeamName.Text = t.Name;
                CenterLabel();
            }



        }

        private void CenterLabel()
        {
            TeamName.Left = (panel1.ClientSize.Width - TeamName.Width) / 2;
        }

        private void SelectTeam_Click(object sender, EventArgs e)
        {
            var t = season._teams.Where(x => x.Name == selectedTeam).FirstOrDefault();
            if (t != null)
            {
                season.setuserTeam(t);

            }

        }

        private void BattIngLine_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UpdatebatteringBox(Team t)
        {
            BattIngLine.Items.Clear();
            for (int i = 0; i < 9; i++)
            {
                var batter = t.BattingRoster[i];
                BattIngLine.Items.Add($"{i + 1} : {batter.FirstName} {batter.LastName}");
            }
        }

        private void UpdatePitchingBox(Team t)
        {
            PitchingLine.Items.Clear();
            for (int i = 0; i < 13; i++)
            {
                var pitcher = t.PitchingRoster[i];
                PitchingLine.Items.Add($"{i + 1} : {pitcher.FirstName} {pitcher.LastName}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PitchingLine_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
