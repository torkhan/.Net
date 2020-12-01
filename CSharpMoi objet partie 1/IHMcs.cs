using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMoi_objet_partie_1
{
    class IHM
    {
        Salarie[] employes;
        int maxEmployes = 20;
        int compteurEmployes = 0;

        public IHM()
        {
            employes = new Salarie[maxEmployes];
        }

        public void Start()
        {
            Console.WriteLine("=====Gestion des employés=====");
            string choix;
            do
            {
                MenuPrincipal();
                choix = Console.ReadLine();
                switch (choix)
                {
                    case "1":
                        CreationEmploye();
                        break;
                    case "2":
                        SalaireEmployes();
                        break;
                    case "3":
                        RechercheEmploye();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                }
            } while (choix != "0");
        }
        private void MenuPrincipal()
        {
            Console.WriteLine("1-- Ajouter un employé ");
            Console.WriteLine("2-- Afficher le salaire des employés");
            Console.WriteLine("3-- Rechercher un employé");
            Console.WriteLine("0-- Quitter");
        }

        private void MenuCreationEmploye()
        {
            Console.WriteLine("1-- Salarié");
            Console.WriteLine("2-- Commerciale");
        }

        private void CreationEmploye()
        {
            MenuCreationEmploye();
            string choix = Console.ReadLine();
            Salarie s = null;
            switch (choix)
            {
                case "1":
                    s = CreationSalarie();
                    break;
                case "2":
                    s = CreationCommerciale();
                    break;
            }
            if (s != null)
            {
                employes[compteurEmployes] = s;
                compteurEmployes++;
            }
        }

        private Salarie CreationSalarie()
        {
            Console.Write("Merci de saisir le nom : ");
            string nom = Console.ReadLine();
            Console.Write("Merci de saisir le matricule : ");
            string mat = Console.ReadLine();
            Console.Write("Merci de saisir la categorie: ");
            string cat = Console.ReadLine();
            Console.Write("Merci de saisir le service : ");
            string service = Console.ReadLine();
            Console.Write("Merci de saisir le salaire: ");
            decimal salaire = Convert.ToDecimal(Console.ReadLine());
            return new Salarie(mat, cat, service, nom, salaire);
        }

        private Commerciale CreationCommerciale()
        {
            Salarie tmpSalarie = CreationSalarie();
            Console.Write("Merci de saisir le chiffre d'affaire du commerciale : ");
            decimal chiffreAffaire = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Merci de saisir la commission : ");
            int commission = Convert.ToInt32(Console.ReadLine());
            return new Commerciale(tmpSalarie.Matricule, tmpSalarie.Categorie, tmpSalarie.Service, tmpSalarie.Nom, tmpSalarie.Salaire, chiffreAffaire, commission);
        }

        private void SalaireEmployes()
        {
            Console.WriteLine("====Salaire des employés=====");
            for (int i = 0; i < compteurEmployes; i++)
            {
                employes[i].CalculerSalaire();
                Console.WriteLine("----------");
            }
        }

        private void RechercheEmploye()
        {
            Console.WriteLine("====Rercherche employé par nom=====");
            Console.Write("Merci de saisir le nom : ");
            string nom = Console.ReadLine();
            Salarie s = null;
            for (int i = 0; i < compteurEmployes; i++)
            {
                if (employes[i].Nom == nom)
                {
                    s = employes[i];
                    break;
                }
            }
            if (s != null)
            {
                s.CalculerSalaire();
            }
            else
            {
                Console.WriteLine("aucun employé avec ce nom");
            }
        }
    }
}
