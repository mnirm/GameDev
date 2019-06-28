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
using PlatformerJarno.States.Menus;
using PlatformerJarno.Terrain;

namespace PlatformerJarno.States.Levels
{
    class Level2:Level
    {
        // Properties
        private WinScreen _winScreen;

        // Constructor
        public Level2(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {

        }

        // Methods
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

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (collision.TouchPortal(portal.CollisionRectangle))
            {
                _winScreen = new WinScreen(_graphicsDevice);
                NextState(_winScreen);
            }
        }
    }
}
