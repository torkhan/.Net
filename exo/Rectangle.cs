using System;
using System.Collections.Generic;
using System.Text;

namespace exo
{
   class Rectangle : Figure,IDeformable
    {
        double hauteur;
        double largeur;

        public Rectangle(double posX, double posY,double hauteur, double largeur): base(posX, posY)
        {
            Hauteur = hauteur;
            Largeur = largeur;
        }

        public double Hauteur { get => hauteur; set => hauteur = value; }
        public double Largeur { get => largeur; set => largeur = value; }

        public override void Affiche()
        {
            
        }

        public Figure Deformation(double coeffh, double coefffv)
        {
            if (coeffh * Largeur == coeffh * Largeur)
            {
                return new Carre(PosX, PosY, coeffh * Largeur);
            }
            else
            {
                return new Carre(PosX, PosY, coeffh * Hauteur);
            }
        }
    }
}
