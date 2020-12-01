using System;
using System.Collections.Generic;
using System.Text;

namespace Annuaire
{
    class IHM
    {
        private Annuaire annuaire;

        public IHM()
        {
            annuaire = new Annuaire();
        }
        public void Start()
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
                        ActionAjouterContact();
                        break;
                    case "2":
                        ActionModifierContact();
                        break;
                    case "3":
                        ActionSupprimerContact();
                        break;
                    case "4":
                        Contact contact = ActionRechercherContact();
                        if(contact != null)
                        {
                            Console.WriteLine(contact);
                        }
                        else
                        {
                            Console.WriteLine("Aucun contact avec ce nom");
                        }
                        break;
                    case "0":
                        break;
                }
            } while (choix != "0");
        }

        private void MenuPrincipal()
        {
            Console.WriteLine("1--- Ajouter un contact");
            Console.WriteLine("2--- Modifier un contact");
            Console.WriteLine("3--- Supprimer un contact");
            Console.WriteLine("4--- Rechercher un contact par son nom ");
        }

        private void ActionAjouterContact()
        {
            Contact contact = new Contact();
            Console.Write("Nom : ");
            contact.Nom = Console.ReadLine();
            Console.Write("Prénom : ");
            contact.Prenom = Console.ReadLine();
            Console.Write("Téléphone : ");
            contact.Telephone = Console.ReadLine();
            if(annuaire.Contacts.Count > 0)
            {
                contact.Id = annuaire.Contacts[annuaire.Contacts.Count - 1].Id + 1;
            }
            else
            {
                contact.Id = 1;
            }
            annuaire.Contacts.Add(contact);
            annuaire.SaveContactsFile();
        }
        private void ActionModifierContact()
        {
            Contact contact = ActionRechercherContact();
            if(contact != null)
            {
                Console.Write("Merci de saisir le nouveau numéro de téléphone : ");
                contact.Telephone = Console.ReadLine();
                annuaire.SaveContactsFile();
            }
            else
            {
                Console.WriteLine("Aucun contact avec ce nom");
            }
        }

        private void ActionSupprimerContact()
        {
            Contact contact = ActionRechercherContact();
            if (contact != null)
            {
                annuaire.Contacts.Remove(contact);
                annuaire.SaveContactsFile();
            }
            else
            {
                Console.WriteLine("Aucun contact avec ce nom");
            }
        }

        private Contact ActionRechercherContact()
        {
            Console.Write("Nom du contact : ");
            string nom = Console.ReadLine();
            return annuaire.Contacts.Find(c => c.Nom == nom);
        }
    }
}
