namespace GUI
{
    partial class HomeScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Calendar = new ListView();
            DayDetails = new Panel();
            AwayRecord = new Label();
            HomeRecord = new Label();
            AwayTeamIcon = new PictureBox();
            HomeTeamIcon = new PictureBox();
            AwayTeam = new Label();
            HomeTeam = new Label();
            DayDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AwayTeamIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HomeTeamIcon).BeginInit();
            SuspendLayout();
            // 
            // Calendar
            // 
            Calendar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Calendar.Location = new Point(12, 12);
            Calendar.MultiSelect = false;
            Calendar.Name = "Calendar";
            Calendar.Size = new Size(888, 556);
            Calendar.TabIndex = 0;
            Calendar.TileSize = new Size(120, 120);
            Calendar.UseCompatibleStateImageBehavior = false;
            Calendar.View = View.Tile;
            Calendar.SelectedIndexChanged += Calendar_SelectedIndexChanged;
            // 
            // DayDetails
            // 
            DayDetails.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DayDetails.Controls.Add(AwayRecord);
            DayDetails.Controls.Add(HomeRecord);
            DayDetails.Controls.Add(AwayTeamIcon);
            DayDetails.Controls.Add(HomeTeamIcon);
            DayDetails.Controls.Add(AwayTeam);
            DayDetails.Controls.Add(HomeTeam);
            DayDetails.Location = new Point(915, 14);
            DayDetails.Name = "DayDetails";
            DayDetails.Size = new Size(638, 554);
            DayDetails.TabIndex = 1;
            // 
            // AwayRecord
            // 
            AwayRecord.AutoSize = true;
            AwayRecord.Location = new Point(439, 58);
            AwayRecord.Name = "AwayRecord";
            AwayRecord.Size = new Size(39, 20);
            AwayRecord.TabIndex = 5;
            AwayRecord.Text = "0 - 0";
            AwayRecord.Click += AwayRecord_Click;
            // 
            // HomeRecord
            // 
            HomeRecord.AutoSize = true;
            HomeRecord.Location = new Point(148, 58);
            HomeRecord.Name = "HomeRecord";
            HomeRecord.Size = new Size(39, 20);
            HomeRecord.TabIndex = 4;
            HomeRecord.Text = "0 - 0";
            HomeRecord.Click += HomeRecord_Click;
            // 
            // AwayTeamIcon
            // 
            AwayTeamIcon.BackColor = Color.Navy;
            AwayTeamIcon.Location = new Point(484, 23);
            AwayTeamIcon.Name = "AwayTeamIcon";
            AwayTeamIcon.Size = new Size(91, 87);
            AwayTeamIcon.TabIndex = 3;
            AwayTeamIcon.TabStop = false;
            // 
            // HomeTeamIcon
            // 
            HomeTeamIcon.BackColor = Color.Maroon;
            HomeTeamIcon.Location = new Point(51, 23);
            HomeTeamIcon.Name = "HomeTeamIcon";
            HomeTeamIcon.Size = new Size(91, 87);
            HomeTeamIcon.TabIndex = 2;
            HomeTeamIcon.TabStop = false;
            // 
            // AwayTeam
            // 
            AwayTeam.AutoSize = true;
            AwayTeam.Location = new Point(490, 113);
            AwayTeam.Name = "AwayTeam";
            AwayTeam.Size = new Size(85, 20);
            AwayTeam.TabIndex = 1;
            AwayTeam.Text = "Away Team";
            // 
            // HomeTeam
            // 
            HomeTeam.AutoSize = true;
            HomeTeam.Location = new Point(52, 113);
            HomeTeam.Name = "HomeTeam";
            HomeTeam.Size = new Size(90, 20);
            HomeTeam.TabIndex = 0;
            HomeTeam.Text = "Home Team";
            HomeTeam.Click += HomeTeam_Click;
            // 
            // HomeScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1563, 812);
            Controls.Add(DayDetails);
            Controls.Add(Calendar);
            Name = "HomeScreen";
            Text = "HomeScreen";
            Load += HomeScreen_Load;
            DayDetails.ResumeLayout(false);
            DayDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AwayTeamIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)HomeTeamIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListView Calendar;
        private Panel DayDetails;
        private PictureBox AwayTeamIcon;
        private PictureBox HomeTeamIcon;
        private Label AwayTeam;
        private Label HomeTeam;
        private Label AwayRecord;
        private Label HomeRecord;
    }
}