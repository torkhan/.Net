using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMoi_objet_partie_1
{
    abstract class VehiculeAMoteur : Vehicule
    {
        Moteur moteurV;
        public VehiculeAMoteur(string marque, string modele) : base(marque, modele)
        {
            MoteurV = new Moteur();
        }

        public Moteur MoteurV { get => moteurV; set => moteurV = value; }

        public override bool Demarrer()
        {
            return MoteurV.Demarrer();
        }
        public override void Arreter()
        {
            MoteurV.Arreter();
        }

        public override void FaireLePlein(double volume)
        {
            Arreter();
            MoteurV.FaireLePlein(volume);
            Demarrer();
        }
    }
}
   
