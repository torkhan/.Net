using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionCompteBancaire.Classes
{
    class IHMBanque
    {
        private Banque banque;

        public void Start()
        {
            banque = new Banque();
            ActionPrincipal();
        }

        private void MenuPrincipal()
        {
            Console.WriteLine("1----Création compte");
            Console.WriteLine("2----Effectuer un dépôt");
            Console.WriteLine("3----Effectuer un retrait");
            Console.WriteLine("4----Afficher opération et solde");
            Console.WriteLine("5----Calcule Interet");
            Console.WriteLine("6----Gestion fichier clients");
        }

        private void MenuCreationCompte()
        {
            Console.WriteLine("1---Compte courant");
            Console.WriteLine("2---Compte Epargne");
            Console.WriteLine("3---Compte Payant");
        }

        private void ActionPrincipal()
        {
            string choix;
            do
            {
                MenuPrincipal();
                choix = Console.ReadLine();
                Console.Clear();
                switch (choix)
                {
                    case "1":
                        ActionCreationCompte();
                        break;
                    case "2":
                        ActionDepot();
                        break;
                    case "3":
                        ActionRetrait();
                        break;
                    case "4":
                        ActionAffichage();
                        break;
                    case "5":
                        ActionCalculeInteret();
                        break;
                    case "6":
                        ActionGestionClient();
                        break;
                }
            } while (choix != "0");
        }

        private void ActionGestionClient()
        {
            Console.WriteLine("1--- Ajouter un client");
            Console.WriteLine("2--- Modifier un client");
            Console.WriteLine("3--- Supprimer un client");
            Console.WriteLine("4--- Rechercher un client par son nom ");
            Console.WriteLine("0--- Exit ");
            MenuClient();
        }
        private void MenuClient()
        {
            string choix;
            do
            {
                choix = Console.ReadLine();
                Console.Clear();
                switch (choix)
                {
                    case "1":
                        ActionAjouterClient();
                        break;
                    case "2":
                        ActionModifierClient();
                        break;
                    case "3":
                        ActionSupprimerClient();
                        break;
                    case "4":
                        Client client = ActionRechercherClient();
                        if (client != null)
                        {
                            Console.WriteLine(client);
                        }
                        else
                        {
                            Console.WriteLine("Aucun client avec ce nom");
                        }
                        break;
                }
            } while (choix != "0");

        }
        private void ActionAjouterClient()
        {
            Console.WriteLine("Aucun client avec ce nom");
            Client client = new Client();
            Console.Write("Nom : ");
            client.Nom = Console.ReadLine();
            Console.Write("Prénom : ");
            client.Prenom = Console.ReadLine();
            Console.Write("Téléphone : ");
            client.Telephone = Console.ReadLine();
            if (banque.Clients.Count > 0)
            {
                client.Id = banque.Clients[banque.Clients.Count - 1].Id + 1;
            }
            else
            {
                client.Id = 1;
            }
            banque.Clients.Add(client);
            banque.SaveClientsFiles();
        }
        private void ActionModifierClient()
        {
            Client contact = ActionRechercherClient();
            if (contact != null)
            {
                Console.Write("Merci de saisir le nouveau numéro de téléphone : ");
                contact.Telephone = Console.ReadLine();
                banque.SaveClientsFiles();
            }
            else
            {
                Console.WriteLine("Aucun client avec ce nom");
            }
        }

        private void ActionSupprimerClient()
        {
            Client contact = ActionRechercherClient();
            if (contact != null)
            {
                banque.Clients.Remove(contact);
                banque.SaveClientsFiles();
            }
            else
            {
                Console.WriteLine("Aucun client avec ce nom");
            }
        }

        private Client ActionRechercherClient()
        {
            Console.Write("Nom du client : ");
            string nom = Console.ReadLine();
            return banque.Clients.Find(c => c.Nom == nom);
        }
        private Client ActionCreationClient()
        {
            Client client = new Client();
            //bool error = false;
            //do
            //{
            //    Console.Write("Nom : ");
            //    try
            //    {
            //        client.Nom = Console.ReadLine();
            //        error = false;
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //        error = true;
            //    }
            //} while (error);

            //do
            //{
            //    Console.Write("Prénom : ");
            //    try
            //    {
            //        client.Prenom = Console.ReadLine();
            //        error = false;
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //        error = true;
            //    }
            //} while (error);

            //do
            //{
            //    Console.Write("Téléphone : ");
            //    try
            //    {
            //        client.Telephone = Console.ReadLine();
            //        error = false;
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //        error = true;
            //    }
            //} while (error);    
            Tools.TryParseProperty("Nom : ", client, "Nom");
            Tools.TryParseProperty("Prénom : ", client, "Prenom");
            Tools.TryParseProperty("Téléphone : ", client, "Telephone");
            return client;
        }
        private void ActionCreationCompte()
        {
            Console.WriteLine("======Création de compte======");
            MenuCreationCompte();
            string choix = Console.ReadLine();
            Compte compte = null;
            Client client = ActionCreationClient();
            string response = "";
            switch (choix)
            {
                case "1":
                    Console.Write("Dépôt initial : ((o)ui/ (n)on)");
                    response = Console.ReadLine();
                    if(response == "o")
                    {
                        Console.Write("Solde : ");
                        decimal soldeInitial = Convert.ToDecimal(Console.ReadLine());
                        compte = new Compte(client, soldeInitial);
                    }
                    else
                    {
                        compte = new Compte(client);
                    }
                    break;
                case "2":
                    Console.Write("Taux Interet : ");
                    decimal taux = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Dépôt initial : ((o)ui/ (n)on)");
                    response = Console.ReadLine();
                    if (response == "o")
                    {
                        Console.Write("Solde : ");
                        decimal soldeInitial = Convert.ToDecimal(Console.ReadLine());
                        compte = new CompteEpargne(client, taux, soldeInitial);
                        (compte as CompteEpargne).DoubleEpargne += NotificationDoubleCompteEpargne;
                    }
                    else
                    {
                        compte = new CompteEpargne(client, taux);
                    }
                    break;
                case "3":
                    Console.Write("Cout opération : ");
                    decimal cout = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Dépôt initial : ((o)ui/ (n)on)");
                    response = Console.ReadLine();
                    if (response == "o")
                    {
                        Console.Write("Solde : ");
                        decimal soldeInitial = Convert.ToDecimal(Console.ReadLine());
                        compte = new ComptePayant(client, cout, soldeInitial);
                    }
                    else
                    {
                        compte = new ComptePayant(client, cout);
                    }
                    break;
            }
            if(compte != null)
            {
                compte.ADecouvert += NotificationCompteADecouvert;
                banque.Comptes.Add(compte);
                Console.WriteLine("Compte bancaire crée avec le numéro " + compte.Numero);
            }
        }

        private void ActionDepot()
        {
            Compte compte = ActionChercherCompte();
            if (compte == null)
            {
                Console.WriteLine("Aucun compte avec ce numéro");
            }else
            {
                Console.Write("Montant du dépôt : ");
                decimal montant = Convert.ToDecimal(Console.ReadLine());
                if(compte.Depot(montant))
                {
                    Console.WriteLine("Dépôt effectué, nouveau solde " + compte.Solde);
                }
                else
                {
                    Console.WriteLine("Erreur dépôt");
                }
            }
        }

        private void ActionRetrait()
        {
            Compte compte = ActionChercherCompte();
            if (compte == null)
            {
                Console.WriteLine("Aucun compte avec ce numéro");
            }
            else
            {
                Console.Write("Montant du retrait : ");
                decimal montant = Convert.ToDecimal(Console.ReadLine());
                if (compte.Retrait(montant))
                {
                    Console.WriteLine("Retrait effectué, nouveau solde " + compte.Solde);
                }
                else
                {
                    Console.WriteLine("Erreur retrait");
                }
            }
        }
        private void ActionAffichage()
        {
            Compte compte = ActionChercherCompte();
            if(compte == null)
            {
                Console.WriteLine("Aucun compte avec ce numéro");
            }
            else {
                Console.WriteLine("=======Solde et opération========");
                Console.WriteLine(compte);
            }
        }

        private Compte ActionChercherCompte()
        {
            Console.Write("Numéro de compte : ");
            int numero = Convert.ToInt32(Console.ReadLine());
            Compte compte = banque.GetCompteById(numero);
            //if(compte!= null)
            //{
            //    compte.ADecouvert += NotificationCompteADecouvert;
            //}
            return compte;
        }

        private void ActionCalculeInteret()
        {
            Compte compte = ActionChercherCompte();
            if (compte == null)
            {
                Console.WriteLine("Aucun compte avec ce numéro");
            }
            else
            {
                if(compte is CompteEpargne compteEpargne)
                {
                    compteEpargne.CalculeInteret();
                }
                else
                {
                    Console.WriteLine("Ce n'est pas un compte epargne");
                }
            }
        }


        private void NotificationCompteADecouvert(decimal solde, int numero)
        {
            Console.WriteLine($"Le compte N° {numero} est dans le rouge, le solde est de : {solde} euros");
        }

        private void NotificationDoubleCompteEpargne(decimal solde, int nbre)
        {
            Console.WriteLine($"Bravo votre epargne a doublé, votre nouveau solde est de {solde} euros en {nbre} années");
        }
    }
}
