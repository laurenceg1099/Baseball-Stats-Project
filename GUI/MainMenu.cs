using Computing_Project_2024;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace GUI
{
    public partial class MainMenu : Form
    {
        private Season season;
        public MainMenu(Season season)
        {   
            this.season = season;
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            NewGame newgamescreen = new NewGame(season);
            Hide();
            newgamescreen.ShowDialog();
            Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
