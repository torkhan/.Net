using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1
{
    public class Calculatrice
    {
        public delegate void delegateCalcule(int a, int b);
        public delegate void delgateMultiCalcule(int a, int b, Func<int, int, int> methodeCalcule);
        public int Addition(int a, int b)
        {
            return a + b;
        }
        public int Soustraction(int a, int b)
        {
            return a - b;
        }


        public void ConsoleAddition(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        public void ConsoleSoustraction(int a, int b)
        {
            Console.WriteLine(a - b);
        }
        public void ConsoleMultiplication(int a, int b)
        {
            Console.WriteLine(a * b);
        }

        //public void Calcule(int a, int b, delegateCalcule methodeCalcule)
        //{
        //    Console.WriteLine(methodeCalcule(a, b));
        //}
        public void Calcule(int a, int b, Func<int,int,int> methodeCalcule)
        {
            Console.WriteLine(methodeCalcule(a, b));
        }

        public void CalculeAvecMessage(int a, int b, Func<int, int, int> methodeCalcule)
        {
            Console.WriteLine("Le calcule est : " + methodeCalcule(a, b));
        }

        public void StartAll()
        {
            delgateMultiCalcule multiCalcule;
            multiCalcule = Calcule;
            multiCalcule += CalculeAvecMessage;
            multiCalcule(10, 20, Addition);
        }

        public void SecondStart(int a, int b)
        {
            //delegateCalcule methodeCalcule;
            Action<int, int> methodeCalcule;
            methodeCalcule = ConsoleAddition;
            methodeCalcule += ConsoleSoustraction;
            methodeCalcule += ConsoleMultiplication;
            methodeCalcule += ConsoleMultiplication;
            methodeCalcule(a, b);
        }
        
    }
}
