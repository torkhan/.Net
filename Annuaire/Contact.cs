using System;
using System.Collections.Generic;
using System.Text;

namespace Annuaire
{
    class Contact
    {
        int id;
        string nom;
        string prenom;
        string telephone;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
       
        public Contact()
        {

        }
        public Contact(int id, string nom, string prenom, string telephone)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
        }

        public override string ToString()
        {
            return $"Nom : {Nom}, Prénom : {Prenom}, Téléphone : {Telephone}";
        }
    }
}
