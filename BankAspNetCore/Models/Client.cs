using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BankAspNetCore.Models
{
    public class Client
    {
        private int id;
        private string nom;
        private string prenom;
        private string telephone;

        

        public string Nom
        {
            get => nom; set
            {
                nom = value;
            }
        }
        public string Prenom
        {
            get => prenom; set
            {
                prenom = value;
            }
        }
        public string Telephone
        {
            get => telephone; set
            {
                telephone = value;
            }
        }

        public int Id { get => id; set => id = value; }

        public Client()
        {

        }
        public Client(string nom, string prenom, string telephone)
        {
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
        }

        public Client(int id, string nom, string prenom, string telephone) : this(nom, prenom, telephone)
        {
            this.id = id;
        }

        public bool Save()
        {
            DataDbContext.Instance.Clients.Add(this);
            DataDbContext.Instance.SaveChanges();
            return Id > 0;
        }

        public static Client GetClientById(int id)
        {
            return DataDbContext.Instance.Clients.Find(id);
        }

        public override string ToString()
        {
            return $"Nom : {Nom}, Prénom : {Prenom}, Téléphone : {Telephone}";
        }


    }
}
