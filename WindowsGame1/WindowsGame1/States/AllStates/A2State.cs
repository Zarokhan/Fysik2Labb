using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame1.Physics;
using WindowsGame1.Utilities;

namespace WindowsGame1.States.AllStates
{
    class A2State : AbstractState
    {
        public const int pixelPerMeter = 50;
        public float gravity { get; set; }
        public int radius = 1;

        public DrawObject vänstervägg;
        public DrawObject högervägg;
        public DrawObject golv;
        public bool active;

        public PhysicsObject boll2;
        public PhysicsObject boll1;

        public A2State(Game1 game): base(game)
        {
            boll1 = new PhysicsObject(game.res.boll);
            boll2 = new PhysicsObject(game.res.boll);
            boll1.color = Color.Red;
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
            boll1.width = (int)(((radie / game.res.boll.Width * 0.5f) * game.res.boll.Width)) * pixelPerMeter;
            boll2.width = (int)(((radie / game.res.boll.Width * 0.5f) * game.res.boll.Width)) * pixelPerMeter;
            boll1.height = boll1.width;
            boll2.height = boll1.width;
            boll1.scale = (radie / (game.res.boll.Width * 0.5f)) * pixelPerMeter;
            boll2.scale = (radie / (game.res.boll.Width * 0.5f)) * pixelPerMeter;
        }

        public void Reset()
        {
            boll1.pos = new Vector2(0, 0);
            boll2.pos = new Vector2(0, 0);
            active = false;
        }

        public void Start()
        {
            active = true;
            boll1.startPos = new Vector2(boll1.pos.X, boll1.pos.Y);
            boll1.velocity.X = boll1.speed * (float)Math.Cos(boll1.angle);
            boll1.time = 0;
            if (boll1.speed == 0)
                boll1.speed = 0.000001f;

            boll2.startPos = new Vector2(boll2.pos.X, boll2.pos.Y);
            boll2.velocity.X = boll2.speed * (float)Math.Cos(boll2.angle);
            boll2.time = 0;
            if (boll2.speed ==0)
            {
                boll2.speed = 0.000001f;
            }
        }

        public void CheckGolv(PhysicsObject b)
        {
            if (b.pos.Y + (float)radius + b.GetVelocityY() > golv.pos.Y - golv.GetOriginY())
            {
                Vector2 p = new Vector2(b.pos.X + b.GetVelocityX(), b.pos.Y - b.GetVelocityY());
                b.CalculateHit(p, 0.7f);
                b.startPos = new Vector2(b.pos.X, golv.pos.Y - golv.GetOriginY() - radius - 1/50f);
            }
        }
        public void CheckHögerVägg(PhysicsObject b)
        {
            if (b.pos.X + radius - b.GetVelocityX() > högervägg.pos.X - högervägg.GetOriginX())
            {
                Vector2 p = new Vector2(b.pos.X - b.GetVelocityX(), b.pos.Y + b.GetVelocityY());
                b.CalculateHit(p, 0.8f);
                b.startPos = new Vector2(högervägg.pos.X - högervägg.GetOriginX() - radius - 1/50f, b.pos.Y);
            }
        }
        public void CheckVänsterVägg(PhysicsObject b)
        {
            if (b.pos.X - radius - b.GetVelocityX() < vänstervägg.pos.X + vänstervägg.GetOriginX())
            {
                Vector2 p = new Vector2(b.pos.X - b.GetVelocityX(), b.pos.Y + b.GetVelocityY());
                b.CalculateHit(p, 0.8f);
                b.startPos = new Vector2(vänstervägg.pos.X + vänstervägg.GetOriginX() + radius + 1/50f, b.pos.Y);
            }
        }
        public void CheckBollsColl()
        {
            float distans = Vector2.Distance(boll1.pos, boll2.pos);
            if (distans <= (radius * 2))
            {
                float deltaX = boll1.pos.X - boll2.pos.X;
                float deltaY = boll1.pos.Y - boll2.pos.Y;
                float angle1 = (float)Math.Atan2(deltaY, deltaX);

                deltaX = boll2.pos.X - boll1.pos.X;
                deltaY = boll2.pos.Y - boll1.pos.Y;
                float angle2 = (float)Math.Atan2(deltaY, deltaX);

                float mag1 = boll1.magnitude;
                float mag2 = boll2.magnitude;

                boll1.NewDir(-angle2, mag2);
                boll2.NewDir(-angle1, mag1);
            }
        }

        KeyboardState oldState;

        public override void Update(float delta)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && oldState.IsKeyUp(Keys.Space))
                active = !active;

            if (active)
            {
                //Update balls
                boll1.Update(delta, this);
                boll2.Update(delta, this);
                // Check collision for golv
                CheckGolv(boll1);
                CheckGolv(boll2);
                // Check collision for högervägg
                CheckHögerVägg(boll1);
                CheckHögerVägg(boll2);
                // Check collision for vänstervägg
                CheckVänsterVägg(boll1);
                CheckVänsterVägg(boll2);
                // Check collision for balls
                CheckBollsColl();
            }

            oldState = Keyboard.GetState();
        }


        public override void Draw(SpriteBatch batch)
        {
            golv.Draw(batch, Astate.pixelPerMeter);
            vänstervägg.Draw(batch, Astate.pixelPerMeter);
            högervägg.Draw(batch, Astate.pixelPerMeter);
            boll2.Draw(batch, Astate.pixelPerMeter);
            boll1.Draw(batch, Astate.pixelPerMeter);
        }

    }
}
