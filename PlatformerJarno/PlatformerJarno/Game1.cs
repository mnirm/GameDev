using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformerJarno.Entities;
using PlatformerJarno.Sprites;
using PlatformerJarno.States;
using PlatformerJarno.States.Levels;
using PlatformerJarno.Terrain;

namespace PlatformerJarno
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private ICollection<Entity> entities;
        private Player player;
        private ICollection<Block> terrain;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            GameStateManager.Instance.AddScreen(new Level1(GraphicsDevice));
        }

        protected override void UnloadContent()
        {
            GameStateManager.Instance.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
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
