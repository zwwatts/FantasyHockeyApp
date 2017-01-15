using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillTeamsWithDummyData();
        }

        private void FillTeamsWithDummyData()
        {
            standingsGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            standingsGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            standingsGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            standingsGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            standingsGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            standingsGridView.GridColor = Color.Black;
            standingsGridView.RowHeadersVisible = false;

            standingsGridView.Columns[0].Name = "Rank";
            standingsGridView.Columns[1].Name = "Team Name";
            standingsGridView.Columns[2].Name = "Wins";
            standingsGridView.Columns[3].Name = "Losses";
            standingsGridView.Columns[4].Name = "Ties";
            standingsGridView.Columns[5].Name = "Points For";
            standingsGridView.Columns[6].Name = "Points Against";

            standingsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            standingsGridView.MultiSelect = false;

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
    }
}
