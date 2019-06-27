using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PlatformerJarno.Animations;
using PlatformerJarno.Terrain;
using PlatformerJarno.Utilities;

namespace PlatformerJarno.Entities
{
    class Enemy : Entity
    {
        // Properties

        // Constructor
        public Enemy(ContentManager content, string path, Vector2 startPosition, ICollection<Entity> entities, ICollection<Block> terrain, ICollection<Bullet> bullets, float scale = 1, int health = 2) : base(content, path, startPosition, entities, terrain, bullets, scale, health)
        {
            currentAnimation = new Animation(4);
            for (int i = 0; i < 4; i++)
            {
                Rectangle r = new Rectangle((28 * i) + 2 * i + 2,0,28,15);
                currentAnimation.AddFrame(r);
            }
        }

        // Methods
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            Health.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            Health.Update();
            currentAnimation.Update(gameTime);

            oldPosition = Position;
            Position += move.Update(gameTime, collision.TouchingGround(CollisionRectangle));
            Position = collision.TryMoveTo(oldPosition, Position, CollisionRectangle);
            move.StopMovingIfBlocked(Position, oldPosition);
        }

        public override void WalkLeft()
        {

        }

        public override void WalkRight()
        {

        }
    }
}
