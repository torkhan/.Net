using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    class Voiture : VehiculeAMoteur
    {
        public event Action<decimal, string> Promotion;

        decimal prix;

        public decimal Prix { get => prix; set => prix = value; }


        public Voiture(string marque, string modele, double volumeInitial, decimal prix) : base(marque, modele)
        {
            MoteurV.VolumeReservoir = volumeInitial;
            MoteurV.VolumeTotal = volumeInitial;
            Prix = prix;
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

        public void Reduction(decimal reduction)
        {
            Prix -= reduction;
            if(Promotion != null)
            {
                Promotion(Prix, modele);
            }
        }
    }
}
