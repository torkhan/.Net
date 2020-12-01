using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using CoursCSharpObjetPartie1.Classes;
namespace CoursCSharpObjetPartie1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Correction exercice 1 poo
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
            ////p2.nom = "tata";
            ////p2.prenom = "toto";
            ////Console.WriteLine(p2.nom + " " + p2.prenom);
            ////Start Gc
            //GC.Collect();
            //p2.Afficher();



            //Personne p3 = new Personne("titi", "minet", 50);
            //p3.Afficher();
            //Personne p4 = Personne.CreatePersonne("tata", "toto", 20);
            //Console.WriteLine(Personne.compteur);




            /*Salarie s1 = new Salarie();
            s1.Nom = "s1";
            s1.Categorie = "c1";
            s1.Matricule = "m1";
            s1.Service = "sv1";
            s1.Salaire = 2000;
              #endregion


            #region TP
            /*Console.WriteLine("Le nombre de salariés : " + Salarie.Compteur);
            Salarie.ResetCompteur();
            Salarie s3 = new Salarie("m3", "c3", "sv3", "s3", 4000);
            Salarie[] tabSalarie = new Salarie[] { s1, s2, s3 };

            for(int i=0; i < tabSalarie.Length; i++)
            {
                tabSalarie[i].CalculerSalaire();
            }
            Console.WriteLine("Le nombre de salariés : " + Salarie.Compteur);
            GC.Collect();*/
            #endregion

            #region coursPOO héritage
            /*Etudiant e = new Etudiant();
            e.Nom = "nom e1";
            e.Prenom = "prenom e1";
            e.Age = 20;
            e.Niveau = 3;
            e.Afficher();
            //e.AfficherEtudiant();
            Personne e2 = new Etudiant("nom e2", "prenom e2", 21, 4);
            e2.Afficher();
            Personne s1 = new Salarie();
            Personne[] personnes = new Personne[] { e2, s1 };

            foreach(Personne p in personnes)
            {
                Console.WriteLine(p.GetType());
            }
            //Console.WriteLine(e2.GetType());
            //e2.AfficherEtudiant();*/
            #endregion

            #region Correction tp 1 héritage
            //IHM ihm = new IHM();
            //ihm.Start();
            #endregion

            #region suite coursPOO héritage
            ////object c = new object();
            //Personne p = new Etudiant("abadi", "ihab", 33, 4);
            //Console.WriteLine(p.ToString());
            //Solution exercice hértiage voiture
            /*Voiture v = new Voiture("Renault", "Laguna", 30);
            Console.WriteLine(v);
            v.Rouler(25);
            Console.WriteLine(v);
            v.Rouler(10);*/
            #endregion

            #region cours Générique
            //Maison<Personne> maisonPersonne = new Maison<Personne>(5);
            //Maison<Voiture> maisonVoiture = new Maison<Voiture>(10);
            //Pile<int> pileEntier = new Pile<int>(3);
            //pileEntier.Empiler(1);
            //pileEntier.Empiler(25);
            //Console.WriteLine(pileEntier.Get(1));
            //pileEntier.Depiler();
            //Console.WriteLine(pileEntier.Get(1));

            //Pile<Voiture> pileVoitures = new Pile<Voiture>(3);
            //pileVoitures.Empiler(new Voiture("kia", "ceed", 30));
            //pileVoitures.Empiler(new Voiture("Ford", "kuga", 30));
            //Console.WriteLine(pileVoitures.Get(0));
            //Console.WriteLine(pileVoitures.Get(1));
            //pileVoitures.Depiler();
            //Console.WriteLine((pileVoitures.Get(1) != null) ? pileVoitures.Get(1).ToString() : "null");

            //List
            /*List<int> listeEntiers = new List<int>();
            listeEntiers.Add(10);
            listeEntiers.Add(20);
            listeEntiers.Add(30);
            Console.WriteLine(listeEntiers.Count);
            Console.WriteLine("==================");
            foreach(int e in listeEntiers)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("==================");
            listeEntiers.Remove(10);
            Console.WriteLine(listeEntiers.Count);
            Console.WriteLine("==================");
            foreach (int e in listeEntiers)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("==================");
            List<Voiture> listeVoitures = new List<Voiture>();
            listeVoitures.Add(new Voiture("kia", "ceed", 30));
            listeVoitures.Add(new Voiture("ford", "Kuga", 30));            
            foreach(Voiture v in listeVoitures)
            {
                Console.WriteLine(v);
            }*/
            #endregion

            #region cours interface
            //List<IVolant> volants = new List<IVolant>();
            //volants.Add(new Oiseau());
            //volants.Add(new Avion());
            //foreach(IVolant v in volants)
            //{
            //    v.Voler();
            //}
            //IVolant avion = new Avion();
            //IVolant drone = new Drone();
            //TransportColis t = new TransportColis(avion);
            //t.Transporter();
            /*List<IAnimal> animaux = new List<IAnimal>();
            animaux.Add(new Chien());
            animaux.Add(new Chat());
            animaux.Add(new Lapin());
            foreach(IAnimal a in animaux)
            {
                a.Crier();
            }*/
            #endregion

            #region gestion des exceptions
            //Avion a = null;
            //a.Voler();
            //Console.Write("Merci de saisir un entier : ");
            //int a = Convert.ToInt32(Console.ReadLine());


            //try
            //{
            //    Console.Write("Merci de saisir un entier : ");
            //    int nombre = Convert.ToInt32(Console.ReadLine());
            //    //Avion a = null;
            //    //a.Voler();
            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine("Vous n'avez pas saisi un entier " + ex.Message + " " + ex.GetType().ToString());
            //}
            //catch(NullReferenceException ex)
            //{
            //    Console.WriteLine("L'objet n'a pas été correctement instancié");
            //}
            //finally
            //{
            //    Console.WriteLine("finally instruction");
            //}

            //bool error = false;
            //int nombre = 0;
            //do
            //{
            //    try
            //    {
            //        Console.Write("Merci de saisir un entier : ");
            //        nombre = Convert.ToInt32(Console.ReadLine());
            //        error = false;
            //    }catch(Exception e)
            //    {
            //        error = true;
            //        Console.WriteLine("Erreur de format");
            //    }
            //} while (error);
            //Console.WriteLine("Le nombre est de " + nombre);
            //Etudiant e = new Etudiant();
            //e.Age = -10;
            //Cours regex
            //Commencer par un caractère  => ^
            //finir par un caractère  => $
            //pour indiquer plusieurs possibilité => []
            //pour indiquer le nombre de caractère => {}
            // pour indiquer un min et un max de nombre => {min,max}
            //pour un nombre 0 et plus => *
            //pour un nombre 1 et plus => +
            //pour 0 ou 1 => ?
            //string pattern = @"^[a-zA-Z0-9_\.-]+@([a-z_-]+(\.)?[a-z_-])+\.[a-z]{2,7}$";
            //// [a-zA-Z0-9_] => \w
            ////[0-9] => \d
            //string patternTelephone = @"^0[1-9]{1}([\s\.-]?\d{2}){4}$"; 
            //string chaine = "06 06-06.06.060";
            //Console.WriteLine(Regex.IsMatch(chaine, patternTelephone));
            #endregion

            #region passage de paramètres dans une méthode et délegate
            //passage par valeur;
            //int a = 10;
            //Afficher(a);
            //Console.WriteLine(a);
            //string nom = "toto";
            //Afficher(nom);
            //Console.WriteLine(nom);
            //passage par référence
            //pour les paramètres objet, le passage est toujours par référence
            //Etudiant e = new Etudiant("toto", "tata", 30, 1);
            //Afficher(e);
            //Console.WriteLine(e.Nom);
            // pour les paramètres de type primitifs.
            // pour passer une variable primitive par référence =>
            // 1 => en utilisant le mot clé ref
            //int a = 10;
            //Afficher(ref a);
            // 2 => en utilisant le mot clé out
            //int a;
            //Afficher(out a);
            //Console.WriteLine(a);
            //Console.Write("Merci de saisir la valeur de a :");
            //try
            //{
            //    int a = Convert.ToInt32(Console.ReadLine());
            //}catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //int a;
            //if(!Int32.TryParse(Console.ReadLine(), out a))
            //{
            //    Console.WriteLine("Exception de parse");
            //}
            //else
            //{
            //    Console.WriteLine(a);
            //}
            //decimal solde = 100;
            //CalculeReduction(ref solde, 10);
            //Console.WriteLine(solde);
            //CalculeReduction(ref solde, 20);
            //Console.WriteLine(solde);
            //int age;
            //bool error = false;
            //do
            //{
            //    Console.WriteLine("Merci de saisir votre age : ");
            //    error = !Int32.TryParse(Console.ReadLine(), out age);
            //} while (error);
            //Calculatrice c = new Calculatrice();
            ////c.Calcule(10, 20, c.Addition);
            //c.Calcule(10, 20, (a, b) => a + b);
            //c.Calcule(10, 20, c.Soustraction);
            //c.Calcule(10, 30, Multiplication);
            ////c.Calcule(10, 30, Division);
            //c.Calcule(10, 30, delegate(int a, int b) { return a / b; });
            //c.Calcule(10, 30, (a,b) => a / b );
            ////c.StartAll();
            //c.SecondStart(10, 20);
            #endregion



            #region cours event
            //Voiture v = new Voiture("ford", "kuga", 30, 35000);
            //v.Promotion += NotificationReductionEmail;
            //v.Promotion += NotificationReductionSMS;
            //int countPromotion = 0;
            //string choix;
            //do
            //{
            //    Console.Write("Redution ? (o/n)");
            //    choix = Console.ReadLine();
            //    if(choix == "o")
            //    {
            //        Console.Write("Montant de la réduction : ");
            //        decimal reduction;
            //        Decimal.TryParse(Console.ReadLine(), out reduction);
            //        v.Reduction(reduction);
            //        countPromotion++;
            //        if(countPromotion == 3)
            //        {
            //            v.Promotion -= NotificationReductionSMS;
            //        } 
            //    }
            //} while (choix != "0");

            //Pile<int> pile = new Pile<int>(3);
            //pile.PilePleine += NotificationPilePleine;
            //pile.PilePleine += () => { Console.WriteLine("Notification sms pile pleine"); };
            //string choix;
            //do
            //{
            //    Console.WriteLine("1--Empiler un élément");
            //    Console.WriteLine("2--Depiler");
            //    choix = Console.ReadLine();
            //    if(choix == "1")
            //    {
            //        Console.Write("Element à empiler : ");
            //        int element;
            //        Int32.TryParse(Console.ReadLine(), out element);
            //        pile.Empiler(element);
            //    }
            //    else if(choix == "2")
            //    {
            //        pile.Depiler();
            //    }
            //} while (choix != "0");
            #endregion

            #region Gestion de fichiers
            //Ecrire dans un fichier txt par exemple
            //StreamWriter writer = new StreamWriter(@"C:\Users\ihab\Desktop\FormationM2INET\test.html");
            //writer.WriteLine("<h1>Bonjour tout le monde</h1>");
            //writer.Close();
            //Lecture d'un fichier txt par exemple
            //verifier qu'un fichier existe
            //string path = @"C:\Users\ihab\Desktop\FormationM2INET\test.csv";
            //string folderPath = @"C:\Users\ihab\Desktop\FormationM2INET";
            //if (File.Exists(path))
            //{
            //    StreamReader reader = new StreamReader(path);
            //    Console.WriteLine(reader.ReadToEnd());
            //    reader.Close();
            //}else
            //{
            //    Console.WriteLine("Aucun fichier trouvé");
            //}

            //pour gérer les fichiers (Fichier exists, supprimer un fichier, ouvrir un fichier) => on utilise les méthodes statiques de la classe File
            //pour agir sur les dossiers (Directory)
            //Directory.CreateDirectory(folderPath + @"\fichiers");
            //foreach(string f in Directory.GetFiles(folderPath, "*.txt"))
            //{
            //    Console.WriteLine(f);
            //}
            //On commence par demander le nom du fichier (.txt)
            //On demande le contenu du fichier ligne par ligne 
            //Si l'utilisateur saisi 0, on sauvegarde le fichier(si le fichier existe, on ajoute le contenu, sinon on le crée)
            //Correction Exercice
            /*Console.Write("Merci de saisir le nom du fichier : ");
            string nomFichier = Console.ReadLine();
            string contenuFichier = "";
            //Lecture si fichier existe
            if(File.Exists(nomFichier))
            {
                StreamReader reader = new StreamReader(nomFichier);
                contenuFichier += reader.ReadToEnd();
                reader.Close();
            }
            //Ecriture du fichier
            StreamWriter writer = new StreamWriter(nomFichier);
            if(contenuFichier != "")
            {
                writer.WriteLine(contenuFichier);
            }
            string ligne;
            do
            {
                ligne = Console.ReadLine();
                if(ligne != "0")
                {
                    writer.WriteLine(ligne);
                }
            } while (ligne != "0");
            writer.Close();*/
            //2ème possibilité
            //string ligne;
            //do
            //{
            //    ligne = Console.ReadLine();
            //    if (ligne != "0")
            //    {
            //        contenuFichier += "\n" + ligne;
            //    }
            //} while (ligne != "0");

            //StreamWriter writer = new StreamWriter(nomFichier);
            //writer.WriteLine(contenuFichier);
            //writer.Close();

            //Ecriture des objets dans un csv
            //List<Etudiant> etudiants = new List<Etudiant>();
            //etudiants.Add(new Etudiant("toto", "tata", 10, 1));
            //etudiants.Add(new Etudiant("titi", "minet", 20, 1));
            //StreamWriter writer = new StreamWriter("etudiants.csv");
            //writer.WriteLine("nom;prenom;age;niveau");
            //foreach(Etudiant e in etudiants)
            //{
            //    writer.WriteLine($"{e.Nom};{e.Prenom};{e.Age};{e.Niveau}");
            //}
            //writer.Close();
            //Lecture à partir d'un csv
            /*List<Etudiant> etudiants = new List<Etudiant>();
            StreamReader reader = new StreamReader("etudiants.csv");
            string ligne = reader.ReadLine();
            //do
            //{
            //    ligne = reader.ReadLine();
            //} while (ligne != null);
            while(ligne != null)
            {
                ligne =reader.ReadLine();
                if (ligne != null)
                {
                    string[] content = ligne.Split(';');
                    Console.WriteLine(ligne);
                    etudiants.Add(new Etudiant(content[0], content[1], Convert.ToInt32(content[2]), Convert.ToInt32(content[3])));
                }
            }

            reader.Close();*/
            #endregion

            #region test unitaire
            #endregion
        }

        static void NotificationReductionEmail(decimal p, string m)
        {
            Console.WriteLine($"Envoie email avec reduction sur la voiture {m} le nouveau prix est de: {p} euros");
        }
        static void NotificationReductionSMS(decimal p, string m)
        {
            Console.WriteLine($"Envoie sms avec reduction sur la voiture {m} le nouveau prix est de: {p} euros");

        }

        static void NotificationPilePleine()
        {
            Console.WriteLine("La pile est pleine");
        }

        //static void Afficher(ref int nombre)
        //{
        //    nombre += 10;
        //    Console.WriteLine(nombre);
        //}
        static void Afficher(out int nombre)
        {
            nombre = 10;
            Console.WriteLine(nombre);
        }

        static void Afficher(string chaine)
        {
            chaine += " coucou";
            Console.WriteLine(chaine);
        }

        static void Afficher(Etudiant e)
        {
            e.Nom += " E1";
            Console.WriteLine(e.Nom);
        }

        static void CalculeReduction(ref decimal solde, decimal reduction)
        {
            solde -= reduction;
        }

        static int Multiplication(int a, int b)
        {
            return a * b;
        }
        static int Division(int a, int b)
        {
            return a / b;
        }
    }
}
