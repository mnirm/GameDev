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
using PlatformerJarno.States.Menus;
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
        protected Portal portal;
        protected Collision collision;
        protected Camera2D camera;
        protected BitmapLoader terrainLoader;

        // Constructor
        public Level(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            camera = new Camera2D(){Zoom = 2f};
            bullets = new List<Bullet>();
        }

        // Methods
        public override void Initialize()
        {

        }

        public abstract override void LoadContent(ContentManager content);

        public abstract override void UnloadContent();

        public void NextState(IGameState state)
        {
            GameStateManager.Instance.SetCurrentState(state);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: camera.GetTransformationMatrix(_graphicsDevice));
            foreach (var block in terrain)
            {
                if (block is BreakableBlock)
                {
                    var breakableBlock = block as BreakableBlock;
                    breakableBlock.Draw(spriteBatch);
                }
                else block.Draw(spriteBatch);
            }

            portal.Draw(spriteBatch);


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
                if (entity.Health.Amount <= 0) entities.Remove(entity);

                entity.Update(gameTime);

                if (entity is Player)
                {
                    camera.MoveCamera(new Vector2(entity.CollisionRectangle.X - (1920 / 2 / camera.Zoom), 0));
                    if(entity.Health.Amount <= 0)
                        NextState(new MainMenu(_graphicsDevice));
                }
            }

            foreach (var bullet in bullets)
            {
                bullet.Update(gameTime);
            }

            portal.Update(gameTime);

            collision.CollisionBullet();
        }
    }
}
