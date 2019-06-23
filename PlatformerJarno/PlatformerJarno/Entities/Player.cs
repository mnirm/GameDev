using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (facing == Facing.Left) sprite.Draw(spriteBatch, position: Position);
            if (facing == Facing.Right) sprite.Draw(spriteBatch, true, Position);
        }

        public void Idle()
        {

        }

        public override void WalkLeft()
        {
            facing = Facing.Left;
        }

        public override void WalkRight()
        {
            facing = Facing.Right;
        }

        public void Jump()
        {

        }

        public void Attack()
        {

        }
    }
}
