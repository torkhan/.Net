using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling
{
     public class Game
    {
        List<Frame> frames;

        public Game()
        {
        }

        public List<Frame> Frames { get => frames; set => frames = value; }
    }
}
