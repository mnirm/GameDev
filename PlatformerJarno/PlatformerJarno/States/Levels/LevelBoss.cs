
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PlatformerJarno.Terrain;

namespace PlatformerJarno.States.Levels
{
    class LevelBoss : Level
    {
        // Properties

        // Constructor
        public LevelBoss(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }

        // Methods

        public override void LoadContent(ContentManager content)
        {
            //terrainLoader = new BitmapLoader(PlatformerJarno.Properties.Resources.lvlBoss);

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
