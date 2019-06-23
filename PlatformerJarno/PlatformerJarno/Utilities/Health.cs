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
    class Health
    {
        // Properties
        public int Amount { get; private set; }

        private List<Sprite> _hearts;
        private List<Vector2> _heartsPositions;
        private float _scale;
        private Entity _entity;

        // Constructor
        public Health(int health, ContentManager content, Entity entity, float scale = 1)
        {
            _scale = scale/2;
            Amount = health;
            _entity = entity;
            _hearts = new List<Sprite>();
            _heartsPositions = new List<Vector2>();

            for (int h = 0; h < health; h++)
            {
                _heartsPositions.Add(new Vector2(entity.Position.X + (h * 17 * _scale), entity.Position.Y - (20 * _scale)));
                _hearts.Add(new Sprite(content, "heart", _heartsPositions[h], _scale));
            }
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

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Amount; i++)
            {
                _hearts[i].Draw(spriteBatch, position:_heartsPositions[i]);
            }
        }

        public void Update()
        {
            for (int i = 0; i < Amount; i++)
            {
                _heartsPositions[i] = new Vector2(_entity.Position.X - 2 * _scale + (17 * i * _scale), _entity.Position.Y - 20 * _scale);
            }
        }
    }
}
