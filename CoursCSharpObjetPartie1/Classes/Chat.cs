using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    class Chat : IAnimal
    {
        public void Crier()
        {
            Console.WriteLine("Le chat miaule");
        }
    }
}
