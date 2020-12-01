using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMoi_objet_partie_1
{
    class Etudiant : Personne
    {
        private int niveau;

        public int Niveau { get => niveau; set => niveau = value; }

        public Etudiant() : base()
        {

        }

        public Etudiant(string nom, string prenom, int age, int niveau) : base(nom, prenom, age)
        {
            Niveau = niveau;
        }

        // réécriture de la méthode afficher de Peronnes

        public override void Afficher()
        {
            base.Afficher();
            AfficherEtudiant();
        }

        public void AfficherEtudiant()
        {
            Console.WriteLine("Etudiant : " + "Niveau : " + Niveau);
        }
    }
}
