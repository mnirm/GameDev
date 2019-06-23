using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PlatformerJarno.Animations;
using PlatformerJarno.Controller;


namespace PlatformerJarno.Entities
{

    class Player : Entity
    {
        // Properties
        private InputHandler _input;
        private Animation _currentAnimation;
        private Animation _idleAnimation;
        private Animation _walkAnimation;
        private Animation _jumpAnimation;

        // Constructor
        public Player(ContentManager content, string path, Vector2 startPosition, ICollection<Entity> entities, float scale = 1 ,int health = 5) : base(content, path, startPosition, entities, scale, health)
        {
            _input = new InputHandler(this);
            CreateAnimations(19, 19);
        }

        // Methods
        public override void Update(GameTime gameTime)
        {
            _input.HandleInput();
            _currentAnimation.Update(gameTime);
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

        private void CreateAnimations(int width, int height)
        {
            #region Idle

            int y = 3;

            _idleAnimation = new Animation(15);
            for (int i = 0; i < 5; i++)
            {
                Rectangle r = new Rectangle(5 + (i * width), y, width, height);
                _idleAnimation.AddFrame(r);
            }

            #endregion

            #region Jump

            y = 25;
            int j = 0;
            _jumpAnimation = new Animation(15);
            for (int i = 0; i < 3; i++)
            {
                Rectangle r = new Rectangle(5 + (i * width), y, width, height);
                _jumpAnimation.AddFrame(r);
                j = i;
            }
            --y;
            _jumpAnimation.AddFrame(new Rectangle(5 + (j * width), y, width, height));

            y -= 2;
            ++j;
            int k = 0;
            for (int i = j; i < j + 3; i++)
            {
                Rectangle r = new Rectangle(5 + (i * width), y, width, height);
                _jumpAnimation.AddFrame(r);
                k = 0;
            }

            for (int i = k; i < k + 2; i++)
            {
                y += 2;
                Rectangle r = new Rectangle(5 + (i * width), y, width, height);
                _jumpAnimation.AddFrame(r);
            }
            #endregion

            #region Walk
            
            y = 47;

            _walkAnimation = new Animation(15);
            for (int i = 0; i < 10; i++)
            {
                Rectangle r = new Rectangle(5 + (i * width), y, width, height);
                _walkAnimation.AddFrame(r);
            }
            #endregion

            _currentAnimation = _idleAnimation;
        }
    }
}
