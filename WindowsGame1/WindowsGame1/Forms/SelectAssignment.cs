using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsGame1.Fönster
{
    partial class SelectAssignment : Form
    {
        private Game1 game;

        public SelectAssignment(Game1 game)
        {
            this.game = game;
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        // Button A
        private void button1_Click(object sender, EventArgs e)
        {
            game.states.ChangeState(States.StateManager.State.A);
            this.Close();
        }
        // Button B
        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            game.states.ChangeState(States.StateManager.State.B);
            this.Close();
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            game.states.ChangeState(States.StateManager.State.C);
            this.Close();
        }
    }
}
