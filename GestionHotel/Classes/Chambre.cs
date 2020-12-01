using System;
using System.Collections.Generic;
using System.Text;

namespace GestionHotel.Classes
{
    class Chambre
    {
        private int numero;

        private int capacite;

        private ChambreStatut statut;

        private decimal tarif;

        public int Numero { get => numero; set => numero = value; }
        public int Capacite { get => capacite; set => capacite = value; }
        public ChambreStatut Statut { get => statut; set => statut = value; }
        public decimal Tarif { get => tarif; set => tarif = value; }
    }

    enum ChambreStatut
    {
        Libre,
        Occupe
    }
}
