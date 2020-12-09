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
            //if(annuaire.Contacts.Count > 0)
            //{
            //    contact.Id = annuaire.Contacts[annuaire.Contacts.Count - 1].Id + 1;
            //}
            //else
            //{
            //    contact.Id = 1;
            //}
            //annuaire.Contacts.Add(contact);
            //annuaire.SaveContactsFile();

            if(contact.Save())
            {
                Console.WriteLine("Contact ajouté avec l'id " + contact.Id);
            }
            else {
                Console.WriteLine("Erreur insertion base de données");
            }
        }
        private void ActionModifierContact()
        {
            Contact contact = ActionRechercherContact();
            if(contact != null)
            {
                Console.Write("Merci de saisir le nouveau nom : ");
                contact.Nom = Console.ReadLine();
                Console.Write("Merci de saisir le nouveau prénom : ");
                contact.Prenom= Console.ReadLine();
                Console.Write("Merci de saisir le nouveau numéro de téléphone : ");
                contact.Telephone = Console.ReadLine();
                if(contact.Update())
                {
                    Console.WriteLine("Modification effectuée");
                }
                else
                {
                    Console.WriteLine("Erreur base de données");
                }
                //annuaire.SaveContactsFile();
            }
            else
            {
                Console.WriteLine("Aucun contact avec cet id");
            }
        }

        private void ActionSupprimerContact()
        {
            Contact contact = ActionRechercherContact();
            if (contact != null)
            {
                if (contact.Delete())
                {
                    Console.WriteLine("Suppression effectuée");
                }
                else
                {
                    Console.WriteLine("Erreur base de données");
                }
                //annuaire.Contacts.Remove(contact);
                //annuaire.SaveContactsFile();
            }
            else
            {
                Console.WriteLine("Aucun contact avec cet id");
            }
        }

        private Contact ActionRechercherContact()
        {
            //Console.Write("Nom du contact : ");
            //string nom = Console.ReadLine();
            //return annuaire.Contacts.Find(c => c.Nom == nom);
            Console.Write("Id du contact : ");
            int id = Convert.ToInt32(Console.ReadLine());
            return Contact.GetContactById(id);
        }
    }
}
