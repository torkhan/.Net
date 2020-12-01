﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GestionHotel.Classes
{
    class Hotel
    {
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
    }
}
