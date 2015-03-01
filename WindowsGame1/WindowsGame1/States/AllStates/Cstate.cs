using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame1.Utilities;

namespace WindowsGame1.States.AllStates
{
    class Cstate : AbstractState
    {
        private DrawObject car;

        private Vector2 centerPos;
        private float radie, omkrets, cirkelHastighetOffset, time, endTime, startRad, endRad, velocity, totaltime;
        private float friktionskoefficienten { get; set; }

        // Högsta tillåtna fart
        private float Vmax;

        public bool Activate { get; set; }

        private float warningTimer;

        private const int pixelPerMeter = 25;

        public Cstate(Game1 game)
            : base(game)
        {
            car = new DrawObject(game.res.car);
            centerPos = new Vector2(0, Game1.height/2);
            centerPos = centerPos / pixelPerMeter;

            this.SetValues(5, 0.8f, 1);
        }

        public void Reset()
        {
            Activate = false;
            car.pos = new Vector2(centerPos.X, centerPos.Y - this.radie);
            time = startRad / cirkelHastighetOffset;
        }

        public void SetValues(float radie, float friktionskoefficienten, float velocity)
        {
            this.radie = radie;
            this.friktionskoefficienten = friktionskoefficienten;
            this.velocity = velocity;

            car.pos = new Vector2(centerPos.X, centerPos.Y - this.radie);
            Vmax = (float)Math.Sqrt(this.friktionskoefficienten * 9.82f * this.radie);
            //Vmax = Vmax * pixelPerMeter;

            startRad = (float)MathHelper.ToRadians(270);
            endRad = (float)MathHelper.ToRadians(360);

            omkrets = 2 * (float)Math.PI * this.radie;
            cirkelHastighetOffset = (2 * (float)Math.PI) / (omkrets / this.velocity);
            time = startRad / cirkelHastighetOffset;
            endTime = endRad / cirkelHastighetOffset;
            totaltime = ((2 * (float)Math.PI) / cirkelHastighetOffset);
        }

        public override void Update(float delta)
        {
            car.Rotation = cirkelHastighetOffset * time + MathHelper.ToRadians(90);
            if (warningTimer > 0)
                warningTimer -= delta;

            if (Activate)
            {
                if (velocity > Vmax)
                {
                    Activate = false;
                    warningTimer = 5f;
                }

                if (time < endTime)
                {
                    time += delta;
                    car.pos.X = centerPos.X + radie * (float)Math.Cos(time * cirkelHastighetOffset);
                    car.pos.Y = centerPos.Y + radie * (float)Math.Sin(time * cirkelHastighetOffset);
                }
                else
                {
                    car.pos.Y += radie * delta * cirkelHastighetOffset;
                }
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(car.texture, car.pos * pixelPerMeter, car.sourceRect, car.color, car.rotation, car.origin, car.scale, car.fx, 0);

            // renders text
            batch.DrawString(game.res.font, "Pixels per meter: " + Cstate.pixelPerMeter, new Vector2(20, 20), Color.White);
            //batch.DrawString(game.res.font, "Radie: " + (int)radie * pixelPerMeter + "     Friktionskoefficient: " + friktionskoefficienten, new Vector2(0, 0), Color.White);
            //batch.DrawString(game.res.font, "Bil V: " + (int)velocity + "      V max: " + Vmax, new Vector2(0, game.res.font.MeasureString("X").Y), Color.White);

            if (warningTimer > 0)
            {
                string msg = "Åker av vägen!";
                Vector2 d = game.res.font.MeasureString(msg);
                batch.DrawString(game.res.font, msg, new Vector2((Game1.width - d.X)/2, (Game1.height - d.Y)/2), Color.Red);
            }
        }
    }
}
