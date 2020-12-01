using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    class Chien : IAnimal
    {
        public void Crier()
        {
            Console.WriteLine("Le chien aboye");
        }
    }
}
