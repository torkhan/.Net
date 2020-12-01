using System;
using System.Collections.Generic;
using System.Text;

namespace TpHotel
{
    public abstract class Personne
    {
        string nom;
        string prenom;
        string telephone;


        public Personne()
        {

        }
        public Personne(string nom, string prenom, string telephone)
        {
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
        }

        public string Prenom { get => prenom; set => prenom = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Telephone { get => telephone; set => telephone = value; }

        public override string ToString()
        {
            return $"Nom : {Nom}, Prénom {Prenom}, Téléphone {Telephone}";
        }
    }

}
