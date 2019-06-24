using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PlatformerJarno.Collider;
using PlatformerJarno.Entities;
using PlatformerJarno.Terrain;
using PlatformerJarno.Utilities;

namespace PlatformerJarno.States.Levels
{
    abstract class Level : GameState
    {
        // Properties
        protected Player player;
        protected ICollection<Entity> entities;
        protected ICollection<Block> terrain;
        protected ICollection<Bullet> bullets;
        protected Collision collision;

        // Constructor
        public Level(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }

        // Methods
        public override void Initialize()
        {

        }

        public abstract override void LoadContent(ContentManager content);

        public abstract override void UnloadContent();

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach (var block in terrain)
            {
                block.Draw(spriteBatch);
            }

            foreach (var entity in entities)
            {
                entity.Draw(spriteBatch);
            }

            foreach (var bullet in bullets)
            {
                bullet.Draw(spriteBatch);
            }
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var entity in entities)
            {
                entity.Update(gameTime);
            }

            foreach (var bullet in bullets)
            {
                bullet.Update(gameTime);
            }
            collision.CollisionTerrainBullet();
        }
    }
}
