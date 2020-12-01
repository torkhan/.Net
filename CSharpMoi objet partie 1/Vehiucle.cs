using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMoi_objet_partie_1
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
