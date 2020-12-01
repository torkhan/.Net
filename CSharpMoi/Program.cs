using System;

namespace CSharpMoi
{
    class Program
    {
        static void Main(string[] args)
        {
            #region tableaux

            /* int[] tabEntier = new int[5];
             //afficher les valeurs d un tab
             for (int i = 0; i < tabEntier.Length; i++)
             {
                 Console.WriteLine("xx");
             }*/
            //exo

/*
            int[] apprenants = new int[12];
            double somme = 0;
            int noteHaute = 0;
            int noteBasse = 21;
            int choix;

            for (int i = 0; i < apprenants.Length; i++)
            {
                Console.WriteLine("Entrez les notes de l'élève n° " + (i + 1));
                apprenants[i] = Convert.ToInt32(Console.ReadLine());
            }
            do
            {
                Console.Write("Souhaitez vous:  1/afficher les notes  2/_afficher la somme 3/ afficher la plus haute note" +
                     "  4/ afficher la plus petite note  5/afficher la moyenne  6/ quitter   " + "\r\n");
                choix = Convert.ToInt32(Console.ReadLine());


                switch (choix)
                {
                    case 1:
                        for (int i = 0; i < apprenants.Length; i++)
                        {
                            Console.WriteLine("les notes sont: " + apprenants[i] );
                        }Console.WriteLine("\r\n");
                        break;
                    case 2:
                        for (int i = 0; i < apprenants.Length; i++)
                        {
                            somme += apprenants[i];
                        }
                        Console.WriteLine("La somme des notes est: " + somme + "\r\n");
                        break;
                    case 3:
                        for (int i = 0; i < apprenants.Length; i++)
                        {
                            if (noteHaute < apprenants[i])
                                noteHaute = apprenants[i];
                        }
                        Console.WriteLine("La note la plus haute est: " + noteHaute + "\r\n");
                        break;
                    case 4:
                        for (int i = 0; i < apprenants.Length; i++)
                        {
                            if (noteBasse > apprenants[i])
                                noteBasse = apprenants[i];
                        }
                        Console.WriteLine("La note la plus basse est: " + noteBasse + "\r\n");
                        break;
                    case 5:
                        Console.WriteLine("La moyenne des notes est: " + (somme / 12) + "\r\n");
                        break;
                }

            } while (choix < 6);*/


            #endregion
        }
    }
}
