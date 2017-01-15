using System;
using System.Drawing;
using System.Windows.Forms;

namespace Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillStandings();
            FillMatchUps();
            FillSkaters();

            FillStandingsWithDummyData();
        }

        private void FillStandings()
        {
            standingsGridView.ColumnCount = 7;
            standingsGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            standingsGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            standingsGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            standingsGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            standingsGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            standingsGridView.GridColor = Color.Black;
            standingsGridView.RowHeadersVisible = false;
            standingsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            standingsGridView.MultiSelect = false;

            standingsGridView.Columns[0].Name = "Rank";
            standingsGridView.Columns[1].Name = "Team Name";
            standingsGridView.Columns[2].Name = "Wins";
            standingsGridView.Columns[3].Name = "Losses";
            standingsGridView.Columns[4].Name = "Ties";
            standingsGridView.Columns[5].Name = "Points For";
            standingsGridView.Columns[6].Name = "Points Against";

            //TODO actually fill the data in
        }

        private void FillMatchUps()
        {
            matchupGridView.ColumnCount = 5;
            matchupGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            matchupGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            matchupGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            matchupGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            matchupGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            matchupGridView.GridColor = Color.Black;
            matchupGridView.RowHeadersVisible = false;
            matchupGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            matchupGridView.MultiSelect = false;

            matchupGridView.Columns[0].Name = "Team Name";
            matchupGridView.Columns[1].Name = "Score";
            matchupGridView.Columns[2].Name = "-";
            matchupGridView.Columns[3].Name = "Score";
            matchupGridView.Columns[4].Name = "Team Name";

            //TODO fill matchups
        }

        private void FillSkaters()
        {
            teamPlayerGridView.ColumnCount = 6;
            teamPlayerGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            teamPlayerGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            teamPlayerGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            teamPlayerGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            teamPlayerGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            teamPlayerGridView.GridColor = Color.Black;
            teamPlayerGridView.RowHeadersVisible = false;
            teamPlayerGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            teamPlayerGridView.MultiSelect = false;

            teamPlayerGridView.Columns[0].Name = "First Name";
            teamPlayerGridView.Columns[1].Name = "Last Name";
            teamPlayerGridView.Columns[2].Name = "NHL Team";
            teamPlayerGridView.Columns[3].Name = "Uniform Number";
            teamPlayerGridView.Columns[4].Name = "Position";
            teamPlayerGridView.Columns[5].Name = "stats";
        }

        private void FillStandingsWithDummyData()
        {
            object[] row0 = { "1", "Team1", "11", "1", "0", "2000", "0" };
            object[] row1 = { "2", "Team2", "10", "2", "0", "1900", "100" };
            object[] row2 = { "3", "Team3", "9", "3", "0", "1800", "200" };
            object[] row3 = { "4", "Team4", "8", "4", "0", "1700", "300" };
            object[] row4 = { "5", "Team5", "7", "5", "0", "1600", "400" };
            object[] row5 = { "6", "Team6", "6", "6", "0", "1500", "500" };

            standingsGridView.Rows.Add(row0);
            standingsGridView.Rows.Add(row1);
            standingsGridView.Rows.Add(row2);
            standingsGridView.Rows.Add(row3);
            standingsGridView.Rows.Add(row4);
            standingsGridView.Rows.Add(row5);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
