using System;
using System.Collections.Generic;
using System.Text;

namespace ForumNouvelles
{
    class Abonnes : Utilisateurs
    {

        //constructeurs
        public  Abonnes(string nom, string prenom, int age) : base(nom, prenom, age)
        {
        }
        //méthodes
        public virtual void DemandeInscription()
        {
           
            Console.WriteLine("test");

        }


        public void CreerNouvelle()
        {

        }
        public virtual void DeposerNouvelle()
        {
        }
        public void ConsulterNouvelle()
        {

        }
        public void RepondreNouvelle()
        {

        }

    }
}
