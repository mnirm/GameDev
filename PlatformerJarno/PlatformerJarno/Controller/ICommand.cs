using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatformerJarno.Entities;

namespace PlatformerJarno.Controller
{
    interface ICommand
    {
        void Excecute(Player player, InputHandler.ControlAction action);
    }
}
