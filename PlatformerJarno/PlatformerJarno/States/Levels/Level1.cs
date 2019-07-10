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
        private Level2 _level2;

        // Constructor
        public Level1(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }

        // Methods
        public override void LoadContent(ContentManager content)
        {
            entities = new List<Entity>();
            terrainLoader = new BitmapLoader(PlatformerJarno.Properties.Resources.lvl1);
            terrain = terrainLoader.GetTerrain(content);
            terrain.Add(new BreakableBlock(content, "block_spritesheet", new Vector2(40,40), 6));
            entities.Add(new Enemy(content, "slime_spritesheet", new Vector2(140, 20), entities, terrain, bullets));
            player = new Player(content, "player_spritesheet", new Vector2(0,0), entities, terrain, bullets);
            portal = new Portal(content, "portal_spritesheet", new Vector2(500,300));
            collision = new Collision(terrain, entities, bullets);
        }

        public override void Update(GameTime gameTime)
        {
            if (collision.TouchPortal(portal.CollisionRectangle))
            {
                _level2 = new Level2(_graphicsDevice);
                NextState(_level2);
            }
            base.Update(gameTime);
        }

        public override void UnloadContent()
        {
            try
            {
                GameStateManager.Instance.UnloadContent();
            }
            catch (Exception e)
            {

            }
        }
    }
}
