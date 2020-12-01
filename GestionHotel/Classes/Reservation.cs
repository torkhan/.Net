using System;
using System.Collections.Generic;
using System.Text;

namespace GestionHotel.Classes
{
    class Reservation
    {
        private int id;
        private List<Chambre> chambres;
        private ReservationStatut statut;
        private Client client;

        private decimal total;
        public int Id { get => id; set => id = value; }
        public List<Chambre> Chambres { get => chambres; set => chambres = value; }
        public ReservationStatut Statut { get => statut; set => statut = value; }
        public Client Client { get => client; set => client = value; }
        public decimal Total { get => total; set => total = value; }
    }

    enum ReservationStatut
    {
        Valide,
        Annule
    }
}
