using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionCompteBancaire.Classes
{
    class Client
    {
        private string nom;
        private string prenom;
        private string telephone;

        public string Nom
        {
            get => nom; set
            {
                if (Tools.CheckName(value))
                    nom = value;
                else
                    throw new Exception("Erreur nom");
            }
        }
        public string Prenom
        {
            get => prenom; set
            {
                if (Tools.CheckName(value))
                    prenom = value;
                else
                    throw new Exception("Erreur prénom");
            }
        }
        public string Telephone
        {
            get => telephone; set
            {
                if (Tools.CheckPhone(value))
                    telephone = value;
                else
                    throw new Exception("Erreur téléphone");
            }
        }

        public Client()
        {

        }
        public Client(string nom, string prenom, string telephone)
        {
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
        }

        public override string ToString()
        {
            return $"Nom : {Nom}, Prénom : {Prenom}, Téléphone : {Telephone}";
        }


    }
}
