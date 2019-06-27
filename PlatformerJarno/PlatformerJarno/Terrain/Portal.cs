using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PlatformerJarno.Animations;
using PlatformerJarno.Sprites;

namespace PlatformerJarno.Terrain
{
    class Portal
    {
        // Properties
        private Sprite _sprite;
        private Animation _portalAnimation;
        private Vector2 _position;
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
        public Portal(ContentManager content, string path, Vector2 position)
        {
            _sprite = new Sprite(content, path, position);
            
            _position = position;
            _portalAnimation = new Animation(2);
            for (int i = 0; i < 3; i++)
            {
                _portalAnimation.AddFrame(new Rectangle(i * 20, 0, 20,20));
            }
        }

        // Methods
        public void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            _portalAnimation.Update(gameTime);
            _sprite.ViewRectangle = _portalAnimation.CurrentFrame.SourceRectangle;
        }
    }
}
