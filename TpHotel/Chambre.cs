using System;
using System.Collections.Generic;
using System.Text;

namespace TpHotel
{
    class Chambre
    {
        int numeroChambre;
        int capacite;
        ChambreStatus status;

        public Chambre(int numeroChambre, int capacite, string status)
        {
            NumeroChambre = numeroChambre;
            Capacite = capacite;
            
        }

        public int NumeroChambre { get => numeroChambre; set => numeroChambre = value; }
        public int Capacite { get => capacite; set => capacite = value; }
       

        public void RechercherChambreVide()
        {

        }
        
        public void ModifierStatut()
        {

        }
    }
    enum ChambreStatus
    {
        Libre,
        Occupé
    }
}
