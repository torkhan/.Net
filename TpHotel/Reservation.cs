using System;
using System.Collections.Generic;
using System.Text;

namespace TpHotel
{
    class Reservation
    {
        int numeroChambre;
        DateTime arrivee;
        DateTime depart;
        int NbrePersonne;
        string status;
        List<Client> clients;
        List<Chambre> chambres;

        public Reservation(int numeroChambre, DateTime arrivee, DateTime depart, int nbrePersonne1, string status, List<Client> clients, List<Chambre> chambres)
        {
            NumeroChambre = numeroChambre;
            Arrivee = arrivee;
            Depart = depart;
            NbrePersonne1 = nbrePersonne1;
            Status = status;
            Clients = clients;
            Chambres = chambres;
        }

        public int NumeroChambre { get => numeroChambre; set => numeroChambre = value; }
        public DateTime Arrivee { get => arrivee; set => arrivee = value; }
        public DateTime Depart { get => depart; set => depart = value; }
        public int NbrePersonne1 { get => NbrePersonne; set => NbrePersonne = value; }
        public string Status { get => status; set => status = value; }
        internal List<Client> Clients { get => clients; set => clients = value; }
        internal List<Chambre> Chambres { get => chambres; set => chambres = value; }


        public void AjoutReservation()
        {

        }
        public void ModifierReservation()
        {

        }
        public void AnnulerReservation()
        {

        }
    }   
}
