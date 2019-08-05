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
    // EntityHealth shows the health graphical
    class EntityHealth : Health
    {
        // Properties
        private Entity _entity;
        private float _scale;
        private List<Sprite> _hearts;
        private List<Vector2> _heartsPositions;

        // Constructor
        public EntityHealth(int health, ContentManager content, Entity entity, float scale = 1) : base(health)
        {
            _scale = scale / 2;
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

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Amount; i++)
            {
                _hearts[i].Draw(spriteBatch, position: _heartsPositions[i]);
            }
        }

        public void Update()
        {
            for (int i = 0; i < Amount; i++)
            {
                _heartsPositions[i] = new Vector2((_entity.Position.X - 2 * _scale) - 10 + (17 * i * _scale), _entity.Position.Y - 20 * _scale);
            }
        }
    }
}
