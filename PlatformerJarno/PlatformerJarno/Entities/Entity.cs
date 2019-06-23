using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PlatformerJarno.Collider;
using PlatformerJarno.Movement;
using PlatformerJarno.Sprites;
using PlatformerJarno.Utilities;

namespace PlatformerJarno.Entities
{
    abstract class Entity : IMoveable, ICollision
    {
        // Properties
        protected Sprite sprite;
        protected Vector2 oldPosition;
        protected Facing facing;
        // Using ICollection<T> instead of List<T> because of OOP.
        // The interface defines the contract but not the implementation. The implementation could change.
        // A good object-oriented practice is to program towards the interface and not the implementation.
        protected ICollection<Entity> Entities;
        public Vector2 Movement { get; set; }
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

        protected enum Facing
        {
            Left, Right
        }

        // Constructor
        protected Entity(ContentManager content, string path, Vector2 startPosition, ICollection<Entity> entities, int health = 5)
        {
            sprite = new Sprite(content, path, startPosition, scale: 4f);

            Entities = entities;
            Entities.Add(this);

            Position = startPosition;
             
            Health = new Health(health);
        }

        // Methods
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position: Position);
        }

        public abstract void Update(GameTime gameTime);
        public abstract void WalkLeft();
        public abstract void WalkRight();
    }
}
