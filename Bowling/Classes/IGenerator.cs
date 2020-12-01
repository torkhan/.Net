using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Classes
{
    public interface IGenerator
    {
        int GetRandomPins(int max);
    }
}
