using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformerJarno.Entities;
using PlatformerJarno.Sprites;
using PlatformerJarno.States;
using PlatformerJarno.States.Levels;
using PlatformerJarno.States.Menus;
using PlatformerJarno.Terrain;

namespace PlatformerJarno
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {   PreferredBackBufferWidth = 1920,
                PreferredBackBufferHeight = 1080
            };
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GameStateManager.Instance.SetContent(Content);
            GameStateManager.Instance.SetCurrentState(new MainMenu(GraphicsDevice));
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GameStateManager.Instance.GetCurrentState() is MenuScreen)
                this.IsMouseVisible = true;
            else this.IsMouseVisible = false;

            GameStateManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GameStateManager.Instance.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
