using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using PlatformerJarno.Utilities;

namespace PlatformerJarno.Terrain
{
    class BreakableBlock : Block
    {
        // Properties
        private Health _health;

        // Constructor
        public BreakableBlock(ContentManager content, string path, Vector2 position, int health) : base(content, path, position)
        {
            // _health = new Health(health, content,);
        }

        // Methods

    }
}
