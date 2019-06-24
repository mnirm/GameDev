using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PlatformerJarno.States.Levels;
using PlatformerJarno.Utilities;

namespace PlatformerJarno.States.Menus
{
    class MainMenu : MenuScreen
    {
        // Properties
        private Button _play;
        private Level1 _level1;

        // Constructor
        public MainMenu(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }

        // Methods
        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            _play = new Button(content, "", new Vector2(_graphicsDevice.DisplayMode.Width / 2 - 100, 100));
            _play.Clicked += PlayClicked;
        }

        public override void DrawMenuItems(SpriteBatch spriteBatch)
        {
            _play.Draw(spriteBatch);
        }

        public override void UpdateMenuItems(GameTime gameTime)
        {
            _play.Update(gameTime, mouse);
        }

        private void PlayClicked(object source, ButtonEventArgs args)
        {
            _level1 = new Level1(_graphicsDevice);
            GameStateManager.Instance.SetCurrentState(_level1);
        }

        private void SettingsClicked(object source, ButtonEventArgs args)
        {

        }
    }
}
