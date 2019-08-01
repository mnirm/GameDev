using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformerJarno.Sprites;

namespace PlatformerJarno.Utilities
{
    // Background class
    // Shows everything going on in the background (moving clouds, a sun, a moon) and the background itself

    class Background
    {
        // Properties
        private List<Sprite> _decals;
        private List<Sprite> _movingDecals;
        private List<Vector2> _positionMovingDecals;
        private Sprite _backgroundLayer;

        // Constructor
        public Background(Sprite backgroundLayer, List<Sprite> decals, List<Sprite> movingDecals, List<Vector2> positionMovingDecals)
        {
            _backgroundLayer = backgroundLayer;
            _decals = decals;
            _movingDecals = movingDecals;
            _positionMovingDecals = positionMovingDecals;
        }

        // Methods

        // Only draws the decals and moving decals if anything is in it
        public void Draw(SpriteBatch spriteBatch)
        {
            _backgroundLayer.Draw(spriteBatch);

            if (_decals.Any())
            {
                foreach (var decal in _decals)
                {
                    decal.Draw(spriteBatch);
                }
            }

            if (_movingDecals.Any())
            {
                int index = 0;

                foreach (var decal in _movingDecals)
                {
                    decal.Draw(spriteBatch, position: _positionMovingDecals[index]);
                    index++;
                }
            }
        }

    }
}
