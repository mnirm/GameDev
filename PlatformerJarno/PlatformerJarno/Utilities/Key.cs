using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PlatformerJarno.Collider;
using PlatformerJarno.Sprites;

namespace PlatformerJarno.Utilities
{
    class Key : ICollision
    {
        // Properties
        private Vector2 _position;
        private Sprite _sprite;
        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle(
                    (int)_position.X,
                    (int)_position.Y,
                    (int)(_sprite.ViewRectangle.Width * _sprite.Scale),
                    (int)(_sprite.ViewRectangle.Height * _sprite.Scale)
                );
            }
        }

        // Constructor

        // Methods
    }
}
