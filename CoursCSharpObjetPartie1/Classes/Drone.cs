using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    class Drone : IVolant
    {
        public void Voler()
        {
            Console.WriteLine("Je vole tout seul");
        }
    }
}
