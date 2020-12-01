using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TpHotel
{
    class Hotel
    {
        string nom;
        string adresse;
        string telephone;
        List<Client> clients;
        List<Employe> employes;
        List<Chambre> chambres;
        List<Reservation> reservations;

        public string fileName = @"C:\Users\Torkhan\Desktop\listeClients.csv";

        public Hotel(string nom, string adresse, string telephone, List<Client> clients, List<Employe> employes, List<Chambre> chambres)
        {
            Nom = nom;
            Adresse = adresse;
            Telephone = telephone;
            Clients = clients;
            Employes = employes;
            Chambres = chambres;
            Clients = new List<Client>();
            Employes = new List<Employe>();
            Chambres = new List<Chambre>();
            GetClientsFromFile();

        }
        public Hotel()
        {
            Clients = new List<Client>();
        }

        public string Nom { get => nom; set => nom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public List<Client> Clients { get => clients; set => clients = value; }
        public List<Employe> Employes { get => employes; set => employes = value; }
        public List<Chambre> Chambres { get => chambres; set => chambres = value; }

        public void GetClientsFromFile()
        {
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
                string ligne = reader.ReadLine();
                while (ligne != null)
                {
                    ligne = reader.ReadLine();
                    if (ligne != null)
                    {
                        string[] content = ligne.Split(';');
                        Client c = new Client(Convert.ToInt32(content[0]), content[1], content[2], content[3]);
                        Clients.Add(c);
                    }
                }
                reader.Close();
            }
        }
        public void SaveClientsFile()
        {
            StreamWriter writer = new StreamWriter(fileName);
            writer.WriteLine("numeroClient;nom;prenom;telephone");
            foreach (Client c in Clients)
            {
                writer.WriteLine($"{c.NumeroClient};{c.Nom};{c.Prenom};{c.Telephone}");
            }
            writer.Close();
        }
        public void AfficheListClient()
        {
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
               reader.ReadToEnd();
                {
                    foreach(Client c in clients) { 
                       
                        Console.Write($"{c.NumeroClient};{c.Nom};{c.Prenom};{c.Telephone}");
                    }
                }
                reader.Close();

            }
        }
    }
}
