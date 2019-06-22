using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace PlatformerJarno.Entities
{

    class Player : Entity
    {
        // Properties


        // Constructor
        public Player(ContentManager content, string path, Vector2 startPosition, ICollection<Entity> entities, int health = 5) : base(content, path, startPosition, entities, health)
        {

        }

        // Methods
        public override void Update(GameTime gameTime)
        {
            
        }

        public void Idle()
        {
            Console.WriteLine("Idle");
        }

        public void WalkLeft()
        {
            Console.WriteLine("Left");
        }

        public void WalkRight()
        {
            Console.WriteLine("Right");
        }

        public void Jump()
        {
            Console.WriteLine("Jump");
        }

        public void Attack()
        {
            Console.WriteLine("Attack");
        }
    }
}
