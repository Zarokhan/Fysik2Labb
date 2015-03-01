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
    partial class CForm : Form
    {
        Game1 game;

        public CForm(Game1 game)
        {
            this.game = game;
            InitializeComponent();
        }

        // Radie textbox
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Friktionskoefficienten textbox
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        // Hastighet textbox
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Set button
        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            game.states.c.SetValues(int.Parse(textBox1.Text), float.Parse(textBox2.Text, CultureInfo.InvariantCulture.NumberFormat), int.Parse(textBox3.Text));
        }

        // Activate button
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            game.states.c.Activate = true;
        }

        // Reset button
        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            game.states.c.Reset();
        }


    }
}
