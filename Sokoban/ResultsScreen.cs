using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban
{
    public partial class ResultsScreen : UserControl
    {
        public ResultsScreen()
        {
            InitializeComponent();

            winLabel.Text = "Won in " + MainScreen.moveCount + " moves!";
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Form Form1 = this.FindForm();
            Form1.Close();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Form Form1 = this.FindForm();
            Form1.Controls.Remove(this);

            MainScreen ms = new MainScreen();
            Form1.Controls.Add(ms);
        }
    }
}
