using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    class AgeException : Exception
    {
        public AgeException() : base("Format age incorrect")
        {

        }
    }
}
