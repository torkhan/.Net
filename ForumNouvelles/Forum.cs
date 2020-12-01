using System;
using System.Collections.Generic;
using System.Text;

namespace ForumNouvelles
{
    class Forum
    {
        //attributs
        string nom;
        string date;
     

        

        //propriétés
        public string Nom { get => nom; set => nom = value; }
        public string Date { get => date; set => date = value; }

        //constructeurs
        public Forum(string nom, string date)
        {
            Nom = nom;
            Date = date;
        }
    }
}
