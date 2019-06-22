using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PlatformerJarno.Sprites
{
    // Sprite Class, Class for drawing sprites on screen
    class Sprite
    {
        // Properties
        private Texture2D _texture;
        private float _scale;

        public Vector2 Position { get; set; }
        public Rectangle ViewRectangle { get; set; }

        // Constructor
        public Sprite(ContentManager content, string path, Vector2 startPosition, float scale = 1)
        {
            _texture = content.Load<Texture2D>(path);
            Position = startPosition;

            ViewRectangle = new Rectangle(0,0, _texture.Width, _texture.Height);
            _scale = scale;
        }

        // Methods

        // Draw Method, Draws the sprite on the screen with different properties.
        public void Draw(SpriteBatch spriteBatch, bool flipped)
        {
            SpriteEffects spriteEffect = (flipped) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            spriteBatch.Draw(_texture, Position, ViewRectangle, Color.White, 0f, Vector2.Zero, _scale, spriteEffect, 0f);
        }
    }
}
