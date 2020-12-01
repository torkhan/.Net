using System;
using System.Collections.Generic;
using System.Text;

namespace ForumNouvelles
{
    class Nouvelles
    {
        //attributs
        
       
        int compteur;
        string sujet;
        string texte;

        //propriétés
        public Nouvelles(string sujet, string texte)
        {
            Sujet = sujet;
            Texte = texte;
        }
        //constructeurs
        public string Sujet { get => sujet; set => sujet = value; }
        public string Texte { get => texte; set => texte = value; }
       
        public int Compteur { get => compteur; set => compteur = value; }
    }
}
