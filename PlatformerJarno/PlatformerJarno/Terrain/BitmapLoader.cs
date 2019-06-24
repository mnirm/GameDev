using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace PlatformerJarno.Terrain
{
    class BitmapLoader
    {
        // Properties
        private Bitmap _image;
        private int[,] _coordinates;
        private ICollection<Block> _terrain;

        // Constructor
        public BitmapLoader(Bitmap bitmap)
        {
            _image = new Bitmap(bitmap);
            _coordinates = new int[_image.Width,_image.Height];
            _terrain = new List<Block>();

            int x, y;
            for (y = 0; y < _image.Height; y++)
            {
                for (x = 0; x < _image.Width; x++)
                {
                    _coordinates[x, y] = _image.GetPixel(x, y).ToArgb();
                }
            }
        }

        // Methods

        public ICollection<Block> GetTerrain(ContentManager content, string terrainSprite)
        {
            int x, y;
            for (y = 0; y < _image.Height; y++)
            {
                for (x = 0; x < _image.Width; x++)
                {
                    if (_coordinates[x, y] != 0)
                    {
                        AddBlock(content, terrainSprite, x, y);
                    }
                }
            }
            return _terrain;
        }

        private void AddBlock(ContentManager content, string path, int x, int y)
        {
            _terrain.Add(new Block(content, path, new Vector2(x * 20, y * 20)));
        }
    }
}
