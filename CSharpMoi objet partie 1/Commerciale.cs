using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMoi_objet_partie_1
{
    class Commerciale : Salarie
    {
        decimal chiffreAffaire;
        int commission;

        public decimal ChiffreAffaire { get => chiffreAffaire; set => chiffreAffaire = value; }
        public int Commission { get => commission; set => commission = value; }

        public Commerciale() : base()
        {

        }
        public Commerciale(string matricule, string categorie, string service, string nom, decimal salaire, decimal chiffreAffaire, int commission) : base(matricule, categorie, service, nom, salaire)
        {
            ChiffreAffaire = chiffreAffaire;
            Commission = commission;
        }

        public override void CalculerSalaire()
        {
            base.CalculerSalaire();
            decimal salaireReel = Salaire + chiffreAffaire * commission / 100;
            Console.WriteLine("Le salaire avec commission de " + Nom + " est " + salaireReel + " euros");
        }
    }
}
