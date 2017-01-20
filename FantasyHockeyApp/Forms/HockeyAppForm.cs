using System;
using System.Diagnostics;
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
            FillStandings();
            FillTeamSelectionDropDown();

            //FillStandingsWithDummyData();
        }

        private void SetUpDataGridViews()
        {
            //Standings
            standingsDataGridView.ColumnCount = 7;
            standingsDataGridView.Columns[0].Name = "Rank";
            standingsDataGridView.Columns[1].Name = "Team Name";
            standingsDataGridView.Columns[2].Name = "Wins";
            standingsDataGridView.Columns[3].Name = "Losses";
            standingsDataGridView.Columns[4].Name = "Ties";
            standingsDataGridView.Columns[5].Name = "Points For";
            standingsDataGridView.Columns[6].Name = "Points Against";

            //Match Ups
            matchupDataGridView.ColumnCount = 5;
            matchupDataGridView.Columns[0].Name = "Team Name";
            matchupDataGridView.Columns[1].Name = "Score";
            matchupDataGridView.Columns[2].Name = "-";
            matchupDataGridView.Columns[3].Name = "Score";
            matchupDataGridView.Columns[4].Name = "Team Name";

            //Skaters
            SkaterDataGridView.ColumnCount = 6;
            SkaterDataGridView.Columns[0].Name = "First Name";
            SkaterDataGridView.Columns[1].Name = "Last Name";
            SkaterDataGridView.Columns[2].Name = "NHL Team";
            SkaterDataGridView.Columns[3].Name = "Uniform Number";
            SkaterDataGridView.Columns[4].Name = "Position";
            SkaterDataGridView.Columns[5].Name = "stats"; 

            //Goalies
            goalieDataGridView.ColumnCount = 6;
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
            //foreach (var matchup in _businessLayer.GetMatchups())
            //{
            //    object[] row = {
            //        matchup.Teams[0].Name,
            //        matchup.Teams[0].WeekScore,
            //        "vs",
            //        matchup.Teams[1].WeekScore,
            //        matchup.Teams[1].Name
            //    };
                
            //    matchupDataGridView.Rows.Add(row);
            //}
        }

        private void FillSkaters(int team)
        {
            SkaterDataGridView.Rows.Clear();
            foreach (var player in _businessLayer.GetTeam(team).Skaters)
            {
                object[] row =
                {
                    player.FirstName,
                    player.LastName,
                    player.EditorialTeamName,
                    player.UniformNumber,
                    player.Position,
                    "Stats"
                };

                SkaterDataGridView.Rows.Add(row);
            }
        }

        private void FillGoalies(int team)
        {
            goalieDataGridView.Rows.Clear();
            foreach (var player in _businessLayer.GetTeam(team).Goalies)
            {
                object[] row =
                {
                    player.FirstName,
                    player.LastName,
                    player.EditorialTeamName,
                    player.UniformNumber,
                    player.Position,
                    "Stats"
                };

                goalieDataGridView.Rows.Add(row);
            }
        }

        private void FillTeamSelectionDropDown()
        {
            teamComboBox.DataSource = _businessLayer.GetTeams();
            teamComboBox.DisplayMember = "Name";
            teamComboBox.ValueMember = "TeamId";
            teamComboBox.SelectedIndexChanged += teamComboBoxEventHandler; 
        }

        private void teamComboBoxEventHandler(object sender, EventArgs e)
        {
            var teamBox = (ComboBox) sender;
            var teamId = (int) teamBox.SelectedValue;

            Debug.WriteLine(teamBox.SelectedValue);
            FillSkaters(teamId);
            FillGoalies(teamId);
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
    }
}
