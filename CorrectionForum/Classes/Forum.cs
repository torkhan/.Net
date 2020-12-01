using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionForum.Classes
{
    public class Forum
    {
        string nom;
        DateTime dateCreation;
        List<Nouvelle> nouvelles;
        List<Abonne> abonnes;
        Moderateur moderateur;

        public string Nom { get => nom; set => nom = value; }
        public DateTime DateCreation { get => dateCreation; }
        public List<Nouvelle> Nouvelles { get => nouvelles; set => nouvelles = value; }
        public List<Abonne> Abonnes { get => abonnes; set => abonnes = value; }
        public Moderateur Moderateur { get => moderateur; set => moderateur = value; }

        public Forum(string nom)
        {
            Nouvelles = new List<Nouvelle>();
            Abonnes = new List<Abonne>();
            Nom = nom;
            dateCreation = DateTime.Now;
        }

        public Nouvelle GetNouvelleById(int id)
        {
            //Nouvelle nouvelle = null;
            //foreach(Nouvelle n in Nouvelles)
            //{
            //    if(n.Id == id)
            //    {
            //        nouvelle = n;
            //        break;
            //    }
            //}
            //return nouvelle;
            return Nouvelles.Find(n => n.Id == id);
        }

        public Abonne GetAbonneByEmail(string email)
        {
            //Abonne ab = null;
            //foreach (Abonne a in Abonnes)
            //{
            //    if (a.Email == email)
            //    {
            //        ab = a;
            //        break;
            //    }
            //}
            //return ab;
            return Abonnes.Find(a => a.Email == email);
        }

        public override string ToString()
        {
            return $"{Nom}, {DateCreation}";
        }
    }
}
