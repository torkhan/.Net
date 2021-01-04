using coursWPF.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace coursWPF.ViewModels
{
    public class WindowWithContextViewModel
    {
        private Personne personne;
        private Adresse adresse;

        public Adresse Adresse { get => adresse; set => adresse = value; }
        public Personne Personne { get => personne; set => personne = value; }

        public string Nom
        {
            get
            {
                return Personne.Nom;
            }
            set
            {
                Personne.Nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return Personne.Prenom;
            }
            set
            {
                Personne.Prenom= value;
            }
        }

        public string Rue
        {
            get
            {
                return Adresse.Rue;
            }
            set
            {
                Adresse.Rue = value;
            }
        }

        public string Ville
        {
            get
            {
                return Adresse.Ville;
            }
            set
            {
                Adresse.Ville = value;
            }
        }
        public WindowWithContextViewModel()
        {
            personne = new Personne();
            adresse = new Adresse();
        }
    }
}
