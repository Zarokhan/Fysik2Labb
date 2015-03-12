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

        public const int pixelPerMeter = 50;

        private float angle;
        private Circle2B boll;
        private int currentStage;

        private Vector2 p1, p2, p3, p4, p5;
        private float lenght, distance;
        private Vector2 direction = Vector2.Zero;

        // kinetisk
        private float friktionskoefficienten { get; set; }
        public float speed { get; set; }
        private float friktionskraften;
        private float ma;

        public bool active { get; set; }

        public Bstate(Game1 game)
            : base(game)
        {
            currentStage = 0;
            angle = (float)MathHelper.ToRadians(31);
            
            boll = new Circle2B(game.res);
            boll.Rotation = angle;
            // Calculate normalkraften
            boll.Fn.X = (float)(boll.Fg * Math.Sin(angle));
            boll.Fn.Y = (float)(boll.Fg * Math.Cos(angle));

            p1 = new Vector2(1, 7);
            p2 = new Vector2(4, 7);
            p3 = new Vector2(15, 14);
            p4 = new Vector2(18, 14);
            p5 = new Vector2(25, 7);

            direction = new Vector2(p2.X - p1.X, p2.Y - p1.Y);
            distance = Vector2.Distance(p1, p2);
            direction.Normalize();
            speed = 2;

            boll.pos = new Vector2(p1.X, p1.Y);

            //SetFriktionskoefficienten(0.45f);
        }

        public void Reset()
        {
            active = false;
            this.boll.acceleration = 0;
            this.boll.hastighet = 0;
            this.boll.pos = new Vector2(p1.X, p1.Y);
            //SetFriktionskoefficienten(friktionskoefficienten);
        }

        public void SetFriktionskoefficienten(float tal)
        {
            this.friktionskoefficienten = tal;
            friktionskraften = friktionskoefficienten * boll.Fn.Y;
            ma = boll.Fn.X - friktionskraften;
            boll.acceleration = (ma * 9.82f) / boll.Fg;

            if (boll.acceleration < 0)
                boll.acceleration = 0;
        }

        public override void Update(float delta)
        {
            if (active)
            {

                boll.pos.X += direction.X * speed * delta;
                boll.pos.Y += direction.Y * speed * delta;
                lenght += speed * delta;
                if (lenght >= distance)
                {
                    currentStage += 1;
                    switch (currentStage)
                    {
                        case 1:
                                direction = new Vector2(p3.X - p2.X, p3.Y - p2.Y);
                                distance = Vector2.Distance(p2, p3);
                                direction.Normalize();
                                lenght = 0;
                            break;
                        case 2:
                                direction = new Vector2(p4.X - p3.X, p4.Y - p3.Y);
                                distance = Vector2.Distance(p3, p4);
                                direction.Normalize();
                                lenght = 0;
                            break;
                        case 3:
                                direction = new Vector2(p5.X - p4.X, p5.Y - p4.Y);
                                distance = Vector2.Distance(p4, p5);
                                direction.Normalize();
                                lenght = 0;
                            break;
                    }
                }
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            boll.Draw(batch);

            // Renders text
            batch.DrawString(game.res.font, "Pixels per meter: " + Bstate.pixelPerMeter + "     Box V: " + boll.hastighet + " m/s     Box A: " + boll.acceleration + " m/s2", Vector2.Zero, Color.White);
        }
    }
}
