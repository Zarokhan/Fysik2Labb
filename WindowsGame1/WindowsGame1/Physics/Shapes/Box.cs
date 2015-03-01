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
    class Box : DrawObject
    {
        public float massa;
        public float Fg;
        public float hastighet;
        public float acceleration;

        // Normalkraften
        public Vector2 Fn = Vector2.Zero;

        public Box(ResourceManager res)
            : base(res.box)
        {
            massa = 100;
            Fg = massa * 9.82f;
            hastighet = 0;
            acceleration = 0;
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, pos * Bstate.pixelPerMeter, sourceRect, color, rotation, origin, scale, fx, 0);
        }
    }
}
