using System;
using System.Collections.Generic;
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
            _businessLayer.LeagueDataUpdated += PopulateUi;
        }

        public void PopulateUi(int leagueId)
        {
            if (InvokeRequired)
            {
                Invoke((Action<int>) PopulateUi, leagueId);
                return;
            }
            
            leagueName.Text = _businessLayer.GetLeagueInfo().LeagueName;
            SetUpDataGridViews();
            FillStandings();
            FillTeamSelectionDropDown();
            FillMatchUps();
            var initialTeamToDisplay = _businessLayer.GetTeams().First().TeamId;
            FillGoalies(initialTeamToDisplay);
            FillSkaters(initialTeamToDisplay);
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
            var columnNames = _businessLayer.GetSkaterStatColumnHeaders();
            
            SkaterDataGridView.ColumnCount = 5 + columnNames.Count;
            SkaterDataGridView.Columns[0].Name = "First Name";
            SkaterDataGridView.Columns[1].Name = "Last Name";
            SkaterDataGridView.Columns[2].Name = "NHL Team";
            SkaterDataGridView.Columns[3].Name = "Uniform Number";
            SkaterDataGridView.Columns[4].Name = "Position";

            var i = 5;
            foreach (var colName in columnNames)
            {
                SkaterDataGridView.Columns[i].Name = colName;
                i++;
            }

            //Goalies
            columnNames = _businessLayer.GetGoalieStatColumnHeaders();
            
            goalieDataGridView.ColumnCount = 5 + columnNames.Count;
            goalieDataGridView.Columns[0].Name = "First Name";
            goalieDataGridView.Columns[1].Name = "Last Name";
            goalieDataGridView.Columns[2].Name = "NHL Team";
            goalieDataGridView.Columns[3].Name = "Uniform Number";
            goalieDataGridView.Columns[4].Name = "Position";

            i = 5;
            foreach (var colName in columnNames)
            {
                goalieDataGridView.Columns[i].Name = colName;
                i++;
            }
        }

        private void FillStandings()
        {
            standingsDataGridView.Rows.Clear();
            foreach (var team in _businessLayer.GetTeams())
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
            matchupDataGridView.Rows.Clear();
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
                var dataRow = new List<string>
                {
                    player.FirstName,
                    player.LastName,
                    player.EditorialTeamName,
                    player.UniformNumber.ToString(),
                    player.Position
                };

                dataRow.AddRange(player.Stats.Select(stat => stat.Quantity.ToString()));
                SkaterDataGridView.Rows.Add(dataRow.ToArray());
            }
        }

        private void FillGoalies(int team)
        {
            goalieDataGridView.Rows.Clear();
            foreach (var player in _businessLayer.GetTeam(team).Goalies)
            {
                var dataRow = new List<string>
                {
                    player.FirstName,
                    player.LastName,
                    player.EditorialTeamName,
                    player.UniformNumber.ToString(),
                    player.Position
                };
                dataRow.AddRange(player.Stats.Select(stat => stat.Quantity.ToString()));

                goalieDataGridView.Rows.Add(dataRow.ToArray());
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

        private void leagueIDSubmit_Click(object sender, EventArgs e) => _businessLayer.SetLeagueId((int)leagueIDNumeric.Value);
    }
}
