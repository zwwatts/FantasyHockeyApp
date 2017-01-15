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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.teamComboBox = new System.Windows.Forms.ComboBox();
            this.teamPlayerGridView = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.Standings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.standingsGridView)).BeginInit();
            this.Matchups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchupGridView)).BeginInit();
            this.Teams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamPlayerGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // appName
            // 
            this.appName.Dock = System.Windows.Forms.DockStyle.Top;
            this.appName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appName.Location = new System.Drawing.Point(0, 0);
            this.appName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.appName.Name = "appName";
            this.appName.Size = new System.Drawing.Size(791, 27);
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
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(791, 418);
            this.tabControl1.TabIndex = 1;
            // 
            // Standings
            // 
            this.Standings.Controls.Add(this.standingsGridView);
            this.Standings.Location = new System.Drawing.Point(4, 25);
            this.Standings.Margin = new System.Windows.Forms.Padding(4);
            this.Standings.Name = "Standings";
            this.Standings.Padding = new System.Windows.Forms.Padding(4);
            this.Standings.Size = new System.Drawing.Size(1020, 437);
            this.Standings.TabIndex = 0;
            this.Standings.Text = "Standings";
            this.Standings.UseVisualStyleBackColor = true;
            // 
            // standingsGridView
            // 
            this.standingsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.standingsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.standingsGridView.Location = new System.Drawing.Point(4, 4);
            this.standingsGridView.Margin = new System.Windows.Forms.Padding(4);
            this.standingsGridView.Name = "standingsGridView";
            this.standingsGridView.ReadOnly = true;
            this.standingsGridView.Size = new System.Drawing.Size(1012, 429);
            this.standingsGridView.TabIndex = 0;
            // 
            // Matchups
            // 
            this.Matchups.Controls.Add(this.matchupGridView);
            this.Matchups.Location = new System.Drawing.Point(4, 25);
            this.Matchups.Margin = new System.Windows.Forms.Padding(4);
            this.Matchups.Name = "Matchups";
            this.Matchups.Padding = new System.Windows.Forms.Padding(4);
            this.Matchups.Size = new System.Drawing.Size(1020, 437);
            this.Matchups.TabIndex = 1;
            this.Matchups.Text = "Matchups";
            this.Matchups.UseVisualStyleBackColor = true;
            // 
            // matchupGridView
            // 
            this.matchupGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matchupGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matchupGridView.Location = new System.Drawing.Point(4, 4);
            this.matchupGridView.Margin = new System.Windows.Forms.Padding(4);
            this.matchupGridView.Name = "matchupGridView";
            this.matchupGridView.ReadOnly = true;
            this.matchupGridView.Size = new System.Drawing.Size(1012, 429);
            this.matchupGridView.TabIndex = 0;
            // 
            // Teams
            // 
            this.Teams.Controls.Add(this.dataGridView1);
            this.Teams.Controls.Add(this.label3);
            this.Teams.Controls.Add(this.label2);
            this.Teams.Controls.Add(this.label1);
            this.Teams.Controls.Add(this.teamComboBox);
            this.Teams.Controls.Add(this.teamPlayerGridView);
            this.Teams.Location = new System.Drawing.Point(4, 25);
            this.Teams.Margin = new System.Windows.Forms.Padding(4);
            this.Teams.Name = "Teams";
            this.Teams.Padding = new System.Windows.Forms.Padding(4);
            this.Teams.Size = new System.Drawing.Size(783, 389);
            this.Teams.TabIndex = 2;
            this.Teams.Text = "Teams";
            this.Teams.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 196);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(777, 190);
            this.dataGridView1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 176);
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
            this.label1.Location = new System.Drawing.Point(655, 18);
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
            this.teamComboBox.Location = new System.Drawing.Point(655, 38);
            this.teamComboBox.Name = "teamComboBox";
            this.teamComboBox.Size = new System.Drawing.Size(121, 24);
            this.teamComboBox.TabIndex = 1;
            this.teamComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // teamPlayerGridView
            // 
            this.teamPlayerGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teamPlayerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teamPlayerGridView.Location = new System.Drawing.Point(3, 78);
            this.teamPlayerGridView.Margin = new System.Windows.Forms.Padding(4);
            this.teamPlayerGridView.Name = "teamPlayerGridView";
            this.teamPlayerGridView.ReadOnly = true;
            this.teamPlayerGridView.Size = new System.Drawing.Size(777, 94);
            this.teamPlayerGridView.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 445);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.appName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.Standings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.standingsGridView)).EndInit();
            this.Matchups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.matchupGridView)).EndInit();
            this.Teams.ResumeLayout(false);
            this.Teams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamPlayerGridView)).EndInit();
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
        private System.Windows.Forms.DataGridView teamPlayerGridView;
        private System.Windows.Forms.ComboBox teamComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

