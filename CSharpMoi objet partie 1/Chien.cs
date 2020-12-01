using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMoi_objet_partie_1
{
    class Chien
    {
         //Attributs
        private string race;
        private string couleur;
        private string nom;

        //propriétés
        public string Race
        {
            get
            {
                return race;
            }
            set
            {
                race = value;
            }
        }

        public string Couleur { get => couleur; set => couleur = value; }

        //constructeur
        public Chien(string race, string couleur, string nom)
        {
            this.race = race;
            this.Couleur = couleur;
            this.nom = nom;
        }
        //méthodes
        public void Aboyer()
        {
            Console.WriteLine("Le chien" + " " + nom + " " + "fait ouah ouah!");
        }



    }
}
