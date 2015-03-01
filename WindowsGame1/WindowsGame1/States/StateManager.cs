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
            None, A, B, C
        }

        private Game1 game;
        private State currentState;

        public Astate a { get; set; }
        public Bstate b { get; set; }
        public Cstate c { get; set; }

        public StateManager(Game1 game)
        {
            this.game = game;
            currentState = State.None;
            a = new Astate(game);
            b = new Bstate(game);
            c = new Cstate(game);
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
                case State.B:
                    game.bForm = new Forms.BForm(game);
                    game.bForm.Show();
                    break;
                case State.C:
                    game.cForm = new Forms.CForm(game);
                    game.cForm.Show();
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
                case State.B:
                    b.Update(delta);
                    break;
                case State.C:
                    c.Update(delta);
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
                case State.B:
                    b.Draw(batch);
                    break;
                case State.C:
                    c.Draw(batch);
                    break;
            }
        }
    }
}
