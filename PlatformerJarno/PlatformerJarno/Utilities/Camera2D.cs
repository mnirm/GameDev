
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlatformerJarno.Utilities
{
    class Camera2D
    {
        // Properties
        private float _zoom;
        private float _rotation;
        private Matrix _transformMatrix;
        public Vector2 Position { get; set; }
        public float Zoom
        {
            get => _zoom;
            set => _zoom = (_zoom < 0.1f)? 0.1f : value;
        }
        public float Rotation
        {
            get => _rotation;
            set => _rotation = value;
        }

        // Constructor
        public Camera2D()
        {
            _zoom = 1f;
            _rotation = 0.0f;
            Position = Vector2.Zero;
        }

        // Methods
        public void MoveCamera(Vector2 amount)
        {
            Position = amount;
        }

        public Matrix GetTransformationMatrix(GraphicsDevice graphicsDevice)
        {
            _transformMatrix = 
                Matrix.CreateTranslation(
                    new Vector3(-Position.X, -Position.Y, 0)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));
            return _transformMatrix;
        }
    }
}
