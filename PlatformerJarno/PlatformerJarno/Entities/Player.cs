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
using PlatformerJarno.Movement;
using PlatformerJarno.Terrain;
using PlatformerJarno.Utilities;


namespace PlatformerJarno.Entities
{

    class Player : Entity
    {
        // Properties
        private InputHandler _input;
        private Animation _idleAnimation;
        private Animation _walkAnimation;
        private Animation _jumpAnimation;
        private ICollection<Bullet> _bullets;
        private ContentManager _content;
        private bool _jump;

        // Constructor
        public Player(ContentManager content, string path, Vector2 startPosition, ICollection<Entity> entities, ICollection<Block> terrain, ICollection<Bullet> bullets, float scale = 1 ,int health = 5) : base(content, path, startPosition, entities, terrain, bullets, scale, health)
        {
            _input = new InputHandler(this);
            CreateAnimations(20, 20);
            _bullets = bullets;
            _content = content;
        }

        // Methods
        public override void Update(GameTime gameTime)
        {
            _input.HandleInput();
            currentAnimation.Update(gameTime);

            oldPosition = Position;
            Position += move.Update(gameTime, collision.TouchingGround(CollisionRectangle));
            Position = collision.TryMoveTo(oldPosition, Position, CollisionRectangle);
            move.StopMovingIfBlocked(Position, oldPosition);

            Health.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Health.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }

        public void Idle()
        {
            currentAnimation = _idleAnimation;
        }

        public override void WalkLeft()
        {
            facing = Facing.Left;
            currentAnimation = _walkAnimation;
            move.Left();
        }

        public override void WalkRight()
        {
            facing = Facing.Right;
            currentAnimation = _walkAnimation;
            move.Right();
        }

        public void Jump()
        {
            _jump = true;
            if (collision.TouchingGround(CollisionRectangle))
            {
                currentAnimation = _jumpAnimation;
                move.Jump();
            }
        }

        public void Attack()
        {
            _bullets.Add(new Bullet(_content, this));
        }

        private void CreateAnimations(int width, int height)
        {
            #region Idle

            int y = 2;

            _idleAnimation = new Animation(8);
            for (int i = 0; i < 5; i++)
            {
                Rectangle r = new Rectangle((5 + (i * (width + 6))), y, width, height);
                _idleAnimation.AddFrame(r);
            }

            #endregion

            #region Jump

            y = 25;
            int j = 0;
            _jumpAnimation = new Animation(7);
            for (int i = 0; i < 4; i++)
            {
                Rectangle r = new Rectangle((5 + (i * (width + 6))), y, width, height);
                _jumpAnimation.AddFrame(r);
                j = i;
            }

            y -= 2;
            ++j;
            int k = 0;
            for (int i = j; i < j + 3; i++)
            {
                Rectangle r = new Rectangle((5 + (i * (width + 6))), y, width, height);
                _jumpAnimation.AddFrame(r);
                k = 0;
            }

            for (int i = k; i < k + 2; i++)
            {
                y += 1;
                Rectangle r = new Rectangle((5 + (i * (width + 6))), y, width, height);
                _jumpAnimation.AddFrame(r);
            }
            #endregion

            #region Walk
            
            y = 47;

            _walkAnimation = new Animation(15);
            for (int i = 0; i < 10; i++)
            {
                Rectangle r = new Rectangle((5 + (i * (width + 6))), y, width, height);
                _walkAnimation.AddFrame(r);
            }
            #endregion

            sprite.ViewRectangle = new Rectangle(0, 0, width, height);
            currentAnimation = _idleAnimation;
        }
    }
}
