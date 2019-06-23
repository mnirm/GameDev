using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PlatformerJarno.Entities;
using PlatformerJarno.Terrain;

namespace PlatformerJarno.States.Levels
{
    class Level1 : GameState
    {
        private Player _player;
        private ICollection<Entity> _entities;
        private ICollection<Block> _terrain;

        public Level1(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }

        public override void Initialize()
        {

        }

        public override void LoadContent(ContentManager content)
        {
            _entities = new List<Entity>();
            _terrain = new List<Block>();
            _player = new Player(content, "player_spritesheet", new Vector2(100,100), _entities, _terrain);
        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            _player.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
                _player.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
