using System;
using System.Collections.Generic;
using System.Text;

namespace GestionHotel.Classes
{
    public class Chambre
    {
        private int id;
        private int numero;

        private int capacite;

        private ChambreStatut statut;

        private decimal tarif;

        public int Numero { get => numero; set => numero = value; }
        public int Capacite { get => capacite; set => capacite = value; }
        public ChambreStatut Statut { get => statut; set => statut = value; }
        public decimal Tarif { get => tarif; set => tarif = value; }
        public int Id { get => id; set => id = value; }
        public Chambre()
        {

        }
        public Chambre(int numero, int capacite, string statut, decimal tarif, int id)
        {
            Numero = numero;
            Capacite = capacite;
            Enum.TryParse(statut, out this.statut);
            Tarif = tarif;
            Id = id;
        }
    }

    public enum ChambreStatut
    {
        Libre,
        Occupe
    }
}
