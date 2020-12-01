using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionForum.Classes
{
    class IHM
    {
        private Forum forum;
        public void Start()
        {
            CreationForum();
            CreationModerateur();
            ActionPrincipal();
        }

        private void CreationForum()
        {
            Console.WriteLine("===============Gestion Forum==============");
            Console.Write("Nom du Forum : ");
            string nom = Console.ReadLine();
            forum = new Forum(nom);
            Console.Clear();
        }

        private void CreationModerateur()
        {
            Console.WriteLine("====Création du modérateur=====");
            Abonne tmpAbonne = CreationAbonne();
            Moderateur moderateur = new Moderateur(tmpAbonne.Nom, tmpAbonne.Prenom, tmpAbonne.Age, tmpAbonne.Email, forum);
            forum.Moderateur = moderateur;
            Console.Clear();
        }

        public Abonne CreationAbonne()
        {
            Console.Write("Nom : ");
            string nom = Console.ReadLine();
            Console.Write("Prénom : ");
            string prenom = Console.ReadLine();
            Console.Write("Age : ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Mail : ");
            string email = Console.ReadLine();
            return new Abonne(nom, prenom, age, email, forum);
        }

        private void MenuPrincipal()
        {
            Console.WriteLine("1--- Modérateur");
            Console.WriteLine("2--- Abonné");
            Console.WriteLine("0--- Quitter");
        }

        private void MenuAbonne()
        {
            Console.WriteLine("1--- Ajouter une nouvelle");
            Console.WriteLine("2--- Répondre à une nouvelle");
            Console.WriteLine("3--- Lister les nouvelles");
        }

        private void MenuModerateur()
        {
            MenuAbonne();
            Console.WriteLine("4--- Ajouter un abonné");
            Console.WriteLine("5--- Bannir un abonné");
            Console.WriteLine("6--- Lister les abonnés");
            Console.WriteLine("7--- Supprimer une nouvelle");
        }

        private void ActionPrincipal()
        {
            Console.WriteLine("========" + forum.ToString() + "========");
            string choix;
            do
            {
                MenuPrincipal();
                choix = Console.ReadLine();
                switch(choix)
                {
                    case "1":
                        if (CheckModerateur())
                        {
                            ActionModerateur();
                        }
                        else
                        {
                            Console.WriteLine("Erreur modérateur");
                        }
                        break;
                    case "2":
                        Abonne abonne = CheckAbonne();
                        if (abonne != null)
                        {
                            ActionAbonne(abonne);
                        }
                        else
                        {
                            Console.WriteLine("Erreur Abonné");
                        }
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                }
            } while (choix != "0");
        }

        private void ActionModerateur()
        {
            Console.WriteLine("=====Menu modérateur=====");
            string choix;
            do
            {
                MenuModerateur();
                choix = Console.ReadLine();
                switch(choix)
                {
                    case "1":
                        ActionAjouterNouvelle(forum.Moderateur);
                        break;
                    case "2":
                        ActionRepondreNouvelle(forum.Moderateur);
                        break;
                    case "3":
                        ActionListerNouvelle();
                        break;
                    case "4":
                        ActionAjouterAbonne();
                        break;
                    case "5":
                        ActionBannirAbonne();
                        break;
                    case "6":
                        ActionListerAbonne();
                        break;
                    case "7":
                        ActionSupprimerNouvelle();
                        break;
                }
            } while (choix != "0");
        }

        private void ActionAjouterNouvelle(Abonne abonne)
        {
            Console.Write("Sujet nouvelle : ");
            string sujet = Console.ReadLine();
            Console.Write("Description nouvelle : ");
            string description = Console.ReadLine();
            abonne.AjouterNouvelle(sujet, description);
            Console.WriteLine("*******Nouvelle ajoutée********");
        }

        private void ActionRepondreNouvelle(Abonne abonne)
        {
            ActionListerNouvelle();
            Console.Write("Id de la nouvelle : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Nouvelle nouvelle = forum.GetNouvelleById(id);
            if(nouvelle == null)
            {
                Console.WriteLine("aucune nouvelle avec cet id");
            }
            else
            {
                Console.Write("Description nouvelle : ");
                string description = Console.ReadLine();
                abonne.RepondreNouvelle(nouvelle, description);
            }
        }

        private void ActionListerNouvelle()
        {
            Console.WriteLine("----Liste des nouvelles------");
            foreach(Nouvelle n in forum.Nouvelles)
            {
                Console.WriteLine(n);
            }
        }

        private void ActionAjouterAbonne()
        {
            Console.WriteLine("----Ajouter un abonné");
            Abonne a = CreationAbonne();
            forum.Moderateur.AjouterAbonne(a);
            Console.WriteLine("*******Abonné ajouté********");
        }

        private void ActionBannirAbonne()
        {
            Console.WriteLine("-----Bannir un abonné-------");
            Abonne ab = CheckAbonne();
            if(ab != null)
            {
                forum.Moderateur.BannirAbonne(ab.Email);
                Console.WriteLine("*****Abonné supprimé******");
            }else
            {
                Console.WriteLine("----Aucun abonné avec cet email");
            }
        }

        private void ActionListerAbonne()
        {
            Console.WriteLine("-----Liste des abonnés-------");
            foreach(Abonne a in forum.Abonnes)
            {
                Console.WriteLine(a);
            }
        }

        private void ActionSupprimerNouvelle()
        {
            ActionListerNouvelle();
            Console.Write("Id nouvelle à supprimer : ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (forum.Moderateur.SupprimerNouvelle(id))
            {
                Console.WriteLine("*******Nouvelle supprimée");
            }else
            {
                Console.WriteLine("----Aucune nouvelle avec cet id");
            }

        }

        private void ActionAbonne(Abonne abonne)
        {
            Console.WriteLine("=====Menu Abonné=====");
            string choix;
            do
            {
                MenuAbonne();
                choix = Console.ReadLine();
                switch (choix)
                {
                    case "1":
                        ActionAjouterNouvelle(abonne);
                        break;
                    case "2":
                        ActionRepondreNouvelle(abonne);
                        break;
                    case "3":
                        ActionListerNouvelle();
                        break;
                }
            } while (choix != "0");
        }


        private bool CheckModerateur()
        {
            Console.Write("Email : ");
            string email = Console.ReadLine();
            return forum.Moderateur.Email == email;
        } 

        private Abonne CheckAbonne()
        {
            Console.Write("Email : ");
            string email = Console.ReadLine();
            Abonne ab = forum.GetAbonneByEmail(email);
            return ab;
        }
    }
}
