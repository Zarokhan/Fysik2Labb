using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame1.Physics;
using WindowsGame1.States.AllStates;
using WindowsGame1.Utilities;

namespace WindowsGame1.States.AllStates
{
    class Astate : PhysicsObject
    {
        public const int pixelPerMeter = 50;
        private Game1 game;
        public float gravity { get; set; }
        public int radius = 50;

        private Vector2 startPos = Vector2.Zero;
        private Vector2 velocity = Vector2.Zero;
        private float time;
        private float magnitude;

        public DrawObject vänstervägg;
        public DrawObject högervägg;
        public DrawObject golv;
        public bool active;

        public Astate(Game1 game)
            : base(game.res.boll)
        {
            this.game = game;
            gravity = 9.8f;
            SetRadius(radius);

            vänstervägg = new DrawObject(game.res.dot, Astate.pixelPerMeter, Game1.height - 100, Color.White);
            vänstervägg.pos.X = 1;
            vänstervägg.pos.Y = 8;
            högervägg = new DrawObject(game.res.dot, Astate.pixelPerMeter, Game1.height - 100, Color.White);
            högervägg.pos.X = 28;
            högervägg.pos.Y = 8;
            golv = new DrawObject(game.res.dot, Astate.pixelPerMeter * 40, Astate.pixelPerMeter, Color.Pink);
            golv.pos.X = 21 / 2 + 0.5f;
            golv.pos.Y = 14.5f;
        }

        public void SetRadius(float radie)
        {
            this.width = (int)((radie / texture.Width * 0.5f) * texture.Width);
            this.height = width;
            this.scale = (radie / (texture.Width * 0.5f));
        }

        public void Reset()
        {
            pos = Vector2.Zero;
            active = false;
        }

        public void Start()
        {
            active = true;
            startPos = new Vector2(pos.X, pos.Y);
            velocity.X = speed * (float)Math.Cos(angle);
            time = 0;
            if (speed == 0)
                speed = 0.000001f;
        }

        public void Update(float delta)
        {
            if (active)
            {
                time += delta;

                velocity.Y = speed * (float)Math.Sin(angle) + gravity * ((speed * (float)Math.Cos(angle)) * time) / (speed * (float)Math.Cos(angle));
                magnitude = (float)Math.Sqrt(Math.Pow(velocity.X, 2) + Math.Pow(velocity.Y, 2));
                this.rotation = angle;

                // Check collision for golv
                if (this.pos.Y + radius / Astate.pixelPerMeter + velocity.Y / Astate.pixelPerMeter > golv.pos.Y - golv.origin.Y / Astate.pixelPerMeter)
                {
                    Vector2 p = new Vector2(pos.X + velocity.X, pos.Y - velocity.Y);
                    CalculateHit(p, 0.7f);
                    startPos = new Vector2(pos.X, golv.pos.Y - golv.origin.Y / Astate.pixelPerMeter - radius / Astate.pixelPerMeter - 1f/Astate.pixelPerMeter);
                }
                // Check collision for högervägg
                if (this.pos.X + radius / Astate.pixelPerMeter - velocity.X / Astate.pixelPerMeter > högervägg.pos.X - högervägg.origin.X / Astate.pixelPerMeter)
                {
                    Vector2 p = new Vector2(pos.X - velocity.X, pos.Y + velocity.Y);
                    CalculateHit(p, 0.8f);
                    startPos = new Vector2(högervägg.pos.X - högervägg.origin.X / Astate.pixelPerMeter - radius / Astate.pixelPerMeter - 1f, pos.Y);
                }
                // Check collision for vänstervägg
                if (this.pos.X - radius / Astate.pixelPerMeter - velocity.X / Astate.pixelPerMeter < vänstervägg.pos.X + vänstervägg.origin.X / Astate.pixelPerMeter)
                {
                    Vector2 p = new Vector2(pos.X - velocity.X, pos.Y + velocity.Y);
                    CalculateHit(p, 0.8f);
                    startPos = new Vector2(vänstervägg.pos.X + vänstervägg.origin.X / Astate.pixelPerMeter + radius / Astate.pixelPerMeter + 1f, pos.Y);
                }

                // Update regular position
                pos.X = startPos.X - speed * time * (float)Math.Cos(angle);
                pos.Y = startPos.Y + speed * time * (float)Math.Sin(angle) + (gravity * (time * time)) / 2;
            }
        }

        // p is the future position of the object after the hit
        private void CalculateHit(Vector2 p, float elasticity)
        {
            float deltaX = p.X - pos.X;
            float deltaY = p.Y - pos.Y;
            angle = (float)Math.Atan2(deltaY, deltaX);
            time = 0;
            speed = magnitude * elasticity;
            velocity.X = speed * (float)Math.Cos(angle);
            velocity.Y = -speed * (float)Math.Sin(angle);
        }

        public override void Draw(SpriteBatch batch)
        {
            golv.Draw(batch, Astate.pixelPerMeter);
            vänstervägg.Draw(batch, Astate.pixelPerMeter);
            högervägg.Draw(batch, Astate.pixelPerMeter);
            batch.Draw(texture, pos * Astate.pixelPerMeter, sourceRect, color, rotation, origin, scale, fx, 0);
        }
    }
}
