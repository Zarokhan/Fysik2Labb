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

        private bool negative = false;
        private float angle;
        public Circle2B boll { get; set; }
        private int currentStage;

        private Vector2 p1, p2, p3, p4, p5;
        private float lenght, distance;
        private Vector2 direction = Vector2.Zero;

        // kinetisk
        private float friktionskoefficienten { get; set; }
        private float friktionskraften;
        private float ma;

        public bool active { get; set; }

        public Bstate(Game1 game)
            : base(game)
        {
            
            boll = new Circle2B(game.res);
            boll.Rotation = angle;

            p1 = new Vector2(1, 7);
            p2 = new Vector2(2, 7);
            p3 = new Vector2(11, 14);
            p4 = new Vector2(16, 14);
            p5 = new Vector2(23 * 1.25f, 0);

            Init();
        }

        private void Init()
        {
            currentStage = 0;
            lenght = 0;
            direction = new Vector2(p2.X - p1.X, p2.Y - p1.Y);
            distance = Vector2.Distance(p1, p2);
            direction.Normalize();
            angle = (float)Math.Atan2(p2.Y - p1.Y, p2.X - p1.X);
            boll.pos = new Vector2(p1.X, p1.Y);
        }

        public void Reset()
        {
            active = false;
            negative = false;
            this.boll.acceleration = 0;
            this.boll.hastighet = 0;
            Init();
            SetFriktionskoefficienten(friktionskoefficienten);
        }

        public void SetFriktionskoefficienten(float tal)
        {
            // Calculate normalkraften
            boll.Fn.X = (float)(boll.Fg * Math.Sin(angle));
            boll.Fn.Y = (float)(boll.Fg * Math.Cos(angle));
            this.friktionskoefficienten = tal;
            friktionskraften = friktionskoefficienten * boll.Fn.Y;
            ma = boll.Fn.X - friktionskraften;
            boll.acceleration = (ma * 9.82f) / boll.Fg;
        }

        public override void Update(float delta)
        {
            if (active)
            {
                boll.hastighet += boll.acceleration * delta;

                boll.pos.X += direction.X * boll.hastighet * delta;
                boll.pos.Y += direction.Y * boll.hastighet * delta;

                if (currentStage == 0 || currentStage == 2)
                {
                    if (!negative)
                    {
                        if (boll.hastighet < 0)
                        {
                            boll.acceleration = 0;
                            boll.hastighet = 0;
                        }
                    }
                }

                lenght += boll.hastighet * delta;
                if (lenght > distance || lenght < 0)
                {
                    if (lenght > distance)
                    {
                        currentStage++;
                    }
                    if (lenght > distance && negative)
                    {
                        negative = false;
                    }
                    if (lenght < 0)
                    {
                        currentStage--;
                        negative = true;
                    }
                    switch (currentStage)
                    {
                        case 0:
                            direction = new Vector2(p2.X - p1.X, p2.Y - p1.Y);
                            distance = Vector2.Distance(p1, p2);
                            direction.Normalize();
                            if(!negative)
                                angle = (float)Math.Atan2(p2.Y - p1.Y, p2.X - p1.X);
                            else
                                angle = (float)Math.Atan2(p1.Y - p2.Y, p1.X - p2.X);
                            SetFriktionskoefficienten(friktionskoefficienten);
                            lenght = 0;
                            break;
                        case 1:
                            if(!negative)
                                angle = (float)Math.Atan2(p3.Y - p2.Y, p3.X - p2.X);
                            else
                                angle = (float)Math.Atan2(p2.Y - p5.Y, p2.X - p5.X);
                            SetFriktionskoefficienten(friktionskoefficienten);
                            direction = new Vector2(p3.X - p2.X, p3.Y - p2.Y);
                            distance = Vector2.Distance(p2, p3);
                            direction.Normalize();
                            lenght = 0;
                            break;
                        case 2:
                            if(!negative)
                                angle = (float)Math.Atan2(p4.Y - p3.Y, p4.X - p3.X);
                            else
                                angle = (float)Math.Atan2(p3.Y - p4.Y, p3.X - p4.X);
                            SetFriktionskoefficienten(friktionskoefficienten);
                            direction = new Vector2(p4.X - p3.X, p4.Y - p3.Y);
                            distance = Vector2.Distance(p3, p4);
                            direction.Normalize();
                            lenght = 0;
                            break;
                        case 3:
                            if(!negative)
                                angle = (float)Math.Atan2(p5.Y - p4.Y, p5.X - p4.X);
                            else
                                angle = (float)Math.Atan2(p4.Y - p5.Y, p4.X - p5.X);
                            SetFriktionskoefficienten(friktionskoefficienten);
                            direction = new Vector2(p5.X - p4.X, p5.Y - p4.Y);
                            distance = Vector2.Distance(p4, p5);
                            direction.Normalize();
                            lenght = 0;
                            break;
                    }
                    if (negative)
                    {
                        switch (currentStage)
                        {
                            case 0:
                                lenght = distance = Vector2.Distance(p1, p2);
                                break;
                            case 1:
                                lenght = distance = Vector2.Distance(p2, p3);
                                break;
                            case 2:
                                lenght = distance = Vector2.Distance(p3, p4);
                                break;
                            case 3:
                                lenght = distance = Vector2.Distance(p4, p5);
                                break;
                        }
                    }
                }
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(game.res.bana, new Vector2(0, 0), Color.White);
            boll.Draw(batch);

            // Renders text
            batch.DrawString(game.res.font, "Pixels per meter: " + Bstate.pixelPerMeter + "     Box V: " + boll.hastighet + " m/s     Box A: " + boll.acceleration + " m/s2", Vector2.Zero, Color.White);
        }
    }
}
