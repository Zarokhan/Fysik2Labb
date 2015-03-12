using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsGame1.Forms
{
    partial class BForm : Form
    {
        Game1 game;

        public BForm(Game1 game)
        {
            this.game = game;
            InitializeComponent();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        // friktionskoefficienten
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        // Set
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            game.states.b.SetFriktionskoefficienten(float.Parse(textBox1.Text, CultureInfo.InvariantCulture.NumberFormat));
            game.states.b.boll.hastighet = float.Parse(textBox2.Text, CultureInfo.InvariantCulture.NumberFormat);
        }

        // Active
        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            game.states.b.active = true;
        }

        // Reset
        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            game.states.b.Reset();
        }

    }
}
