using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace PlatformerJarno.Terrain
{
    class Portal : Block
    {
        public Portal(ContentManager content, string path, Vector2 position) : base(content, path, position)
        {
        }
    }
}
