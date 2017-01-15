namespace Forms
{
    partial class Form1
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
            this.Standings = new System.Windows.Forms.TabPage();
            this.standingsGridView = new System.Windows.Forms.DataGridView();
            this.Matchups = new System.Windows.Forms.TabPage();
            this.matchupGridView = new System.Windows.Forms.DataGridView();
            this.Teams = new System.Windows.Forms.TabPage();
            this.teamGridView = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.Standings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.standingsGridView)).BeginInit();
            this.Matchups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchupGridView)).BeginInit();
            this.Teams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teamGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // appName
            // 
            this.appName.Dock = System.Windows.Forms.DockStyle.Top;
            this.appName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appName.Location = new System.Drawing.Point(0, 0);
            this.appName.Name = "appName";
            this.appName.Size = new System.Drawing.Size(802, 22);
            this.appName.TabIndex = 0;
            this.appName.Text = "Yahoo Fantasy Hockey App";
            this.appName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Standings);
            this.tabControl1.Controls.Add(this.Matchups);
            this.tabControl1.Controls.Add(this.Teams);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(802, 481);
            this.tabControl1.TabIndex = 1;
            // 
            // Standings
            // 
            this.Standings.Controls.Add(this.standingsGridView);
            this.Standings.Location = new System.Drawing.Point(4, 22);
            this.Standings.Name = "Standings";
            this.Standings.Padding = new System.Windows.Forms.Padding(3);
            this.Standings.Size = new System.Drawing.Size(794, 455);
            this.Standings.TabIndex = 0;
            this.Standings.Text = "Standings";
            this.Standings.UseVisualStyleBackColor = true;
            // 
            // standingsGridView
            // 
            this.standingsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.standingsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.standingsGridView.Location = new System.Drawing.Point(3, 3);
            this.standingsGridView.Name = "standingsGridView";
            this.standingsGridView.Size = new System.Drawing.Size(788, 449);
            this.standingsGridView.TabIndex = 0;
            this.standingsGridView.ColumnCount = 7;
            // 
            // Matchups
            // 
            this.Matchups.Controls.Add(this.matchupGridView);
            this.Matchups.Location = new System.Drawing.Point(4, 22);
            this.Matchups.Name = "Matchups";
            this.Matchups.Padding = new System.Windows.Forms.Padding(3);
            this.Matchups.Size = new System.Drawing.Size(794, 455);
            this.Matchups.TabIndex = 1;
            this.Matchups.Text = "Matchups";
            this.Matchups.UseVisualStyleBackColor = true;
            // 
            // matchupGridView
            // 
            this.matchupGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matchupGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matchupGridView.Location = new System.Drawing.Point(3, 3);
            this.matchupGridView.Name = "matchupGridView";
            this.matchupGridView.Size = new System.Drawing.Size(788, 449);
            this.matchupGridView.TabIndex = 0;
            // 
            // Teams
            // 
            this.Teams.Controls.Add(this.teamGridView);
            this.Teams.Location = new System.Drawing.Point(4, 22);
            this.Teams.Name = "Teams";
            this.Teams.Padding = new System.Windows.Forms.Padding(3);
            this.Teams.Size = new System.Drawing.Size(794, 455);
            this.Teams.TabIndex = 2;
            this.Teams.Text = "Teams";
            this.Teams.UseVisualStyleBackColor = true;
            // 
            // teamGridView
            // 
            this.teamGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teamGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teamGridView.Location = new System.Drawing.Point(0, 0);
            this.teamGridView.Name = "teamGridView";
            this.teamGridView.Size = new System.Drawing.Size(794, 455);
            this.teamGridView.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 503);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.appName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.Standings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.standingsGridView)).EndInit();
            this.Matchups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.matchupGridView)).EndInit();
            this.Teams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teamGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label appName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Standings;
        private System.Windows.Forms.TabPage Matchups;
        private System.Windows.Forms.TabPage Teams;
        private System.Windows.Forms.DataGridView standingsGridView;
        private System.Windows.Forms.DataGridView matchupGridView;
        private System.Windows.Forms.DataGridView teamGridView;
    }
}

