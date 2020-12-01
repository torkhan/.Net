using System;
using System.Collections.Generic;
using System.IO;

namespace CSharpMoi_objet_partie_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int compteur = 0;

            //Personne p1 = new Personne();
            /* p1.nom = "toto";
             p1.prenom = "tata";
             Personne p2 = new Personne();
             p2.nom = "titi";
             p2.prenom = "tutu";
             Adresse a = new Adresse();
             a.rue = "tilleuls";*/
            //p1.Nom = "tutu";

            //p1.Afficher();
            /*p2.Afficher();*/

            // Personne p3 = new Personne("trotro", "kiki", 12);
            // p3.Afficher();
            /* Chien chienNoir = new Chien("Dogue", "noir", "Filou");
             chienNoir.Aboyer();
             chienNoir.Couleur = "noir";*/

            // pour démarrer le garbage collector
            // GC.Collect();
            // Console.WriteLine(Personne.compteur);


            //exo salarie
            /*Salarie s1 = new Salarie();
            s1.Nom = "Maurice";
            s1.SalaireReçu = 3000;
            s1.CalculerSalaire();
            Salarie s2 = new Salarie(8552, "Cadre", "Compta", "Gilbert", 2500);
            s2.CalculerSalaire();

            Salarie.ResetCompteur();*/
            // Personne p1 = new Personne();
            //p1.nom = "abadi";
            //p1.prenom = "ihab";
            //Adresse a = new Adresse();
            //a.adresse = "tilleul";
            //a.ville = "Tourcoing";
            //p1.adresse = a;
            //Console.WriteLine(p1.nom + " " + p1.prenom);
            //p1.SetNom("abadi");
            //p1.Nom = "abadi";
            //p1.Afficher();
            //Personne p2 = new Personne();
            //p2.nom = "tata";
            //p2.prenom = "toto";
            //Console.WriteLine(p2.nom + " " + p2.prenom);
            /* p2.Afficher();
             Personne p3 = new Personne("t", "minet", 50);
             p3.Afficher();*/

            #region Correction tp 1 héritage
            /*IHM ihm = new IHM();
            ihm.Start();*/
            #endregion

            #region tpNOte

            /*  IHMNote ihmNOte = new IHMNote();
              ihmNOte.Start();
  */

            #endregion

            #region Tp voiture
            /* Voiture v = new Voiture("Renault", "Laguna", 30);
             Console.WriteLine(v);
             v.Rouler(25);
             Console.WriteLine(v);
             v.Rouler(10);*/

            #endregion

            #region generique
            /*Pile<int> pileEntier = new Pile<int>(3);
            pileEntier.Empiler(1);
            pileEntier.Empiler(15);
            Console.WriteLine(pileEntier.Get(1));
            pileEntier.Depiler();
            Console.WriteLine(pileEntier.Get(1));
            Pile<Voiture> pileVoitures = new Pile<Voiture>(3);
            pileVoitures.Empiler(new Voiture("kia", "ceed", 30));
            pileVoitures.Empiler(new Voiture("Ford", "kuga", 30));
            Console.WriteLine(pileVoitures.Get(0));
            Console.WriteLine(pileVoitures.Get(1));
            pileVoitures.Depiler();
            Console.WriteLine((pileVoitures.Get(1) != null) ? pileVoitures.Get(1).ToString() : "null");*/

            //List
            /* List<int> listeEntiers = new List<int>();
             listeEntiers.Add(10);
             listeEntiers.Add(20);*/


            #endregion

            #region manip fichiers

            /*Console.WriteLine("Entrez le nom du fichier");
            string nomFichier = Console.ReadLine();
            string path = @"C:\Users\Torkhan\Desktop\";
            string fichier = path + nomFichier + ".txt";
            string choix;
            string contenuFichier = "";
          
            do
            {
                Console.WriteLine("====menu======");
                Console.WriteLine("1- Entrez une nouvelle ligne de texte");
                Console.WriteLine("0-Fin");
                choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":

                        Console.WriteLine("Saisissez votre text ici");
                        string texte = Console.ReadLine();
                        if (File.Exists(fichier))
                        {
                            StreamReader reader = new StreamReader(nomFichier);
                            contenuFichier += reader;
                            reader.Close();
                            StreamWriter ecrire = new StreamWriter(fichier);
                            ecrire.WriteLine(contenuFichier + texte);
                            
                            ecrire.Close();
                        }
                        else
                        {
                        }

                        break;
                }

            } while (choix != "0");*/


           
            #endregion
        }
    }
}
