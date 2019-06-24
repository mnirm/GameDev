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
using PlatformerJarno.Sprites;

namespace PlatformerJarno.Utilities
{
    class Bullet : ICollision
    {
        // Properties
        private Entity.Facing _facing;
        private Vector2 _velocity;
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
        public Bullet(ContentManager content,Entity shooter)
        {
            _facing = shooter.GetFacing();
            _position = new Vector2(
                shooter.Position.X + shooter.CollisionRectangle.Width,
                shooter.Position.Y/2
                );
            _sprite = new Sprite(content, "bullet", _position, 0.1f);
        }

        // Methods

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_facing == Entity.Facing.Right)
            {
                _sprite.Draw(spriteBatch, position: _position);
            }
            else if (_facing == Entity.Facing.Left)
            {
                _sprite.Draw(spriteBatch, true, _position);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (_facing == Entity.Facing.Right)
            {
                _velocity = new Vector2(1, 0);
                _position += _velocity;
            }
            else if (_facing == Entity.Facing.Left)
            {
                _velocity = new Vector2(-1,0);
                _position += _velocity;
            }
        }
    }
}
