using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PlatformerJarno.Entities;
using PlatformerJarno.Sprites;

namespace PlatformerJarno.Utilities
{
    // Health class able to give anything health substract from it add health to it and get the remaining health
    class Health
    {
        // Properties
        public int Amount { get; private set; }

        // Constructor
        public Health(int health)
        {
            Amount = health;
        }

        // Methods
        public void ReceiveDamage(int damageReceived)
        {
            if (damageReceived >= 0) Amount -= damageReceived;
            else throw new ArgumentException("You can't heal this unit whit this method.");
        }

        public void ReceiveHealing(int healingReceived)
        {
            if (healingReceived >= 0) Amount += healingReceived;
            else throw new ArgumentException("You can't do damage to a unit with this method.");
        }
    }
}
