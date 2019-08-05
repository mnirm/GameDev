using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformerJarno.States.Levels;
using PlatformerJarno.Utilities;

namespace PlatformerJarno.States.Menus
{
    // Class for menu screens able to add buttons and interact with an UI(user interface) through the MouseState
    abstract class MenuScreen : GameState
    {
        // Properties
        protected MouseState mouse;
        protected GraphicsDevice graphicsDevice;
        protected Background background;

        // Constructor
        public MenuScreen(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
        }

        // Methods
        public override void Initialize()
        {
            mouse = Mouse.GetState();
        }

        public override void LoadContent(ContentManager content)
        {

        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            mouse = Mouse.GetState();
            UpdateMenuItems(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            try
            {
                background.Draw(spriteBatch);
                DrawMenuItems(spriteBatch);
            }
            finally
            {
                spriteBatch.End();
            }
        }

        public abstract void DrawMenuItems(SpriteBatch spriteBatch);
        
        public abstract void UpdateMenuItems(GameTime gameTime);
    }
}
