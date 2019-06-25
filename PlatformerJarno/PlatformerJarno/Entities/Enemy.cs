using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using PlatformerJarno.Terrain;
using PlatformerJarno.Utilities;

namespace PlatformerJarno.Entities
{
    class Enemy : Entity
    {
        // Properties

        // Constructor
        public Enemy(ContentManager content, string path, Vector2 startPosition, ICollection<Entity> entities, ICollection<Block> terrain, ICollection<Bullet> bullets, float scale = 1, int health = 5) : base(content, path, startPosition, entities, terrain, bullets, scale, health)
        {
        }

        // Methods
        public override void Update(GameTime gameTime)
        {

        }

        public override void WalkLeft()
        {

        }

        public override void WalkRight()
        {

        }
    }
}
