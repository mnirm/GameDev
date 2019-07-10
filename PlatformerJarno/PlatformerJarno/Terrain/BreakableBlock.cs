using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PlatformerJarno.Sprites;
using PlatformerJarno.Utilities;

namespace PlatformerJarno.Terrain
{
    class BreakableBlock : Block
    {
        // Properties
        public Health Health;
        private int _startHealth;

        // Constructor
        public BreakableBlock(ContentManager content, string path, Vector2 position, int health) : base(content, path, position)
        {
             Health = new Health(health);
             _startHealth = Health.Amount;
             sprite.ViewRectangle = new Rectangle(0,0,20,20);
        }

        // Methods
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Health.Amount == _startHealth)
            {
                sprite.ViewRectangle = new Rectangle(0,0,20,20);
            }
            else if (Health.Amount / _startHealth >= 0.8)
            {
                sprite.ViewRectangle = new Rectangle(20, 0, 20, 20);
            }
            else if (Health.Amount / _startHealth >= 0.6)
            {
                sprite.ViewRectangle = new Rectangle(40, 0, 20, 20);
            }
            else if (Health.Amount / _startHealth >= 0.4)
            {
                sprite.ViewRectangle = new Rectangle(60, 0, 20, 20);
            }
            else if (Health.Amount / _startHealth >= 0.2)
            {
                sprite.ViewRectangle = new Rectangle(80, 0, 20, 20);
            }
            else if (Health.Amount / _startHealth >= 0)
            {
                sprite.ViewRectangle = new Rectangle(100, 0, 20, 20);
            }
        }       
    }
}
