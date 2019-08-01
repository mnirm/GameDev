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
using PlatformerJarno.Sprites;
using PlatformerJarno.States.Menus;
using PlatformerJarno.Terrain;
using PlatformerJarno.Utilities;

namespace PlatformerJarno.States.Levels
{
    class Level2:Level
    {
        // Properties
        private WinScreen _winScreen;

        // Constructor
        public Level2(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            camera = new Camera2D(){Zoom = 6f};
        }

        // Methods
        public override void LoadContent(ContentManager content)
        {
            background = new Background(
                new Sprite(content, "bg_lvl2", new Vector2(-250, -90), 1f),
                new List<Sprite>(),
                new List<Sprite>(),
                new List<Vector2>()
            );

            entities = new List<Entity>();
            terrainLoader = new BitmapLoader(PlatformerJarno.Properties.Resources.lvl2);
            terrain = terrainLoader.GetTerrain(content);
            portal = new Portal(content, "portal_spritesheet", new Vector2(380,420));
            entities.Add(new Enemy(content, "slime_spritesheet", new Vector2(240, 20), entities, terrain, bullets));
            entities.Add(new Enemy(content, "slime_spritesheet", new Vector2(540, 240), entities, terrain, bullets));
            entities.Add(new Enemy(content, "slime_spritesheet", new Vector2(360, 200), entities, terrain, bullets));
            entities.Add(new Enemy(content, "slime_spritesheet", new Vector2(140, 300), entities, terrain, bullets));

            player = new Player(content, "player_spritesheet", new Vector2(20, 20), entities, terrain, bullets);
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
