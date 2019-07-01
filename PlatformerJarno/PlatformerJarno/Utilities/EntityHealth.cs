using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using PlatformerJarno.Entities;

namespace PlatformerJarno.Utilities
{
    class EntityHealth : Health
    {
        // Properties

        // Constructor
        public EntityHealth(int health, ContentManager content, Entity entity, float scale = 1) : base(health, content, entity, scale)
        {
        }

        // Methods
    }
}
