using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMoi_objet_partie_1
{
    class Contact
    {
        int index;
        string nom;
        string prenom;
        string telephone;

        public Contact(int index, string nom, string prenom, string telephone)
        {
            this.index = index;
            this.nom = nom;
            this.prenom = prenom;
            this.telephone = telephone;
        }

        public int Index { get => index; set => index = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
    }
}
