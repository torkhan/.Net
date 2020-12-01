using System;
using System.Collections.Generic;
using System.Text;

namespace TpHotel
{
    class Facture
    {
        int numeroFacture;
        List<Reservation> reservations;
        List<Client> clients;

        public Facture(int numeroFacture, List<Reservation> reservations, List<Client> clients)
        {
            NumeroFacture = numeroFacture;
            Reservations = reservations;
            Clients = clients;
        }

        public int NumeroFacture { get => numeroFacture; set => numeroFacture = value; }
        internal List<Reservation> Reservations { get => reservations; set => reservations = value; }
        internal List<Client> Clients { get => clients; set => clients = value; }

        public void CreerFacture()
        {

        }
    }
}
