using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PlatformerJarno.Collider;
using PlatformerJarno.Sprites;

namespace PlatformerJarno.Terrain
{
    class Block : ICollision
    {
        // Properties
        protected Sprite sprite;
        protected Vector2 position;
        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    (int)(sprite.ViewRectangle.Width * sprite.Scale),
                    (int)(sprite.ViewRectangle.Height * sprite.Scale)
                );
            }
        }

        // Constructor
        public Block(ContentManager content, string path, Vector2 position)
        {
            this.position = position;
            sprite = new Sprite(content, path, position);
        }

        // Methods
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position: position);
        }
    }
}
