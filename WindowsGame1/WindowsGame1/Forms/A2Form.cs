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
    partial class A2Form : Form
    {
        private Game1 game;

        public A2Form(Game1 game)
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

            //Boll 1
            game.states.a2.boll1.pos.X = int.Parse(textBox1.Text);
            game.states.a2.boll1.pos.Y = (Game1.height/A2State.pixelPerMeter) - int.Parse(textBox2.Text);
            game.states.a2.boll1.angle = (float)MathHelper.ToRadians(int.Parse(textBox3.Text));
            game.states.a2.boll1.rotation = game.states.a2.boll1.angle;
            game.states.a2.boll1.speed = int.Parse(textBox4.Text);

            //Boll 2
            game.states.a2.boll2.pos.X = int.Parse(textBox5.Text);
            game.states.a2.boll2.pos.Y = (Game1.height / A2State.pixelPerMeter) - int.Parse(textBox6.Text);
            game.states.a2.boll2.angle = (float)MathHelper.ToRadians(int.Parse(textBox7.Text));
            game.states.a2.boll2.rotation = game.states.a2.boll2.angle;
            game.states.a2.boll2.speed = int.Parse(textBox8.Text);


        }

        // Set values button
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            SetValues();
        }

        // Start button
        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            game.states.a2.Start();
        }
        // Reset button
        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            game.states.a2.Reset();
            SetValues();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
