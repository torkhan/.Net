using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Classes
{
    public class Generator : IGenerator
    {
        public int GetRandomPins(int max)
        {
            Random r = new Random();
            return r.Next(0, max + 1);
        }
    }
}
