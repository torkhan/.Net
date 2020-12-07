using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorrectionCompteBancaire.Classes
{
    class Banque
    {
        List<Compte> comptes;
        public List<Compte> Comptes { get => comptes; set => comptes = value; }


        private Sauvegarde sv;
        public Banque()
        {
            sv = new Sauvegarde();
            Comptes = sv.GetComptes();
        }
        public Compte GetCompteById(int id)
        {
            //Compte compte = null;
            //foreach(Compte c in Comptes)
            //{
            //    if(c.Numero == id)
            //    {
            //        compte = c;
            //        break;
            //    }
            //}
            //Compte compte = Comptes.FirstOrDefault(c => c.Numero == id);
            //return compte;
            return Comptes.Find(c => c.Numero == id);
        }

        public void Sauvegarde()
        {
            sv.Save(Comptes);
        }

        public int LastCompteNumber()
        {
            return Comptes.Count;
        }


    }
}
