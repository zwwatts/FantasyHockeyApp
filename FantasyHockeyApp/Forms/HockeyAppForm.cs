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
            
            leagueName.Text = _businessLayer.GetLeagueInfo()?.LeagueName;
            SetUpDataGridViews();
            FillStandings();
            FillTeamSelectionDropDown();
            FillMatchUps();
            var initialTeamToDisplay = _businessLayer?.GetTeams()?.FirstOrDefault()?.TeamId ?? 0;
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

            
            var skaterColumnNames = _businessLayer.GetSkaterStatColumnHeaders();
            var goalieColumnNames = _businessLayer.GetGoalieStatColumnHeaders();
            if (skaterColumnNames == null || goalieColumnNames == null) return;

            //Skaters
            SkaterDataGridView.ColumnCount = 5 + skaterColumnNames.Count;
            SkaterDataGridView.Columns[0].Name = "First Name";
            SkaterDataGridView.Columns[1].Name = "Last Name";
            SkaterDataGridView.Columns[2].Name = "NHL Team";
            SkaterDataGridView.Columns[3].Name = "Uniform Number";
            SkaterDataGridView.Columns[4].Name = "Position";

            var i = 5;
            foreach (var colName in skaterColumnNames)
            {
                SkaterDataGridView.Columns[i].Name = colName;
                i++;
            }

            //Goalies
            goalieDataGridView.ColumnCount = 5 + goalieColumnNames.Count;
            goalieDataGridView.Columns[0].Name = "First Name";
            goalieDataGridView.Columns[1].Name = "Last Name";
            goalieDataGridView.Columns[2].Name = "NHL Team";
            goalieDataGridView.Columns[3].Name = "Uniform Number";
            goalieDataGridView.Columns[4].Name = "Position";

            i = 5;
            foreach (var colName in goalieColumnNames)
            {
                goalieDataGridView.Columns[i].Name = colName;
                i++;
            }
        }

        private void FillStandings()
        {
            standingsDataGridView.Rows.Clear();
            var teamsList = _businessLayer.GetTeams();
            if (teamsList == null) return;
            foreach (var team in teamsList)
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
            var matchupList = _businessLayer.GetWeeklyMatchups();
            if (matchupList == null) return;
            foreach (var matchup in matchupList)
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
            var skaters = _businessLayer.GetTeam(team)?.Skaters;
            if(skaters == null) return;
            foreach (var player in skaters)
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
                SkaterDataGridView.Rows.Add(dataRow.ToArray<object>());
            }
        }

        private void FillGoalies(int team)
        {
            goalieDataGridView.Rows.Clear();
            var goalies = _businessLayer.GetTeam(team)?.Goalies;
            if (goalies == null) return;
            foreach (var player in goalies)
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

                goalieDataGridView.Rows.Add(dataRow.ToArray<object>());
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
            var teamId = teamBox.SelectedValue;
            if (teamId == null) return;

            FillSkaters((int)teamId);
            FillGoalies((int)teamId);
        }

        private void leagueIDSubmit_Click(object sender, EventArgs e) => _businessLayer.SetLeagueId((int)leagueIDNumeric.Value);
    }
}
