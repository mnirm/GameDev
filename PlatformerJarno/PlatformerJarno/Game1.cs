using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformerJarno.Entities;
using PlatformerJarno.Sprites;
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
            entities = new List<Entity>();
            terrain =new List<Block>()
            {
                new Block(Content, "grassblok",new Vector2(0,300)),
                new Block(Content, "grassblok",new Vector2(20,300)),
                new Block(Content, "grassblok",new Vector2(40,300)),
                new Block(Content, "grassblok",new Vector2(60,320))
            };
            player = new Player(Content, "player_spritesheet", new Vector2(100,100), entities, terrain);
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
                player.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
                player.Draw(spriteBatch);
                foreach (var blok in terrain)
                {
                    blok.Draw(spriteBatch);
                }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
