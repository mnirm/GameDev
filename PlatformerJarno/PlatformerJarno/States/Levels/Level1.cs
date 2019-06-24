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
using PlatformerJarno.Terrain;
using PlatformerJarno.Utilities;

namespace PlatformerJarno.States.Levels
{
    class Level1: Level
    {
        // Properties

        // Constructor
        public Level1(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }

        // Methods
        public override void LoadContent(ContentManager content)
        {
            entities = new List<Entity>();
            terrain = new List<Block>()
            {
                new Block(content, "grassblok", new Vector2(0,200)),
                new Block(content, "grassblok", new Vector2(20,200)),
                new Block(content, "grassblok", new Vector2(40,200)),
                new Block(content, "grassblok", new Vector2(60,200)),
                new Block(content, "grassblok", new Vector2(80,200)),
                new Block(content, "grassblok", new Vector2(100,200)),
                new Block(content, "grassblok", new Vector2(120,200)),
                new Block(content, "grassblok", new Vector2(120,180)),
                new Block(content, "grassblok", new Vector2(120,160)),

            };
            bullets = new List<Bullet>();

            player = new Player(content, "player_spritesheet", new Vector2(0,0), entities, terrain,bullets);

            collision = new Collision(terrain, entities, bullets);
        }

        public override void UnloadContent()
        {

        }
    }
}
