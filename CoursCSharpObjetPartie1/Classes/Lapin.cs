using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    class Lapin : IAnimal
    {
        public void Crier()
        {
            Console.WriteLine("Le lapin est muet");
        }

        public void Manger()
        {
            Console.WriteLine("Le lapin qui mange");
        }
    }
}
