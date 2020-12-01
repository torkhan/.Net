using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMoi_objet_partie_1
{
    class Personne
    {
       //public static int compteur = 0;
        //Attributs
        private string nom;
        private string prenom;
        private int age;
        private Adresse adresse;

        //Proprietés
        public string Nom
        {
            get
            {
                return nom;
            }
            set
            {
                if (value.Length > 2)
                    nom = value;
                else
                    Console.WriteLine("Erreur nom");
            }
        }

        public string Prenom { get => prenom; set => prenom = value; }
        public int Age { get => age; set => age = value; }

        //Constructeurs
        public Personne()
        {
            //Console.WriteLine("Construction d'un objet");
            //compteur++;
        }

        public Personne(string nom, string prenom, int age)
        {
            this.nom = nom;
            this.Prenom = prenom;
            this.Age = age;
           // compteur++;
        }

        //Méthodes
        public virtual void Afficher()//virtual autorise les réécritures par les classe enfants voitr Etudiants
        {

            Console.WriteLine(nom + " " + Prenom);

        }

        //public void SetNom(string n)
        //{
        //    if(n.Length > 2)
        //    {
        //        nom = n;
        //    }
        //    Console.WriteLine("Erreur saisi nom");
        //}
        //public string GetNom()
        //{
        //    return nom;
        //}

        public static Personne CreatePersonne(string nom, string prenom, int age)
        {
            Personne p = new Personne(nom, prenom, age);
            return p;
        }

        //Déstructeur
        ~Personne()
        {
            Console.WriteLine("Objet détriut");
        }
    }
}
