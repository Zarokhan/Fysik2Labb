using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1.Utilities
{
    class ResourceManager
    {
        public Texture2D boll { get; set; }
        public Texture2D box { get; set; }
        public Texture2D ramp { get; set; }
        public Texture2D car { get; set; }
        public Texture2D ohm { get; set; }

        public SpriteFont font { get; set; }

        public ResourceManager()
        {

        }

        public void LoadContent(ContentManager content)
        {
            boll = content.Load<Texture2D>(@"Images/boll");
            box = content.Load<Texture2D>(@"Images/box");
            ramp = content.Load<Texture2D>(@"Images/ramp");
            car = content.Load<Texture2D>(@"Images/car");
            ohm = content.Load<Texture2D>(@"Images/ohm");
            font = content.Load<SpriteFont>(@"font");

        }
    }
}
