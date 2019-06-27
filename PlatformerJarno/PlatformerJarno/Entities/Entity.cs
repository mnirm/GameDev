using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PlatformerJarno.Animations;
using PlatformerJarno.Collider;
using PlatformerJarno.Movement;
using PlatformerJarno.Sprites;
using PlatformerJarno.Terrain;
using PlatformerJarno.Utilities;

namespace PlatformerJarno.Entities
{
    abstract class Entity : IMoveable, ICollision
    {
        // Properties
        protected Sprite sprite;
        protected Vector2 oldPosition;
        protected Facing facing;
        protected Moving move;
        protected Animation currentAnimation;
        protected Collision collision;
        // Using ICollection<T> instead of List<T> because of OOP.
        // The interface defines the contract but not the implementation. The implementation could change.
        // A good object-oriented practice is to program towards the interface and not the implementation.
        protected ICollection<Entity> Entities;
        public Vector2 Position { get; set; }
        public Health Health { get; }
        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle(
                    (int) Position.X, 
                    (int) Position.Y, 
                    (int) (sprite.ViewRectangle.Width * sprite.Scale), 
                    (int) (sprite.ViewRectangle.Height * sprite.Scale)
                    );
            }
        }

        public enum Facing
        {
            Left, Right
        }

        // Constructor
        protected Entity(ContentManager content, string path, Vector2 startPosition, ICollection<Entity> entities, ICollection<Block> terrain, ICollection<Bullet> bullets, float scale = 1, int health = 5, int movementspeed = 50)
        {
            sprite = new Sprite(content, path, startPosition, scale: scale);

            Entities = entities;
            Entities.Add(this);

            Position = startPosition;

            facing = Facing.Right;

            move = new Moving(movementspeed);
            collision = new Collision(terrain, entities, bullets);
            Health = new Health(health, content, this, scale);
        }

        // Methods
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.ViewRectangle = currentAnimation.CurrentFrame.SourceRectangle;
            if (facing == Facing.Right) sprite.Draw(spriteBatch, position: Position);
            if (facing == Facing.Left) sprite.Draw(spriteBatch, true, Position);
        }

        public virtual Facing GetFacing()
        {
            return facing;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void WalkLeft();
        public abstract void WalkRight();
    }
}
