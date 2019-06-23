using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PlatformerJarno.Entities;

namespace PlatformerJarno.Movement
{
    class Moving
    {
        // Properties
        private float _gravityForce = 0.5f;
        private Vector2 _movement;

        // Constructor
        public Moving()
        {
        }

        // Methods
        private void Gravity()
        {
            _movement += Vector2.UnitY * _gravityForce;
            if (_gravityForce < 1.4f) _gravityForce *= 1.2f;
            if (false) _gravityForce = 0.5f; // change to touch ground
        }

        public void Left()
        {
            _movement += new Vector2(-1,0);
        }

        public void Right()
        {
            _movement += new Vector2(1, 0);
        }

        public void Jump()
        {
            _movement = -Vector2.UnitY * 25;
        }

        public Vector2 Update(GameTime gameTime)
        {
            Gravity();

            _movement *= new Vector2(.9f,.9f);
            SimulateFriction();

            return _movement;
        }

        private void SimulateFriction()
        {
            if (false) // change to touch ground
                _movement -= _movement * Vector2.One * .08f;
            else
                _movement -= _movement * Vector2.One * .02f;
        }
    }
}
