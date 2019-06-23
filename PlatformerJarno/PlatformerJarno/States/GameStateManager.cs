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
        private static GameStateManager _instance;
        private Stack<GameState> _screens = new Stack<GameState>();
        private ContentManager _content;

        public static GameStateManager Instance
        {
            get
            {
                if (_instance == null) _instance = new GameStateManager();
                return _instance;
            }
        }

        // Constructor

        // Methods
        // Set content
        public void SetContent(ContentManager content)
        {
            _content = content;
        }

        // Add screen tot stack
        public void AddScreen(GameState screen)
        {
            try
            {
                _screens.Push(screen);
                _screens.Peek().Initialize();
                if (_content != null)             
                    _screens.Peek().LoadContent(_content);
                
            }
            catch (Exception e)
            {

            }
        }

        // Remove top screen from stack
        public void RemoveScreen()
        {
            if (_screens.Count > 0)
            {
                try
                {
                    var screen = _screens.Peek();
                    _screens.Pop();
                }
                catch (Exception e)
                {

                }
            }
        }

        // Clear all screens from stack
        public void ClearScreens()
        {
            while (_screens.Count > 0) _screens.Pop();    
        }

        // Clear all the screens when adding a new one
        public void ChangeScreen(GameState screen)
        {
            try
            {
                ClearScreens();
                AddScreen(screen);
            }
            catch (Exception e)
            {

            }
        }

        // Updates screen on top from stack
        public void Update(GameTime gameTime)
        {
            try
            {
                if (_screens.Count > 0) _screens.Peek().Update(gameTime);
            }
            catch (Exception e)
            {

            }
        }

        // Draws screen on top from stack
        public void Draw(SpriteBatch spriteBatch)
        {
            try
            {
                if(_screens.Count > 0) _screens.Peek().Draw(spriteBatch);
            }
            catch (Exception e)
            {

            }
        }


        public void UnloadContent()
        {
            foreach (GameState state in _screens)
            {
                state.UnloadContent();
            }
        }
    }
}
