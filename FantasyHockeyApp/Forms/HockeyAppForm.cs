using System;
using System.Linq;
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
            FillMatchUps();
            var initialTeamToDisplay = _businessLayer.GetTeams().First().TeamId;
            FillGoalies(initialTeamToDisplay);
            FillSkaters(initialTeamToDisplay);
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
            foreach (var matchup in _businessLayer.GetWeeklyMatchups())
            {
                object[] row = {
                    matchup.Teams[0].Name,
                    matchup.CurrentScore[matchup.Teams[0].TeamId],
                    "vs",
                    matchup.CurrentScore[matchup.Teams[1].TeamId],
                    matchup.Teams[1].Name
                };

                matchupDataGridView.Rows.Add(row);
            }
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

            FillSkaters(teamId);
            FillGoalies(teamId);
        }
    }
}
