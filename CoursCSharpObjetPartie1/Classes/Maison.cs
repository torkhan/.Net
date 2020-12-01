using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    class Maison<T>
    {
        T[] habitants;

        public Maison(int nombre)
        {
            habitants = new T[nombre];
        }

        public T Recuperer(int index)
        {
            return habitants[index];
        }
    }
}
