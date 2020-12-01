using CorrectionCompteBancaire.Classes;
using System;

namespace CorrectionCompteBancaire
{
    class Program
    {
        static void Main(string[] args)
        {
            IHM ihm = new IHM();
            ihm.Start();
        }
    }
}
