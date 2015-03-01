using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.States
{
    abstract class AbstractState
    {
        protected Game1 game;

        public AbstractState(Game1 game)
        {
            this.game = game;
        }

        public abstract void Update(float delta);
        public abstract void Draw(SpriteBatch batch);
    }
}
