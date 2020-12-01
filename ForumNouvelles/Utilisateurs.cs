using System;
using System.Collections.Generic;
using System.Text;

namespace ForumNouvelles
{
   class Utilisateurs
    {
        //attributs
        string nom;
        string prenom;
        int age;

        //propiétés
        public Utilisateurs(string nom, string prenom, int age)
        {
            Nom = nom;
            Prenom = prenom;
            Age = age;
        }

        //constructeurs
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public int Age { get => age; set => age = value; }

        //méthodes

        public void DemandeAbonnement()
        {
           
        }
    }
}
