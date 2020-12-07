using System;
using System.Collections.Generic;
using System.Text;

namespace GestionHotel.Classes
{
    public class Hotel
    {
        private int id;
        private string nom;
        private string adresse;
        private string telephone;

        private List<Chambre> chambres;
        private List<Reservation> reservations;
        private List<Client> clients;

        public string Nom { get => nom; set => nom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public List<Chambre> Chambres { get => chambres; set => chambres = value; }
        public List<Reservation> Reservations { get => reservations; set => reservations = value; }
        public List<Client> Clients { get => clients; set => clients = value; }
        public int Id { get => id; set => id = value; }

        public Hotel()
        {
            Chambres = new List<Chambre>();
            Reservations = new List<Reservation>();
            Clients = new List<Client>();
        }

        public Hotel(int id, string nom, string adresse, string telephone) : this()
        {
            this.id = id;
            this.nom = nom;
            this.adresse = adresse;
            this.telephone = telephone;
        }
    }
}
