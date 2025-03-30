namespace GUI
{
    partial class NewGame
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
            SelectTeam = new Button();
            TeamList = new ListView();
            panel1 = new Panel();
            TeamName = new Label();
            TeamIcon = new PictureBox();
            PitchingLine = new ListBox();
            BattIngLine = new ListBox();
            Label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TeamIcon).BeginInit();
            SuspendLayout();
            // 
            // SelectTeam
            // 
            SelectTeam.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SelectTeam.Location = new Point(1032, 709);
            SelectTeam.Name = "SelectTeam";
            SelectTeam.Size = new Size(519, 91);
            SelectTeam.TabIndex = 0;
            SelectTeam.Text = "Select Team";
            SelectTeam.UseVisualStyleBackColor = true;
            SelectTeam.Click += SelectTeam_Click;
            // 
            // TeamList
            // 
            TeamList.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            TeamList.GridLines = true;
            TeamList.Location = new Point(12, 43);
            TeamList.Name = "TeamList";
            TeamList.Size = new Size(1014, 757);
            TeamList.TabIndex = 1;
            TeamList.TileSize = new Size(175, 125);
            TeamList.UseCompatibleStateImageBehavior = false;
            TeamList.View = View.Tile;
            TeamList.SelectedIndexChanged += TeamList_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(TeamName);
            panel1.Controls.Add(TeamIcon);
            panel1.Controls.Add(PitchingLine);
            panel1.Controls.Add(BattIngLine);
            panel1.Location = new Point(1039, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(510, 657);
            panel1.TabIndex = 2;
            // 
            // TeamName
            // 
            TeamName.Anchor = AnchorStyles.None;
            TeamName.AutoSize = true;
            TeamName.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TeamName.Location = new Point(197, 202);
            TeamName.Name = "TeamName";
            TeamName.Size = new Size(112, 25);
            TeamName.TabIndex = 4;
            TeamName.Text = "Team Name";
            TeamName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TeamIcon
            // 
            TeamIcon.Anchor = AnchorStyles.Top;
            TeamIcon.Location = new Point(142, 15);
            TeamIcon.Name = "TeamIcon";
            TeamIcon.Size = new Size(216, 169);
            TeamIcon.TabIndex = 3;
            TeamIcon.TabStop = false;
            // 
            // PitchingLine
            // 
            PitchingLine.FormattingEnabled = true;
            PitchingLine.Location = new Point(253, 328);
            PitchingLine.Name = "PitchingLine";
            PitchingLine.Size = new Size(248, 324);
            PitchingLine.TabIndex = 2;
            PitchingLine.SelectedIndexChanged += PitchingLine_SelectedIndexChanged;
            // 
            // BattIngLine
            // 
            BattIngLine.Anchor = AnchorStyles.Bottom;
            BattIngLine.FormattingEnabled = true;
            BattIngLine.Location = new Point(-1, 328);
            BattIngLine.Name = "BattIngLine";
            BattIngLine.SelectionMode = SelectionMode.None;
            BattIngLine.Size = new Size(248, 324);
            BattIngLine.TabIndex = 0;
            BattIngLine.SelectedIndexChanged += BattIngLine_SelectedIndexChanged;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label1.Location = new Point(12, 9);
            Label1.Name = "Label1";
            Label1.Size = new Size(209, 31);
            Label1.TabIndex = 3;
            Label1.Text = "Choose your Team";
            // 
            // NewGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1563, 812);
            Controls.Add(Label1);
            Controls.Add(panel1);
            Controls.Add(TeamList);
            Controls.Add(SelectTeam);
            Name = "NewGame";
            Text = "NewGame";
            Load += NewGame_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TeamIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SelectTeam;
        private ListView TeamList;
        private Panel panel1;
        private ListBox BattIngLine;
        private Label Label1;
        private ListBox PitchingLine;
        private PictureBox TeamIcon;
        private Label TeamName;
    }
}