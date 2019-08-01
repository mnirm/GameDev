using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PlatformerJarno.Sprites;
using PlatformerJarno.States.Levels;
using PlatformerJarno.Utilities;

namespace PlatformerJarno.States.Menus
{
    class WinScreen: MenuScreen
    {
        // Properties
        private Button _playAgain;
        private Button _exit;
        private Level1 _level1;


        // Constructor
        public WinScreen(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }

        // Methods
        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            background = new Background(
                new Sprite(content, "winscreen", Vector2.Zero, 2),
                new List<Sprite>()
                {
                    new Sprite(content, "won", new Vector2((_graphicsDevice.DisplayMode.Width / 2) - 550, 10))
                },
                new List<Sprite>(),
                new List<Vector2>()
            );
            _playAgain = new Button(content, "Buttons/btn_again", new Vector2((_graphicsDevice.DisplayMode.Width / 2) - 350, 100));
            _playAgain.Clicked += PlayAgainClicked;
            _exit = new Button(content, "Buttons/EXIT", new Vector2((_graphicsDevice.DisplayMode.Width / 2) - 150, 100));
            _exit.Clicked += ExitClicked;
        }

        public override void DrawMenuItems(SpriteBatch spriteBatch)
        {
            _playAgain.Draw(spriteBatch);
            _exit.Draw(spriteBatch);
        }

        public override void UpdateMenuItems(GameTime gameTime)
        {
            _playAgain.Update(gameTime, mouse);
            _exit.Update(gameTime, mouse);
        }

        public void PlayAgainClicked(object source, ButtonEventArgs args)
        {
            _level1 = new Level1(graphicsDevice);
            GameStateManager.Instance.SetCurrentState(_level1);
        }

        public void ExitClicked(object source, ButtonEventArgs args)
        {
            Environment.Exit(1);
        }
    }
}
