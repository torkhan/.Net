using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionForum.Classes
{
    public class Abonne
    {
        string nom;
        string prenom;
        int age;
        string email;

        Forum forum;

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public int Age { get => age; set => age = value; }
        public Forum Forum { get => forum; set => forum = value; }
        public string Email { get => email; set => email = value; }

        public Abonne(string n, string p, int a,string e, Forum f)
        {
            Nom = n;
            Prenom = n;
            Age = a;
            Email = e;
            Forum = f;
        }

        public Nouvelle CreationNouvelle(string sujet, string description)
        {
            Nouvelle n = new Nouvelle(sujet, description);
            n.Id = Forum.Nouvelles.Count + 1;
            return n;
        }

        public void AjouterNouvelle(string sujet, string description)
        {
            Nouvelle n = CreationNouvelle(sujet, description);
            Forum.Nouvelles.Add(n);
        }

        public void RepondreNouvelle(Nouvelle nouvelle, string description)
        {
            AjouterNouvelle(nouvelle.Sujet, description);
        }

        public override string ToString()
        {
            return $"Nom : {Nom}, Prénom : {Prenom}, Age : {Age}, Email : {Email}";
        }
    }
}
