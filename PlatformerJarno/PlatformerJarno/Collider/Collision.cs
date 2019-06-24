using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PlatformerJarno.Entities;
using PlatformerJarno.Terrain;
using PlatformerJarno.Utilities;

namespace PlatformerJarno.Collider
{
    class Collision
    {
        // Properties
        private ICollection<Block> _terrain;
        private ICollection<Entity> _entities;
        private ICollection<Bullet> _bullets;

        // Constructor
        public Collision(ICollection<Block> terrain, ICollection<Entity> entities, ICollection<Bullet> bullets)
        {
            _terrain = terrain;
            _entities = entities;
            _bullets = bullets;
        }

        // Methods
        private bool CheckRoom(Rectangle rectangle)
        {
            foreach (var block in _terrain)
            {
                if (block.CollisionRectangle.Intersects(rectangle)) return false;
            }
            return true;
        }

        public bool TouchingGround(Rectangle rectangle)
        {
            Rectangle onePixelDown = rectangle;
            onePixelDown.Offset(0, 1);
            return !CheckRoom(onePixelDown);
        }

        private Rectangle CreateRectangleAtPosition(Vector2 positionToTry, int width, int height)
        {
            return new Rectangle((int)positionToTry.X, (int)positionToTry.Y, width, height);
        }

        public Vector2 TryMoveTo(Vector2 originalPosition, Vector2 destination, Rectangle collisionRectangle)
        {
            Vector2 tryMove = destination - originalPosition;
            Vector2 possibleLocation = originalPosition;

            int remainingSteps = (int) (tryMove.Length() * 2) + 1;
            Vector2 step = tryMove / remainingSteps;

            for (int i = 0; i <= remainingSteps; i++)
            {
                Vector2 positionToTry = originalPosition + step * i;
                Rectangle newCollision =
                    CreateRectangleAtPosition(positionToTry, collisionRectangle.Width, collisionRectangle.Height);

                if (CheckRoom(newCollision)) possibleLocation = positionToTry;
                else
                {
                    bool movingDiagonal = tryMove.X != 0 && tryMove.Y != 0;
                    if (movingDiagonal)
                    {
                        int stepsLeft = remainingSteps - (i - 1);

                        Vector2 remainingHorizontalMovement = step.X * Vector2.UnitX * stepsLeft;
                        Vector2 movingHorizontally = possibleLocation + remainingHorizontalMovement;
                        possibleLocation = TryMoveTo(possibleLocation, movingHorizontally, collisionRectangle);

                        Vector2 remainingVerticalMovement = step.Y * Vector2.UnitY * stepsLeft;
                        Vector2 movingVertically = possibleLocation + remainingVerticalMovement;
                        possibleLocation = TryMoveTo(possibleLocation, movingVertically, collisionRectangle);
                    }

                    break;
                }
            }

            return possibleLocation;
        }

        public void CollisionBullet()
        {
            BulletIntoTerrain();
            BulletIntoEntity();
        }

        private void BulletIntoEntity()
        {
            foreach (var bullet in _bullets)
            {
                foreach (var entity in _entities)
                {
                    if (!(entity is Player))
                    {
                        if (entity.CollisionRectangle.Intersects(bullet.CollisionRectangle))
                        {
                            entity.Health.ReceiveDamage(1);
                            _bullets.Remove(bullet);
                        }
                    }
                }
            }
            _bullets.OrderBy(x => x);
        }

        private void BulletIntoTerrain()
        {
            foreach (var bullet in _bullets)
            {
                foreach (var block in _terrain)
                {
                    if (block.CollisionRectangle.Intersects(bullet.CollisionRectangle))
                        _bullets.Remove(bullet);
                }
            }
            _bullets.OrderBy(x => x);
        }

        public bool TouchPortal()
        {
            foreach (var entity in _entities)
            {
                if (entity is Player)
                {
                    foreach (var block in _terrain)
                    {
                        if(block is Portal)
                            if (entity.CollisionRectangle.Intersects(block.CollisionRectangle))
                                return true;
                    }
                }
            }
            return false;
        }
    }
}
