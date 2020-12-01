using CoursCSharpObjetPartie1.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1
{
    abstract class Personne
    {
        public static int compteur = 0;
        //Attributs
        protected string nom;
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
        public int Age
        {
            get => age;
            set
            {
                if(value > 0 && value < 110)
                    age = value;
                else
                    throw new AgeException();
            }
        }

        //Constructeurs
        public Personne()
        {
            Console.WriteLine("Construction d'un objet");
            compteur++;
        }



        public Personne(string nom, string prenom, int age)
        {
            this.nom = nom;
            this.Prenom = prenom;
            this.Age = age;
            compteur++;
        }

        //Méthodes

        public virtual void Afficher()
        {
            Console.WriteLine(nom + " " + Prenom);
        }

        //public virtual void Afficher()
        //{
        //    Console.WriteLine(nom + " " + Prenom); 
        //}

       // public abstract void Afficher();


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

        public override string ToString()
        {
            return "Nom : " + Nom + " " +
                "Prénom : " + Prenom + "" +
                " Age : " + Age;
        }


        //public static Personne CreatePersonne(string nom, string prenom, int age)
        //{
        //    Personne p = new Personne(nom, prenom, age);
        //    return p;
        //}

        //Déstructeur
        ~Personne()
        {
            Console.WriteLine("Objet détriut");
        }
    }
}
