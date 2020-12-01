using System;
using System.Collections.Generic;
using System.Text;

namespace exo
{
    class Triangle : Figure
    {
        decimal triangleBase;
        decimal hauteur;

        public Triangle(double posX, double posY, decimal triangleBase, decimal hauteur):base(posX, posY)
        {
            this.triangleBase = triangleBase;
            this.hauteur = hauteur;
        }

        public decimal TriangleBase { get => triangleBase; set => triangleBase = value; }
        public decimal Hauteur { get => hauteur; set => hauteur = value; }

        public override void Affiche()
        {
            Console.WriteLine($"Triangle de hauteur {hauteur} et de base {TriangleBase}");
        }
    }
}
