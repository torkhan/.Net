using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire
{
    class IHM

    {
        private CompteBancaire compteBancaire;

        public void Start()
        {

            string choix;
            do {
                Menu();
                choix = Console.ReadLine();
               
                switch (choix)
                {
                    case "1":
                        
                      

                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;

                }
                
            } while (choix != "0") ;

        }
        public void Menu()
        {
            Console.WriteLine("=======Menu========");
            Console.WriteLine("                ");
            Console.WriteLine("1--OUvrir un compte bancaire");
            Console.WriteLine("2--Effectuer un dépôt");
            Console.WriteLine("3--Effectuer un retrait");
            Console.WriteLine("4--Afficher opérations et solde");
        }
        private void ActionCreationCompte()
        {
           
        }
    }
}
