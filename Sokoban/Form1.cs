using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();          
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            //Program goes to the MainScreen method upon pressing button
            MainScreen ms = new MainScreen();
            this.Controls.Add(ms);

            playButton.Visible = false;
            titleLabel.Visible = false;
        }
    }
}
