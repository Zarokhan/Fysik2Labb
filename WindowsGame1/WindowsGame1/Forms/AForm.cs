using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsGame1.States.AllStates;

namespace WindowsGame1.Forms
{
    partial class AForm : Form
    {
        private Game1 game;

        public AForm(Game1 game)
        {
            this.game = game;
            InitializeComponent();
        }

        // X textbox
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        // Y textbox
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        // Angle textbox
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        // Force textbox
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SetValues()
        {
            game.states.a.boll.pos.X = int.Parse(textBox1.Text);
            game.states.a.boll.pos.Y = (Game1.height/Astate.pixelPerMeter) - int.Parse(textBox2.Text);
            game.states.a.boll.angle = (float)MathHelper.ToRadians(int.Parse(textBox3.Text));
            game.states.a.boll.rotation = game.states.a.boll.angle;
            game.states.a.boll.speed = int.Parse(textBox4.Text);
        }

        // Set values button
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            SetValues();
        }

        // Start button
        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            game.states.a.boll.Start();
        }
        // Reset button
        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            game.states.a.boll.Reset();
            SetValues();
        }
    }
}
