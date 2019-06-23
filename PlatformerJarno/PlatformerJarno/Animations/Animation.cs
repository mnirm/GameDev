using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace PlatformerJarno.Animations
{
    class Animation
    {
        // Properties
        private readonly List<AnimationFrame> _frames;
        private int _fps;
        private int _totalWidth = 0;
        private double _offset;

        public AnimationFrame CurrentFrame { get; private set; }

        // Constructor
        public Animation(int spriteWidth, int spriteYPos, int fps = 1)
        {
            _fps = fps;

            _frames = new List<AnimationFrame>();
        }

        // Methods

        public void AddFrame(Rectangle rectangle)
        {
            AnimationFrame newFrame = new AnimationFrame()
            {
                SourceRectangle = rectangle
            };
            
            _frames.Add(newFrame);

            CurrentFrame = _frames[0];

            _offset = CurrentFrame.SourceRectangle.Width;
            foreach (var frame in _frames)
                _totalWidth += frame.SourceRectangle.Width;
        }

        private int _counter = 0;
        private double _x = 0;
        public void Update(GameTime gameTime)
        {
            double temp = CurrentFrame.SourceRectangle.Width * ((double) gameTime.ElapsedGameTime.Milliseconds / 1000);
            _x += temp;

            if (_x >= CurrentFrame.SourceRectangle.Width / _fps)
            {
                _x = 0;
                ++_counter;
                if (_counter >= _frames.Count)
                    _counter = 0;

                CurrentFrame = _frames[_counter];

                _offset += CurrentFrame.SourceRectangle.Width;
            }

            if (_offset >= _totalWidth)
                _offset = 0;
        }
    }
}
