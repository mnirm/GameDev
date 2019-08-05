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
    // Enemy class
    // Enemy moves automatically for a specific time in a direction then changes the direction after the timer is done
    class Enemy : Entity
    {
        // Properties
        private float _timer;
        private const float _TIMER = 5;

        // Constructor
        public Enemy(ContentManager content, string path, Vector2 startPosition, ICollection<Entity> entities,
            ICollection<Block> terrain, ICollection<Bullet> bullets, float scale = 1, int health = 2, int movementspeed = 400) : 
            base(content, path, startPosition, entities, terrain, bullets, scale, health, movementspeed)
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
            sprite.ViewRectangle = currentAnimation.CurrentFrame.SourceRectangle;
            if (facing == Facing.Right) sprite.Draw(spriteBatch, true, Position);
            if (facing == Facing.Left) sprite.Draw(spriteBatch, position: Position);
            Health.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            Health.Update();
            currentAnimation.Update(gameTime);

            ChangeDirectionTimer(gameTime);

            if (facing == Facing.Left)
            {
                WalkLeft();
            }
            else if (facing == Facing.Right)
            {
                WalkRight();
            }

            oldPosition = Position;
            Position += move.Update(gameTime, collision.TouchingGround(CollisionRectangle));
            Position = collision.TryMoveTo(oldPosition, Position, CollisionRectangle);
            move.StopMovingIfBlocked(Position, oldPosition);
        }

        private void ChangeDirectionTimer(GameTime gameTime)
        {
            float elapsed = (float) gameTime.ElapsedGameTime.TotalSeconds;
            _timer -= elapsed;
            if (_timer < 0)
            {
                if (facing == Facing.Left)
                    facing = Facing.Right;
                else facing = Facing.Left;
                _timer = _TIMER;
            }
        }

        public override void WalkLeft()
        {
            move.Left();
        }

        public override void WalkRight()
        {
            move.Right();
        }
    }
}
