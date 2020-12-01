using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMoi_objet_partie_1
{
    class IHMNote
    {
        int nbreApprenant;
        int[] notes;
        string choixMenu;

        public void Start()
        {
            Console.WriteLine("=====Gestion des notes=====");
            Console.WriteLine("                         ");
            Console.Write("Entrez le nombres d'apprenants:");
            
            nbreApprenant = Convert.ToInt32(Console.ReadLine());
            notes = new int[nbreApprenant];

            do
            {
                MenuPrincipal();
                choixMenu = Console.ReadLine();
                switch (choixMenu)
                {
                    case "1":
                        SaisieNotes();
                        break;
                    case "2":
                        AfficherNotes();
                        break;
                    case "3":
                        PlusGrandeNote();
                        break;
                    case "4":
                        PlusPetiteNote();
                        break;
                    case "5":
                        Moyenne();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;

                }

            } while (choixMenu != "0");
        }
        private void MenuPrincipal()
        {
            Console.WriteLine("                         ");
            Console.WriteLine("=====Gestion des notes=====");
            Console.WriteLine("                         ");
            Console.WriteLine("1----Saisir les notes");
            Console.WriteLine("2----Afficher les notes");
            Console.WriteLine("3----La plus grande note");
            Console.WriteLine("4----La plus petite note");
            Console.WriteLine("5----La moyenne des notes");
            Console.WriteLine("0----Quitter");

        }
        private void SaisieNotes()
        {
            Console.Clear();
            Console.WriteLine("------Saisir les notes------");
            Console.WriteLine("                         ");
            for (int i = 0; i < notes.Length; i++)
            {
                Console.Write("La note de l'apprenant N° " + (i + 1) + " : ");
                notes[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        private void AfficherNotes()
        {
            Console.Clear();
            Console.WriteLine("------Afficher les notes------");
            Console.WriteLine("                         ");
            for (int i = 0; i < notes.Length; i++)
            {
                Console.WriteLine("La note de l'apprennant n° " + (i + 1) + " est: " + notes[i]);
            }
        }
        private void PlusGrandeNote()
        {
            Console.Clear();
            Console.WriteLine("------Afficher la plus haute note------");
            Console.WriteLine("                         ");
            int max;
            max = notes[0];
            for (int i = 1; i < notes.Length; i++)
            {
                if (max < notes[i])
                {
                    max = notes[i];
                }
            }
            Console.WriteLine("La note la plus haute est: " + max);
        }
        private void PlusPetiteNote()
        {
            Console.Clear();
            Console.WriteLine("------Afficher la plus petite note------");
            Console.WriteLine("                         ");
            int max;
            max = notes[0];
            for (int i = 1; i < notes.Length; i++)
            {
                if (max > notes[i])
                {
                    max = notes[i];
                }
            }
            Console.WriteLine("La note la plus petite est: " + max);
        }
        private void Moyenne()
        {
            Console.Clear();
            Console.WriteLine("------Afficher la moyenne des notes------");
            Console.WriteLine("                         ");
            int somme = 0;
            for (int i =0; i < notes.Length; i++)
            {
                somme += notes[i];
            }
            double moyenne = somme / notes.Length;
            Console.WriteLine("La moyenne des notes est: " + moyenne);
        }
    }
}
