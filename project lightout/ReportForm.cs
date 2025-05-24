using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace endlightout
{
    public partial class ReportForm : Form
    {
        private int totalGames = 0;
        private int solvedGames = 0;
        private int unsolvedGames = 0;

        public ReportForm(int total, int solved, int unsolved)
        {
            
            totalGames = total;
            solvedGames = solved;
            unsolvedGames = unsolved;
            SetupUI();
        }

        private void SetupUI()
        {
            Label totalLabel = new Label
            {
                Text = $"Total Games Played: {totalGames}",
                Location = new Point(20, 20),
                AutoSize = true
            };

            Label solvedLabel = new Label
            {
                Text = $"Solved Games: {solvedGames}",
                Location = new Point(20, 50),
                AutoSize = true
            };

            Label unsolvedLabel = new Label
            {
                Text = $"Unsolved Games: {unsolvedGames}",
                Location = new Point(20, 80),
                AutoSize = true
            };

            this.Controls.Add(totalLabel);
            this.Controls.Add(solvedLabel);
            this.Controls.Add(unsolvedLabel);


        }
    }

}
