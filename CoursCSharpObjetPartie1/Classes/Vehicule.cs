using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    abstract class Vehicule
    {
        protected string marque;
        protected string modele;

        public Vehicule(string marque, string modele)
        {
            this.marque = marque;
            this.modele = modele;
        }

        public abstract bool Demarrer();
        public abstract void Arreter();
        public abstract void FaireLePlein(double volume);
    }
}
