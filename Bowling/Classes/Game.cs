using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Classes
{
    public class Game
    {
        private IGenerator _generator;
        private List<Frame> frames;
        private int maxFrames = 10;
        private int currentFrame;
        public List<Frame> Frames { get => frames; set => frames = value; }
        public int GlobalScore { get; }

        public Game(IGenerator g)
        {
            _generator = g;
            currentFrame = 1;
        }

        public void Play()
        {
            throw new Exception("En cours de dev");
        }
    }
}
