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
        public Texture2D Texture { get; }
        public SpriteEffects SpriteEffect { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle ViewRectangle { get; set; }
        public float Scale { get; set; }

        // Constructor
        public Sprite(ContentManager content, string path, Vector2 startPosition, SpriteEffects spriteEffect = SpriteEffects.None, float scale = 1)
        {
            Texture = content.Load<Texture2D>(path);
            Position = startPosition;

            ViewRectangle = new Rectangle(0,0, Texture.Width, Texture.Height);
            SpriteEffect = spriteEffect;
            Scale = scale;
        }

        // Methods

        // Draw Method, Draws the sprite on the screen with different properties.
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, ViewRectangle, Color.White, 0f, Vector2.Zero, Scale, SpriteEffect, 0f);
        }
    }
}
