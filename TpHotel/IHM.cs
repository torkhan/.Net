using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TpHotel
{
    class IHM
    {
        private Hotel hotel;
        public string fileName = @"C:\Users\Torkhan\Desktop\listeClients.csv";

        public IHM()
        {
            hotel = new Hotel();

        }
        public void Start()
        {
            string choix;
            do
            {
                MenuClients();
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
                        AfficherListeClients();
                        break;
                }

            } while (choix != "0");

        }
        public void MenuClients()
        {
            Console.WriteLine("1--- Ajouter un client");
            Console.WriteLine("2--- Modifier un client");
            Console.WriteLine("3--- Supprimer un client");
            Console.WriteLine("4--- Afficher la listes des clients ");
        }
        private void ActionAjouterClient()
        {
            Client client = new Client();
            Console.Write("Nom : ");
            client.Nom = Console.ReadLine();
            Console.Write("Prenom : ");
            client.Prenom = Console.ReadLine();
            Console.Write("Telephone : ");
            client.Telephone = Console.ReadLine();
            if (hotel.Clients.Count > 0)
            {
                client.NumeroClient = hotel.Clients[hotel.Clients.Count - 1].NumeroClient + 1;
            }
            else
            {
                client.NumeroClient = 1;
            }
            hotel.Clients.Add(client);
            hotel.SaveClientsFile();
        }
        private void ActionModifierClient()
        {
            Client client = ActionRechercherClient();
            if (client != null)
            {
                Console.Write("Merci de saisir le nouveau numéro de téléphone : ");
                client.Telephone = Console.ReadLine();
                hotel.SaveClientsFile();
            }
            else
            {
                Console.WriteLine("Aucun client avec ce nom");
            }
        }

        private void ActionSupprimerClient()
        {
            Client client = ActionRechercherClient();
            if (client != null)
            {
                hotel.Clients.Remove(client);
                hotel.SaveClientsFile();
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
            return hotel.Clients.Find(c => c.Nom == nom);
        }
        private void AfficherListeClients()
        {
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
              
              
                   
                reader.Close();

            }
        }
    }
}
