using System;
using System.Collections.Generic;
using System.Text;

namespace TpHotel
{
    class Employe : Personne
    {
        int matricule;

        public Employe(int matricule, string nom, string prenom, string telephone) : base(nom, prenom, telephone)
        {
            Matricule = matricule;
        }

        public int Matricule { get => matricule; set => matricule = value; }
    }
}
