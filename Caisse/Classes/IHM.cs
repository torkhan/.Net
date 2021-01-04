using System;
using System.Collections.Generic;
using System.Text;

namespace Caisse.Classes
{
    class IHM
    {
        private DataBase data;
        private Panier panier;

        public IHM()
        {
            data = DataBase.Instance;
            ActionPrincipal();
        }

        private void MenuPrincipal()
        {
            Console.WriteLine("1--Ajouter un produit");
            Console.WriteLine("2--Vente");
        }

        private void ActionPrincipal()
        {
            string choix;

            do
            {
                MenuPrincipal();
                choix = Console.ReadLine();
                Console.Clear();
                switch(choix)
                {
                    case "1":
                        ActionAjouterProduit();
                        break;
                    case "2":
                        ActionVente();
                        break;
                    case "0":
                        data.UpdateDataBase();
                        Environment.Exit(0);
                        break;
                }
            } while (choix != "0");
        }


        private void ActionAjouterProduit()
        {
            Produit produit = new Produit();
            Console.Write("Merci de saisir le titre du produit : ");
            produit.Titre = Console.ReadLine();
            Console.Write("Merci de saisir le prix : ");
            produit.Prix = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Merci de saisir le stock initial : ");
            produit.Stock = Convert.ToInt32(Console.ReadLine());
            if(data.SaveProduit(produit))
            {
                Console.WriteLine("Produit ajouté avec l'id " + produit.Id);
            }
            else
            {
                Console.WriteLine("Erreur insertion base de données");
            }
            clearConsole();
        }

        private void clearConsole()
        {
            Console.WriteLine("Entrez une touche pour continuer...");
            Console.ReadLine();
            Console.Clear();
        }
        private void ActionVente()
        {
            int codeProduit;
            panier = new Panier();
            do
            {
                Console.Write("Code produit : ");
                codeProduit = Convert.ToInt32(Console.ReadLine());
                if(codeProduit != 0)
                {
                    Produit produit = data.GetProduitById(codeProduit);
                    if (produit != null)
                    {
                        panier.AddProduit(produit);
                        data.DescStock(produit.Id);
                        Console.WriteLine(produit);
                    }
                    else
                    {
                        Console.WriteLine("Aucun produit avec ce code");
                    }
                }
                else
                {
                    Console.WriteLine("=========Panier==========");
                    Console.WriteLine(panier);
                    data.SavePanier(panier);
                }
               
            } while (codeProduit != 0);
            clearConsole();
        }
    }
}
