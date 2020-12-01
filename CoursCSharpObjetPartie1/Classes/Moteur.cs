using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    class Moteur
    {
        double volumeReservoir;
        double volumeTotal;
        bool demarre = false;

        public double VolumeReservoir { get => volumeReservoir; set => volumeReservoir = value; }
        public double VolumeTotal { get => volumeTotal; set => volumeTotal = value; }
        public bool Demarre { get => demarre; set => demarre = value; }

        public bool Demarrer()
        {
            if(!Demarre)
            {
                if (VolumeReservoir > 0.1)
                {
                    Console.WriteLine("Moteur démarre....");
                    VolumeReservoir -= 0.1;
                    Demarre = true;
                }
                else
                    Console.WriteLine("Reservoir vide");
            }
            return Demarre;
        }

        public double Utiliser(double volumeUtilise)
        {
            if(VolumeReservoir > volumeUtilise)
            {
                Console.WriteLine("Moteur  a utilisé " + volumeUtilise + " L");
                VolumeReservoir = VolumeReservoir - volumeUtilise;
            }
            else
            {
                Console.WriteLine("Moteur a utilisé " + VolumeReservoir + " L et vous etes en panne d'essence");
                VolumeReservoir = 0;
                Demarre = false;
            }
            return VolumeReservoir;
        }

        public void FaireLePlein(double volume)
        {
            Console.WriteLine("On ajoute " + volume + "au reservoir");
            VolumeReservoir = VolumeReservoir + volume;
            VolumeTotal = VolumeTotal + volume;
        }

        public void Arreter()
        {
            Console.WriteLine("On arrete le moteur");
            Demarre = false;    
        }
    }
}
