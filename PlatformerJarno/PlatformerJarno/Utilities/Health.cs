using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerJarno.Utilities
{
    class Health
    {
        // Properties
        public int Amount
        {
            get { return _health; }
        }

        private int _health;

        // Constructor
        public Health(int health)
        {
            _health = health;
        }

        // Methods
        public void ReceiveDamage(int damageReceived)
        {
            if (damageReceived >= 0) _health -= damageReceived;
            else throw new ArgumentException("You can't heal this unit whit this method.");
        }

        public void ReceiveHealing(int healingReceived)
        {
            if (healingReceived >= 0) _health += healingReceived;
            else throw new ArgumentException("You can't do damage to a unit with this method.");
        }
    }
}
