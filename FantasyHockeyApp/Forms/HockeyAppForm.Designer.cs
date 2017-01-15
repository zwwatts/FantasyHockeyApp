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
            this.goalieDataGridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.teamComboBox = new System.Windows.Forms.ComboBox();
            this.SkaterDataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.leagueName = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.standings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.standingsDataGridView)).BeginInit();
            this.matchups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchupDataGridView)).BeginInit();
            this.teams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.goalieDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkaterDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.tabControl1.Location = new System.Drawing.Point(0, 44);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(982, 411);
            this.tabControl1.TabIndex = 1;
            // 
            // standings
            // 
            this.standings.Controls.Add(this.standingsDataGridView);
            this.standings.Location = new System.Drawing.Point(4, 25);
            this.standings.Margin = new System.Windows.Forms.Padding(4);
            this.standings.Name = "standings";
            this.standings.Padding = new System.Windows.Forms.Padding(4);
            this.standings.Size = new System.Drawing.Size(974, 382);
            this.standings.TabIndex = 0;
            this.standings.Text = "Standings";
            this.standings.UseVisualStyleBackColor = true;
            // 
            // standingsDataGridView
            // 
            this.standingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.standingsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.standingsDataGridView.Location = new System.Drawing.Point(4, 4);
            this.standingsDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.standingsDataGridView.Name = "standingsDataGridView";
            this.standingsDataGridView.ReadOnly = true;
            this.standingsDataGridView.Size = new System.Drawing.Size(966, 374);
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
            this.matchupDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matchupDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matchupDataGridView.Location = new System.Drawing.Point(4, 4);
            this.matchupDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.matchupDataGridView.Name = "matchupDataGridView";
            this.matchupDataGridView.ReadOnly = true;
            this.matchupDataGridView.Size = new System.Drawing.Size(966, 374);
            this.matchupDataGridView.TabIndex = 0;
            // 
            // teams
            // 
            this.teams.Controls.Add(this.goalieDataGridView);
            this.teams.Controls.Add(this.label3);
            this.teams.Controls.Add(this.label2);
            this.teams.Controls.Add(this.label1);
            this.teams.Controls.Add(this.teamComboBox);
            this.teams.Controls.Add(this.SkaterDataGridView);
            this.teams.Location = new System.Drawing.Point(4, 25);
            this.teams.Margin = new System.Windows.Forms.Padding(4);
            this.teams.Name = "teams";
            this.teams.Padding = new System.Windows.Forms.Padding(4);
            this.teams.Size = new System.Drawing.Size(974, 382);
            this.teams.TabIndex = 2;
            this.teams.Text = "Teams";
            this.teams.UseVisualStyleBackColor = true;
            // 
            // goalieDataGridView
            // 
            this.goalieDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.goalieDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.goalieDataGridView.Location = new System.Drawing.Point(3, 189);
            this.goalieDataGridView.Name = "goalieDataGridView";
            this.goalieDataGridView.ReadOnly = true;
            this.goalieDataGridView.RowTemplate.Height = 24;
            this.goalieDataGridView.Size = new System.Drawing.Size(968, 190);
            this.goalieDataGridView.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Goalies";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Skaters";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(846, 18);
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
            this.teamComboBox.Location = new System.Drawing.Point(846, 38);
            this.teamComboBox.Name = "teamComboBox";
            this.teamComboBox.Size = new System.Drawing.Size(121, 24);
            this.teamComboBox.TabIndex = 1;
            this.teamComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // SkaterDataGridView
            // 
            this.SkaterDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SkaterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SkaterDataGridView.Location = new System.Drawing.Point(3, 78);
            this.SkaterDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.SkaterDataGridView.Name = "SkaterDataGridView";
            this.SkaterDataGridView.ReadOnly = true;
            this.SkaterDataGridView.Size = new System.Drawing.Size(968, 87);
            this.SkaterDataGridView.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.leagueName);
            this.panel1.Controls.Add(this.appName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 44);
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
            ((System.ComponentModel.ISupportInitialize)(this.goalieDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkaterDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}

