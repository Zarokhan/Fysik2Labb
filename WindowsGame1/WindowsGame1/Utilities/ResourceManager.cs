using Microsoft.Xna.Framework;
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
        private Game1 game;

        public Texture2D boll { get; set; }
        public Texture2D box { get; set; }
        public Texture2D ramp { get; set; }
        public Texture2D car { get; set; }
        public Texture2D ohm { get; set; }
        public Texture2D dot { get; set; }
        public Texture2D bana { get; set; }

        public SpriteFont font { get; set; }

        public ResourceManager(Game1 game)
        {
            this.game = game;
        }

        public void LoadContent(ContentManager content)
        {
            boll = content.Load<Texture2D>(@"Images/boll");
            box = content.Load<Texture2D>(@"Images/box");
            ramp = content.Load<Texture2D>(@"Images/ramp");
            car = content.Load<Texture2D>(@"Images/car");
            ohm = content.Load<Texture2D>(@"Images/ohm");
            bana = content.Load<Texture2D>(@"Images/bana");
            font = content.Load<SpriteFont>(@"font");

            dot = new Texture2D(game.GraphicsDevice, 1, 1);
            dot.SetData<Color>(new Color[] { Color.White });
        }
    }
}
