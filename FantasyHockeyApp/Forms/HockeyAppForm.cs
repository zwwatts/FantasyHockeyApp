using System;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;

namespace Forms
{
    public partial class HockeyAppForm : Form
    {
        private readonly LeagueBusinessLayer _businessLayer;

        public HockeyAppForm()
        {
            InitializeComponent();

             _businessLayer = new LeagueBusinessLayer(22381);

            leagueName.Text = _businessLayer.GetLeagueInfo().LeagueName;

            SetUpDataGridViews();
            //FillStandings();
            FillMatchUps();
            FillSkaters();
            FillGoalies();

            //FillStandingsWithDummyData();
        }

        private void SetUpDataGridViews()
        {
            //Standings
            standingsDataGridView.ColumnCount = 7;
            standingsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            standingsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            standingsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            standingsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            standingsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            standingsDataGridView.GridColor = Color.Black;
            standingsDataGridView.RowHeadersVisible = false;
            standingsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            standingsDataGridView.MultiSelect = false;
            
            standingsDataGridView.Columns[0].Name = "Rank";
            standingsDataGridView.Columns[1].Name = "Team Name";
            standingsDataGridView.Columns[2].Name = "Wins";
            standingsDataGridView.Columns[3].Name = "Losses";
            standingsDataGridView.Columns[4].Name = "Ties";
            standingsDataGridView.Columns[5].Name = "Points For";
            standingsDataGridView.Columns[6].Name = "Points Against";

            //Match Ups
            matchupDataGridView.ColumnCount = 5;
            matchupDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            matchupDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            matchupDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            matchupDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            matchupDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            matchupDataGridView.GridColor = Color.Black;
            matchupDataGridView.RowHeadersVisible = false;
            matchupDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            matchupDataGridView.MultiSelect = false;

            matchupDataGridView.Columns[0].Name = "Team Name";
            matchupDataGridView.Columns[1].Name = "Score";
            matchupDataGridView.Columns[2].Name = "-";
            matchupDataGridView.Columns[3].Name = "Score";
            matchupDataGridView.Columns[4].Name = "Team Name";

            //Skaters
            SkaterDataGridView.ColumnCount = 6;
            SkaterDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            SkaterDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            SkaterDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            SkaterDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            SkaterDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            SkaterDataGridView.GridColor = Color.Black;
            SkaterDataGridView.RowHeadersVisible = false;
            SkaterDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SkaterDataGridView.MultiSelect = false;

            SkaterDataGridView.Columns[0].Name = "First Name";
            SkaterDataGridView.Columns[1].Name = "Last Name";
            SkaterDataGridView.Columns[2].Name = "NHL Team";
            SkaterDataGridView.Columns[3].Name = "Uniform Number";
            SkaterDataGridView.Columns[4].Name = "Position";
            SkaterDataGridView.Columns[5].Name = "stats";

            //Goalies
            goalieDataGridView.ColumnCount = 6;
            goalieDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            goalieDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            goalieDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            goalieDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            goalieDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            goalieDataGridView.GridColor = Color.Black;
            goalieDataGridView.RowHeadersVisible = false;
            goalieDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            goalieDataGridView.MultiSelect = false;

            goalieDataGridView.Columns[0].Name = "First Name";
            goalieDataGridView.Columns[1].Name = "Last Name";
            goalieDataGridView.Columns[2].Name = "NHL Team";
            goalieDataGridView.Columns[3].Name = "Uniform Number";
            goalieDataGridView.Columns[4].Name = "Position";
            goalieDataGridView.Columns[5].Name = "stats";
        }

        private void FillStandings()
        {
            foreach(var team in _businessLayer.GetTeams())
            {
                object[] row = {
                    team.Standings.Rank,
                    team.Name,
                    team.Standings.Wins,
                    team.Standings.Losses,
                    team.Standings.Ties,
                    team.Standings.PointsFor,
                    team.Standings.PointsAgainst
                };

                standingsDataGridView.Rows.Add(row);
            }

        }

        private void FillMatchUps()
        {
           
        }

        private void FillSkaters()
        {
           
        }

        private void FillGoalies()
        {
            
        }

        private void FillStandingsWithDummyData()
        {
            object[] row0 = { "1", "Team1", "11", "1", "0", "2000", "0" };
            object[] row1 = { "2", "Team2", "10", "2", "0", "1900", "100" };
            object[] row2 = { "3", "Team3", "9", "3", "0", "1800", "200" };
            object[] row3 = { "4", "Team4", "8", "4", "0", "1700", "300" };
            object[] row4 = { "5", "Team5", "7", "5", "0", "1600", "400" };
            object[] row5 = { "6", "Team6", "6", "6", "0", "1500", "500" };

            standingsDataGridView.Rows.Add(row0);
            standingsDataGridView.Rows.Add(row1);
            standingsDataGridView.Rows.Add(row2);
            standingsDataGridView.Rows.Add(row3);
            standingsDataGridView.Rows.Add(row4);
            standingsDataGridView.Rows.Add(row5);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
