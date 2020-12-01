using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    class Triangle : Figure
    {
        double hauteur;
        double baseTriangle;

        public double Hauteur { get => hauteur; set => hauteur = value; }
        public double BaseTriangle { get => baseTriangle; set => baseTriangle = value; }

        public Triangle(double posX, double posY, double hauteur, double baseTriangle) : base(posX, posY)
        {
            Hauteur = hauteur;
            BaseTriangle = baseTriangle;
        }

        public override void Afficher()
        {
            Console.WriteLine($"Triangle de hauteur {Hauteur} et de base {BaseTriangle}");   
        }
    }
}
