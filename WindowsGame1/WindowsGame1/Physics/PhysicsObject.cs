using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame1.Utilities;

namespace WindowsGame1.Physics
{
    class PhysicsObject : DrawObject
    {
        public float angle { get; set; }
        public float speed { get; set; }

        public PhysicsObject(Texture2D tex)
            : base(tex)
        {

        }
    }
}
