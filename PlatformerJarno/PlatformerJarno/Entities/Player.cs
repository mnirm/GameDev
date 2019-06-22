using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using PlatformerJarno.Controller;


namespace PlatformerJarno.Entities
{

    class Player : Entity
    {
        // Properties
        private InputHandler _input;

        // Constructor
        public Player(ContentManager content, string path, Vector2 startPosition, ICollection<Entity> entities, int health = 5) : base(content, path, startPosition, entities, health)
        {
            _input = new InputHandler(this);
        }

        // Methods
        public override void Update(GameTime gameTime)
        {
            _input.HandleInput();
        }

        public void Idle()
        {

        }

        public override void WalkLeft()
        {

        }

        public override void WalkRight()
        {

        }

        public void Jump()
        {

        }

        public void Attack()
        {

        }
    }
}
