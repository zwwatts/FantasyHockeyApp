namespace Forms
{
    partial class HockeyAppForm
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
            this.appName = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.standings = new System.Windows.Forms.TabPage();
            this.standingsDataGridView = new System.Windows.Forms.DataGridView();
            this.matchups = new System.Windows.Forms.TabPage();
            this.matchupDataGridView = new System.Windows.Forms.DataGridView();
            this.teams = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SkaterDataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.goalieDataGridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.teamComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.leagueName = new System.Windows.Forms.Label();
            this.leagueIDSubmit = new System.Windows.Forms.Button();
            this.leagueIDLabel = new System.Windows.Forms.Label();
            this.leagueIDNumeric = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.standings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.standingsDataGridView)).BeginInit();
            this.matchups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchupDataGridView)).BeginInit();
            this.teams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SkaterDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goalieDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leagueIDNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // appName
            // 
            this.appName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.appName.AutoSize = true;
            this.appName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appName.Location = new System.Drawing.Point(359, 11);
            this.appName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.appName.Name = "appName";
            this.appName.Size = new System.Drawing.Size(283, 26);
            this.appName.TabIndex = 0;
            this.appName.Text = "Yahoo Fantasy Hockey App";
            this.appName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.standings);
            this.tabControl1.Controls.Add(this.matchups);
            this.tabControl1.Controls.Add(this.teams);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 53);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(982, 402);
            this.tabControl1.TabIndex = 1;
            // 
            // standings
            // 
            this.standings.Controls.Add(this.standingsDataGridView);
            this.standings.Location = new System.Drawing.Point(4, 25);
            this.standings.Margin = new System.Windows.Forms.Padding(4);
            this.standings.Name = "standings";
            this.standings.Padding = new System.Windows.Forms.Padding(4);
            this.standings.Size = new System.Drawing.Size(974, 373);
            this.standings.TabIndex = 0;
            this.standings.Text = "Standings";
            this.standings.UseVisualStyleBackColor = true;
            // 
            // standingsDataGridView
            // 
            this.standingsDataGridView.AllowUserToAddRows = false;
            this.standingsDataGridView.AllowUserToDeleteRows = false;
            this.standingsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.standingsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.standingsDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.standingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.standingsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.standingsDataGridView.Location = new System.Drawing.Point(4, 4);
            this.standingsDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.standingsDataGridView.MultiSelect = false;
            this.standingsDataGridView.Name = "standingsDataGridView";
            this.standingsDataGridView.ReadOnly = true;
            this.standingsDataGridView.RowHeadersVisible = false;
            this.standingsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.standingsDataGridView.Size = new System.Drawing.Size(966, 365);
            this.standingsDataGridView.TabIndex = 0;
            // 
            // matchups
            // 
            this.matchups.Controls.Add(this.matchupDataGridView);
            this.matchups.Location = new System.Drawing.Point(4, 25);
            this.matchups.Margin = new System.Windows.Forms.Padding(4);
            this.matchups.Name = "matchups";
            this.matchups.Padding = new System.Windows.Forms.Padding(4);
            this.matchups.Size = new System.Drawing.Size(974, 382);
            this.matchups.TabIndex = 1;
            this.matchups.Text = "Matchups";
            this.matchups.UseVisualStyleBackColor = true;
            // 
            // matchupDataGridView
            // 
            this.matchupDataGridView.AllowUserToAddRows = false;
            this.matchupDataGridView.AllowUserToDeleteRows = false;
            this.matchupDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.matchupDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.matchupDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matchupDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matchupDataGridView.Location = new System.Drawing.Point(4, 4);
            this.matchupDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.matchupDataGridView.MultiSelect = false;
            this.matchupDataGridView.Name = "matchupDataGridView";
            this.matchupDataGridView.ReadOnly = true;
            this.matchupDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.matchupDataGridView.RowHeadersVisible = false;
            this.matchupDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.matchupDataGridView.Size = new System.Drawing.Size(966, 374);
            this.matchupDataGridView.TabIndex = 0;
            // 
            // teams
            // 
            this.teams.Controls.Add(this.splitContainer1);
            this.teams.Controls.Add(this.label1);
            this.teams.Controls.Add(this.teamComboBox);
            this.teams.Location = new System.Drawing.Point(4, 25);
            this.teams.Margin = new System.Windows.Forms.Padding(4);
            this.teams.Name = "teams";
            this.teams.Padding = new System.Windows.Forms.Padding(4);
            this.teams.Size = new System.Drawing.Size(974, 382);
            this.teams.TabIndex = 2;
            this.teams.Text = "Teams";
            this.teams.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 55);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.SkaterDataGridView);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.goalieDataGridView);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Size = new System.Drawing.Size(974, 327);
            this.splitContainer1.SplitterDistance = 162;
            this.splitContainer1.TabIndex = 6;
            // 
            // SkaterDataGridView
            // 
            this.SkaterDataGridView.AllowUserToAddRows = false;
            this.SkaterDataGridView.AllowUserToDeleteRows = false;
            this.SkaterDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SkaterDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SkaterDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.SkaterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SkaterDataGridView.Location = new System.Drawing.Point(4, 24);
            this.SkaterDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.SkaterDataGridView.MultiSelect = false;
            this.SkaterDataGridView.Name = "SkaterDataGridView";
            this.SkaterDataGridView.ReadOnly = true;
            this.SkaterDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.SkaterDataGridView.RowHeadersVisible = false;
            this.SkaterDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SkaterDataGridView.Size = new System.Drawing.Size(966, 134);
            this.SkaterDataGridView.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Skaters";
            // 
            // goalieDataGridView
            // 
            this.goalieDataGridView.AllowUserToAddRows = false;
            this.goalieDataGridView.AllowUserToDeleteRows = false;
            this.goalieDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.goalieDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.goalieDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.goalieDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.goalieDataGridView.Location = new System.Drawing.Point(4, 23);
            this.goalieDataGridView.MultiSelect = false;
            this.goalieDataGridView.Name = "goalieDataGridView";
            this.goalieDataGridView.ReadOnly = true;
            this.goalieDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.goalieDataGridView.RowHeadersVisible = false;
            this.goalieDataGridView.RowTemplate.Height = 24;
            this.goalieDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.goalieDataGridView.Size = new System.Drawing.Size(966, 135);
            this.goalieDataGridView.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Goalies";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(846, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Your Team:";
            // 
            // teamComboBox
            // 
            this.teamComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.teamComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teamComboBox.FormattingEnabled = true;
            this.teamComboBox.Location = new System.Drawing.Point(850, 25);
            this.teamComboBox.Name = "teamComboBox";
            this.teamComboBox.Size = new System.Drawing.Size(121, 24);
            this.teamComboBox.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.leagueIDNumeric);
            this.panel1.Controls.Add(this.leagueIDLabel);
            this.panel1.Controls.Add(this.leagueIDSubmit);
            this.panel1.Controls.Add(this.leagueName);
            this.panel1.Controls.Add(this.appName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 53);
            this.panel1.TabIndex = 2;
            // 
            // leagueName
            // 
            this.leagueName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.leagueName.AutoSize = true;
            this.leagueName.Location = new System.Drawing.Point(786, 19);
            this.leagueName.Name = "leagueName";
            this.leagueName.Size = new System.Drawing.Size(192, 17);
            this.leagueName.TabIndex = 1;
            this.leagueName.Text = "<League Name Placeholder>";
            // 
            // leagueIDSubmit
            // 
            this.leagueIDSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.leagueIDSubmit.Location = new System.Drawing.Point(107, 26);
            this.leagueIDSubmit.Name = "leagueIDSubmit";
            this.leagueIDSubmit.Size = new System.Drawing.Size(66, 23);
            this.leagueIDSubmit.TabIndex = 2;
            this.leagueIDSubmit.Text = "Submit";
            this.leagueIDSubmit.UseVisualStyleBackColor = true;
            this.leagueIDSubmit.Click += new System.EventHandler(this.leagueIDSubmit_Click);
            // 
            // leagueIDLabel
            // 
            this.leagueIDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.leagueIDLabel.AutoSize = true;
            this.leagueIDLabel.Location = new System.Drawing.Point(3, 7);
            this.leagueIDLabel.Name = "leagueIDLabel";
            this.leagueIDLabel.Size = new System.Drawing.Size(73, 17);
            this.leagueIDLabel.TabIndex = 4;
            this.leagueIDLabel.Text = "League ID";
            // 
            // leagueIDNumeric
            // 
            this.leagueIDNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.leagueIDNumeric.Location = new System.Drawing.Point(5, 26);
            this.leagueIDNumeric.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.leagueIDNumeric.Name = "leagueIDNumeric";
            this.leagueIDNumeric.Size = new System.Drawing.Size(96, 22);
            this.leagueIDNumeric.TabIndex = 5;
            this.leagueIDNumeric.Value = new decimal(new int[] {
            22381,
            0,
            0,
            0});
            // 
            // HockeyAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 455);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HockeyAppForm";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.standings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.standingsDataGridView)).EndInit();
            this.matchups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.matchupDataGridView)).EndInit();
            this.teams.ResumeLayout(false);
            this.teams.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SkaterDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goalieDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leagueIDNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label appName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage standings;
        private System.Windows.Forms.TabPage matchups;
        private System.Windows.Forms.TabPage teams;
        private System.Windows.Forms.DataGridView standingsDataGridView;
        private System.Windows.Forms.DataGridView matchupDataGridView;
        private System.Windows.Forms.DataGridView SkaterDataGridView;
        private System.Windows.Forms.ComboBox teamComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView goalieDataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label leagueName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label leagueIDLabel;
        private System.Windows.Forms.Button leagueIDSubmit;
        private System.Windows.Forms.NumericUpDown leagueIDNumeric;
    }
}

