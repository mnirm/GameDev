using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformerJarno.Sprites;

namespace PlatformerJarno.Utilities
{
    // Used events
    // Button class
    class Button
    {
        // Properties
        private Sprite _sprite;
        private Rectangle _buttonRectangle;
        public event ClickEventHandler Clicked;
        public delegate void ClickEventHandler(object source, ButtonEventArgs args);

        // Constructor
        public Button(ContentManager content, string path, Vector2 buttonPosition)
        {
            _sprite = new Sprite(content, path, buttonPosition);
            _buttonRectangle = new Rectangle((int)buttonPosition.X, (int)buttonPosition.Y, _sprite.ViewRectangle.Width, _sprite.ViewRectangle.Height);
        }

        // Methods
        public void Update(GameTime gameTime, MouseState mouse)
        {
            if(_buttonRectangle.Intersects(new Rectangle(mouse.X, mouse.Y, 10, 10)) && mouse.LeftButton == ButtonState.Pressed)
                OnClicked();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _sprite.Draw(spriteBatch);
        }

        public virtual void OnClicked()
        {
            Clicked?.Invoke(this, 
                new ButtonEventArgs(){Button = this});
        }
    }
}
