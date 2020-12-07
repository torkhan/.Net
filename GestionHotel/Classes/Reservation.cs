using System;
using System.Collections.Generic;
using System.Text;

namespace GestionHotel.Classes
{
    public class Reservation
    {
        private int id;
        private int numero;
        private List<Chambre> chambres;
        private ReservationStatut statut;
        private Client client;

        private decimal total;
        public int Id { get => id; set => id = value; }
        public List<Chambre> Chambres { get => chambres; set => chambres = value; }
        public ReservationStatut Statut { get => statut; set => statut = value; }
        public Client Client { get => client; set => client = value; }
        public decimal Total
        {
            get
            {
                return total;
            }
            set => total = value;
        }
        public int Numero { get => numero; set => numero = value; }

        public Reservation(int id, string statut, int clientId, decimal total, int numero)
        {
            Id = id;
            Chambres = chambres;
            Enum.TryParse(statut, out this.statut);
            Client = new Client();
            Client.Id = clientId;
            Total = total;
            Numero = numero;
        }

        public void UpdateTotal()
        {
            decimal t = 0;
            Chambres.ForEach((c) =>
            {
                t += c.Tarif;
            });
            total = t;
        }
    }

    public enum ReservationStatut
    {
        Valide,
        Annule
    }
}
