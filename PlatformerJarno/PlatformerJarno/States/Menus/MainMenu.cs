using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Button _setting;
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
            _play = new Button(content, "Buttons/button_play", new Vector2((_graphicsDevice.DisplayMode.Width / 2) - 450, 100));
            _play.Clicked += PlayClicked;
            _setting = new Button(content, "Buttons/button_settings", new Vector2((_graphicsDevice.DisplayMode.Width / 2) - 450, 400));
            _setting.Clicked += SettingsClicked;
        }

        public override void DrawMenuItems(SpriteBatch spriteBatch)
        {
            _play.Draw(spriteBatch);
            _setting.Draw(spriteBatch);
        }

        public override void UpdateMenuItems(GameTime gameTime)
        {
            _play.Update(gameTime, mouse);
            _setting.Update(gameTime, mouse);
        }

        private void PlayClicked(object source, ButtonEventArgs args)
        {
            _level1 = new Level1(_graphicsDevice);
            GameStateManager.Instance.SetCurrentState(_level1);
        }

        private void SettingsClicked(object source, ButtonEventArgs args)
        {
            Debug.WriteLine("Settings pressed");
        }
    }
}
