using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Annuaire
{
    class Annuaire
    {
        List<Contact> contacts;
        private string fileName = "contacts.csv";
        public List<Contact> Contacts { get => contacts; set => contacts = value; }

        public Annuaire()
        {
            Contacts = new List<Contact>();
            GetContactsFromFile();
        }

        public void GetContactsFromFile()
        {
            if(File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
                string ligne = reader.ReadLine();
                while(ligne != null)
                {
                    ligne = reader.ReadLine();
                    if(ligne != null)
                    {
                        string[] content = ligne.Split(';');
                        Contact c = new Contact(Convert.ToInt32(content[0]), content[1], content[2], content[3]);
                        Contacts.Add(c);
                    }
                }
                reader.Close();
            }
        }

        public void SaveContactsFile()
        {
            StreamWriter writer = new StreamWriter(fileName);
            writer.WriteLine("id;nom;prénom;téléphone");
            foreach(Contact c in Contacts)
            {
                writer.WriteLine($"{c.Id};{c.Nom};{c.Prenom};{c.Telephone}");
            }
            writer.Close();
        }
    }
}
