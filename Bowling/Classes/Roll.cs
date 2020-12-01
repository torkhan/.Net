using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Classes
{
    public class Roll
    {
        int pin;

        public int Pin { get => pin; }

        public Roll(int pin)
        {
            this.pin = pin;
        }
    }
}
