using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PlatformerJarno.States
{
    // Singleton pattern
    // Class to handle game states
    class GameStateManager
    {
        // Properties
        private ContentManager _content;
        private IGameState _state;
        private static GameStateManager _instance;
        public static GameStateManager Instance => _instance ?? (_instance = new GameStateManager());

        // Constructor

        // Methods
        // Set the content of this GameStateManager
        public void SetContent(ContentManager content)
        {
            _content = content;
        }

        // Updates current state
        public void Update(GameTime gameTime)
        {
            try
            {
                _state.Update(gameTime);
            }
            catch (Exception e)
            {

            }
        }

        // Draws current state
        public void Draw(SpriteBatch spriteBatch)
        {
            try
            {
                _state.Draw(spriteBatch);
            }
            catch
            {

            }
        }

        public void UnloadContent()
        {
            _state.UnloadContent();
        }

        // Get CurrentState returns a IGameState object
        public IGameState GetCurrentState()
        {
            return _state;
        }

        // Change the CurrentState in this instance
        public void SetCurrentState(IGameState state)
        {
            try
            {
                _state = state;
                _state.Initialize();
                if(_content != null) _state.LoadContent(_content);
            }
            catch (Exception e)
            {

            }
        }

    }
}
