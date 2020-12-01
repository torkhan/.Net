using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire
{
    class Client
    {
        string Nom;
        string Prenom;
        string Telephone;
        public CompteBancaire compteBancaire;

        public Client(string nom, string prenom, string telephone)
        {
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
        }

        public string Nom1 { get => Nom; set => Nom = value; }
        public string Prenom1 { get => Prenom; set => Prenom = value; }
        public string Telephone1 { get => Telephone; set => Telephone = value; }
       
    }
}
