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
    class Bstate : AbstractState
    {
        public const int pixelPerMeter = 25;

        private DrawObject ramp;
        private float angle;
        private Box box;

        private Vector2 start = Vector2.Zero, end = Vector2.Zero;
        private Vector2 direction = Vector2.Zero;

        // kinetisk
        private float friktionskoefficienten { get; set; }
        private float friktionskraften;
        private float ma;

        public bool active { get; set; }

        public Bstate(Game1 game)
            : base(game)
        {
            angle = (float)MathHelper.ToRadians(31);
            
            box = new Box(game.res);
            box.Rotation = angle;
            // Calculate normalkraften
            box.Fn.X = (float)(box.Fg * Math.Sin(angle));
            box.Fn.Y = (float)(box.Fg * Math.Cos(angle));

            ramp = new DrawObject(game.res.ramp);
            ramp.pos = new Vector2(250, Game1.height - 150);

            start = new Vector2(ramp.pos.X - ramp.origin.X + box.origin.X / 4, ramp.pos.Y - ramp.origin.Y - box.origin.Y);
            start = start / pixelPerMeter;
            end = new Vector2(ramp.pos.X + ramp.origin.X + box.origin.X / 4, ramp.pos.Y + ramp.origin.Y - box.origin.Y);
            end = end / pixelPerMeter;
            direction = end - start;
            direction.Normalize();

            box.pos = new Vector2(start.X, start.Y);

            SetFriktionskoefficienten(0.45f);
        }

        public void Reset()
        {
            active = false;
            this.box.acceleration = 0;
            this.box.hastighet = 0;
            this.box.pos = new Vector2(start.X, start.Y);
            SetFriktionskoefficienten(friktionskoefficienten);
        }

        public void SetFriktionskoefficienten(float tal)
        {
            this.friktionskoefficienten = tal;
            friktionskraften = friktionskoefficienten * box.Fn.Y;
            ma = box.Fn.X - friktionskraften;
            box.acceleration = (ma * 9.82f) / box.Fg;

            if (box.acceleration < 0)
                box.acceleration = 0;
        }

        public override void Update(float delta)
        {
            if (active)
            {
                box.hastighet += box.acceleration * delta;

                box.pos.X += direction.X * box.hastighet * delta;
                box.pos.Y += direction.Y * box.hastighet * delta;
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            ramp.Draw(batch);
            box.Draw(batch);

            // Renders text
            batch.DrawString(game.res.font, "Pixels per meter: " + Bstate.pixelPerMeter + "     Box V: " + box.hastighet + " m/s     Box A: " + box.acceleration + " m/s2", Vector2.Zero, Color.White);
        }
    }
}
