using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame1.States.AllStates;

namespace WindowsGame1.States
{
    class StateManager
    {
        public enum State
        {
            None, A, A2
        }

        private Game1 game;
        private State currentState;

        public Astate a { get; set; }
        public A2State a2 { get; set; }

        public StateManager(Game1 game)
        {
            this.game = game;
            currentState = State.None;
            a = new Astate(game);
            a2 = new A2State(game);
        }

        public void ChangeState(State s)
        {
            game.CloseAllForms();
            currentState = s;
            switch (s)
            {
                case State.None:
                    break;
                case State.A:
                    game.aForm = new Forms.AForm(game);
                    game.aForm.Show();
                    break;
                case State.A2:
                    game.a2Form = new Forms.A2Form(game);
                    game.a2Form.Show();
                    break;
            }
        }

        public void Update(float delta)
        {
            switch (currentState)
            {
                case State.None:
                    break;
                case State.A:
                    a.Update(delta);
                    break;
                case State.A2:
                    a2.Update(delta);
                    break;
            }
        }

        public void Draw(SpriteBatch batch)
        {
            switch (currentState)
            {
                case State.None:
                    batch.Draw(game.res.ohm, new Vector2((Game1.width - game.res.ohm.Width)/2, 100), Color.White);
                    string msg = "Select Assignment";
                    Vector2 d = game.res.font.MeasureString(msg);
                    batch.DrawString(game.res.font, msg, new Vector2((Game1.width - d.X)/2, (Game1.height - d.Y)/2), Color.White);

                    break;
                case State.A:
                    a.Draw(batch);
                    break;
                case State.A2:
                    a2.Draw(batch);
                    break;
            }
        }
    }
}
