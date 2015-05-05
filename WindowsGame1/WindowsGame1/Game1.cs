using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using WindowsGame1.Fönster;
using WindowsGame1.States;
using WindowsGame1.Utilities;
using WindowsGame1.Forms;

namespace WindowsGame1
{
    class Game1 : Microsoft.Xna.Framework.Game
    {
        public const int width = 1500, height = 800;

        GraphicsDeviceManager graphics;
        SpriteBatch batch;

        KeyboardState oldState;

        public ResourceManager res { get; set; }
        public StateManager states { get; set; }

        public SelectAssignment form { get; set; }
        public AForm aForm { get; set; }
        public A2Form a2Form { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            this.IsMouseVisible = true;
            Window.Title = "Robin & Antons fysiska motor";
            Content.RootDirectory = "Content";
        }

        public void CloseAllForms()
        {
            form.Close();
            aForm.Close();
            a2Form.Close();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            batch = new SpriteBatch(GraphicsDevice);
            res = new ResourceManager(this);
            res.LoadContent(Content);
            form = new SelectAssignment(this);
            form.Show();
            aForm = new AForm(this);
            a2Form = new A2Form(this);

            states = new StateManager(this);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.S) && oldState.IsKeyUp(Keys.S))
            {
                form.Close();
                form = new SelectAssignment(this);
                form.Show();
            }

            states.Update(delta);

            oldState = Keyboard.GetState();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            batch.Begin();
            states.Draw(batch);
            batch.End();

            base.Draw(gameTime);
        }
    }
}
