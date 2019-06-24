using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using PlatformerJarno.Entities;

namespace PlatformerJarno.Controller
{
    // Class for handling input of the user
    class InputHandler
    {
        // Properties
        private Player _player;
        private ControlAction _currentAction;
        private Commands _commands;

        public enum ControlAction
        {
            Left, Right, Jump, Attack, Idle
        }

        // Constructor
        public InputHandler(Player player)
        {
            _player = player;
            _commands = new Commands();
        }

        //Method

        public void HandleInput()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Up)) _currentAction = ControlAction.Jump;
            else if (state.IsKeyDown(Keys.Space)) _currentAction = ControlAction.Attack;
            else if (state.IsKeyDown(Keys.Right)) _currentAction = ControlAction.Right;
            else if (state.IsKeyDown(Keys.Left)) _currentAction = ControlAction.Left;
            else _currentAction = ControlAction.Idle;

            _commands.Excecute(_player, _currentAction);
        }
    }
}
