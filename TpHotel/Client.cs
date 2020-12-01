using System;
using System.Collections.Generic;
using System.Text;

namespace TpHotel
{
     class Client : Personne
    {
        int numeroClient;
        List<Reservation> reservations;

        public Client()
        {
        }

        public Client(int numeroClient, string nom, string prenom, string telephone) : base (nom, prenom, telephone)
        {
            NumeroClient = numeroClient;

        }
       

       

        public int NumeroClient { get => numeroClient; set => numeroClient = value; }
        internal List<Reservation> Reservations { get => reservations; set => reservations = value; }

        public void EregisterClient()
        {

        }
        public override string ToString()
        {
            return $"Id : {NumeroClient}, Nom : {Nom}, Prénom : {Prenom}, Téléphone : {Telephone}";
        }


    }
}
