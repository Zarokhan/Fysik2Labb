using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame1.States.AllStates;
using WindowsGame1.Utilities;

namespace WindowsGame1.Physics.Shapes
{
    class Boll : DrawObject
    {
        private ResourceManager res;
        public float angle { get; set; }
        public int speed { get; set; }
        public float gravity { get; set; }

        private bool active;
        private Vector2 velocity = Vector2.Zero;
        private Vector2 startPos = Vector2.Zero;
        private float time;

        public Boll(ResourceManager res)
            : base(res.boll)
        {
            this.res = res;
            gravity = 9.8f;
            SetRadius(50);
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
            velocity = Vector2.Zero;
            active = false;
        }

        public void Start()
        {
            active = true;
            velocity.X = (float)(Math.Cos(MathHelper.ToRadians(angle)) * speed);
            velocity.Y = -(float)(Math.Sin(MathHelper.ToRadians(angle)) * speed);
            startPos = new Vector2(pos.X, pos.Y);
            time = 0;
        }

        public void Update(float delta)
        {
            if (active)
            {
                time += delta;

                pos.X = startPos.X + speed * time * (float)Math.Cos(angle);
                pos.Y = startPos.Y - speed * time * (float)Math.Sin(angle) + (gravity * (time * time))/2;
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, pos * Astate.pixelPerMeter, sourceRect, color, rotation, origin, scale, fx, 0);
        }
    }
}
