using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame1.Physics.Shapes;
using WindowsGame1.Utilities;

namespace WindowsGame1.States.AllStates
{
    class Astate : AbstractState
    {
        public const int pixelPerMeter = 50;

        public Boll boll { get; set; }

        public Astate(Game1 game) : base(game)
        {
            boll = new Boll(game);

            boll.pos.X = 10;
            boll.pos.Y = 7;
        }

        public override void Update(float delta)
        {
            boll.Update(delta);
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.DrawString(game.res.font, "Pixels per meter: " + Astate.pixelPerMeter, new Vector2(20, 20), Color.White);
            boll.Draw(batch);
        }
    }
}
