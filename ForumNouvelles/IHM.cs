using System;
using System.Collections.Generic;
using System.Text;

namespace ForumNouvelles
{
    class IHM
    {
        
        public void Start()
        {
            Console.WriteLine("======Bienvenue sur le fofo qu il est bo=========");
            Console.WriteLine("");
            menuLog();


        }
        public void menuLog()
        {
            Console.WriteLine("====Etes-vous?====");
            Console.WriteLine("");
            Console.WriteLine("1-Abonné");
            Console.WriteLine("2-Modérateur");
            string choixLog = Console.ReadLine();
            if (choixLog == "1")
            {
                string choix;
                do
                {
                    menuAbo();
                    choix = Console.ReadLine();
                    switch (choix)
                    {
                        case "1":
                            Abonnes A = new Abonnes( "","",0);
                            A.DemandeAbonnement();
                            break;
                        case "2":
                           
                            break;
                        case "3":
                            break;
                        case "4":
                            break;
                        case "5":
                            break;
                        case "0":
                            Environment.Exit(0);
                            break;

                    }



                } while (choix != "0");
            }
            else if (choixLog == "2")
            {
                menuMode();
            }
            else
            {
                Console.WriteLine("Tu sais taper sur 1 ou 2?");
            }
        }
        public void menuAbo()
        {
            Console.WriteLine("1-Demande d'inscription");
            Console.WriteLine("2-Créer une nouvelle");
            Console.WriteLine("3-Publier une nouvelle");
            Console.WriteLine("4-Consulter une nouvelle");
            Console.WriteLine("5-Répondre à une nouvelle");
            Console.WriteLine("");
            MenuExit();



        }
        public void menuMode()
        {
            menuAbo();
            Console.WriteLine("6-Supprimer une nouvelle");
            Console.WriteLine("7-Bannir un abonné crocro vilain");
            Console.WriteLine("8-Ajouter un abonné");
            Console.WriteLine("9-Lister les nouvelles");
            Console.WriteLine("10-Lister les abonnés");
            Console.WriteLine("");
            MenuExit();

        }
        public void MenuExit()
        {
            Console.WriteLine("0-Quitter");
        }

    }
}
