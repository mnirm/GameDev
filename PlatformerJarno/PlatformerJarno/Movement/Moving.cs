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
        private int _movementSpeed;

        // Constructor
        public Moving(int movementSpeed = 100)
        {
            _movementSpeed = movementSpeed;
        }

        // Methods
        private void Gravity(bool touchGround)
        {
            _movement += Vector2.UnitY * _gravityForce;
            if (_gravityForce < 1.4f) _gravityForce *= 1.2f;
            if (touchGround) _gravityForce = 0.5f; // change to touch ground
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
            _movement = -Vector2.UnitY * 30;
        }

        public Vector2 Update(GameTime gameTime, bool touchGround)
        {
            Gravity(touchGround);

            _movement *= new Vector2(.9f,.9f);
            SimulateFriction(touchGround);

            return _movement * (float) gameTime.ElapsedGameTime.TotalMilliseconds / _movementSpeed;
        }

        private void SimulateFriction(bool touchGround)
        {
            if (touchGround) // change to touch ground
                _movement -= _movement * Vector2.One * .08f;
            else
                _movement -= _movement * Vector2.One * .02f;
        }

        public void StopMovingIfBlocked(Vector2 position, Vector2 oldPosition)
        {
            Vector2 lastMovement = position - oldPosition;
            if(lastMovement.X == 0) _movement *= Vector2.UnitY;
            if(lastMovement.Y == 0) _movement *= Vector2.UnitX;
        }
    }
}
