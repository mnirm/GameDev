using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace PlatformerJarno.Movement
{
    interface IMoveable
    {
        void Update(GameTime gameTime);
        void WalkLeft();
        void WalkRight();
    }
}
