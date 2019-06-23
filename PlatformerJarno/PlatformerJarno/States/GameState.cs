using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PlatformerJarno.States
{
    abstract class GameState : IGameState
    {
        // Properties
        protected GraphicsDevice _graphicsDevice;

        // Constructor
        public GameState(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        // Method
        public abstract void Initialize();
        public abstract void LoadContent(ContentManager content);
        public abstract void UnloadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
