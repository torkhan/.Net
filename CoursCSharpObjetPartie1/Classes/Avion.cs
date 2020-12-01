using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    class Avion : IVolant
    {
        public void Voler()
        {
            Console.WriteLine("Je peux voler grâce à des réacteurs");
        }
    }
}
