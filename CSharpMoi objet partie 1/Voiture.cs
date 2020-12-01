using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMoi_objet_partie_1
{
    class Voiture : VehiculeAMoteur
    {
        public Voiture(string marque, string modele, double volumeInitial) : base(marque, modele)
        {
            MoteurV.VolumeReservoir = volumeInitial;
            MoteurV.VolumeTotal = volumeInitial;
        }

        public void Rouler(double volume)
        {
            Demarrer();
            MoteurV.Utiliser(volume);
        }

        public override string ToString()
        {
            return "Voiture : " + marque + " " + modele + ", Reservoir : " + MoteurV.VolumeReservoir + "L";
        }

    }
}
