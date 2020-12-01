using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    class Rectangle : Figure, IDeformable
    {
        double largeur;
        double hauteur;

        public double Largeur { get => largeur; set => largeur = value; }
        public double Hauteur { get => hauteur; set => hauteur = value; }

        public Rectangle(double posX, double posY, double largeur, double hauteur) : base(posX, posY)
        {
            Largeur = largeur;
            Hauteur = hauteur;
        }

        public override void Afficher()
        {
            Console.WriteLine($"Rectangle de largeur {Largeur} et de hauteur {Hauteur}");
        }

        public Figure Deformation(double coeffH, double coeffV)
        {
           if(coeffH * Largeur == coeffV * Hauteur)
            {
                return new Carre(PosX, PosY, coeffH * Largeur);
            }
           else
            {
                if(coeffH >= coeffV)
                {
                    return new Rectangle(PosX, PosY, coeffH * Largeur, coeffV * Hauteur);
                }
                else
                {
                    return new Rectangle(PosX, PosY, coeffV * Largeur, coeffH * Hauteur);

                }
            }
        }
    }
}
