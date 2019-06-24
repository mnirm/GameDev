using System;
using System.Collections.Generic;
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
    class Level1: Level
    {
        private Player player;
        private ICollection<Entity> entities;
        private ICollection<Block> terrain;
        private ICollection<Bullet> bullets;
        private Collision collision;

        public Level1(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }

        public override void LoadContent(ContentManager content)
        {
            entities = new List<Entity>();
            terrain = new List<Block>()
            {
                new Block(content, "grassblok", new Vector2(0,200)),
                new Block(content, "grassblok", new Vector2(20,200)),
                new Block(content, "grassblok", new Vector2(40,200)),
                new Block(content, "grassblok", new Vector2(60,200)),
                new Block(content, "grassblok", new Vector2(80,200)),
                new Block(content, "grassblok", new Vector2(80,180)),
                new Block(content, "grassblok", new Vector2(80,160)),

            };
            bullets = new List<Bullet>();

            player = new Player(content, "player_spritesheet", new Vector2(0,0), entities, terrain,bullets);

            collision = new Collision(terrain, entities, bullets);
        }

        public override void UnloadContent()
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
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
            base.Update(gameTime);
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
