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

namespace PlatformerJarno.States.Levels
{
    class Level2:Level
    {
        public Level2(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {

        }

        public override void LoadContent(ContentManager content)
        {
            entities = new List<Entity>();
            terrainLoader = new BitmapLoader(PlatformerJarno.Properties.Resources.test);
            terrain = terrainLoader.GetTerrain(content);
            portal = new Portal(content, "portal_spritesheet", new Vector2(100,100));
            player = new Player(content, "player_spritesheet", new Vector2(40, 0), entities, terrain, bullets);
            collision = new Collision(terrain, entities, bullets);
        }

        public override void UnloadContent()
        {

        }
    }
}
