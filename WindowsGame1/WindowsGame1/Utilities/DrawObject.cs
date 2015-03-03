using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.Utilities
{
    class DrawObject
    {
        public Texture2D texture;
        public Vector2 pos, origin;
        public Rectangle sourceRect;
        public Color color;
        public float rotation, scale;
        public SpriteEffects fx;
        public int width, height;

        public DrawObject(Texture2D texture)
        {
            this.texture = texture;
            this.width = texture.Width;
            this.height = texture.Height;
            this.sourceRect = new Rectangle(0, 0, width, height);
            this.origin = new Vector2(width / 2, height / 2);
            this.pos = pos + origin;
            color = Color.White;
            scale = 1f;
        }

        public DrawObject(Texture2D dot, int width, int height, Color color)
        {
            this.texture = dot;
            this.width = width;
            this.height = height;
            this.sourceRect = new Rectangle(0, 0, width, height);
            this.origin = new Vector2(width / 2, height / 2);
            this.pos = pos + origin;
            this.color = color;
            this.scale = 1f;
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public virtual void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, pos, sourceRect, color, rotation, origin, scale, fx, 0);
        }

        public virtual void Draw(SpriteBatch batch, int pixelspermeter)
        {
            batch.Draw(texture, pos * pixelspermeter, sourceRect, color, rotation, origin, scale, fx, 0);
        }

        public Rectangle Bounds
        {
            get { return new Rectangle((int)(pos.X - origin.X), (int)(pos.Y - origin.Y), width, height); }
        }

        public Rectangle GetOffsetRect(int xOffsert, int yOffset)
        {
            return new Rectangle((int)(pos.X - origin.X) + xOffsert, (int)(pos.Y - origin.Y) + yOffset, width, height);
        }
    }
}
