using System;
using System.Collections.Generic;
using System.Text;

namespace exo
{
    class Carre : Figure, IDeformable
    {
        double longeurCote;

        public Carre(double posX, double posY, double longeurCote): base(posX, posY)
        {
            this.longeurCote = longeurCote;
        }

        public double LongeurCote { get => longeurCote; set => longeurCote = value; }

        public override void Affiche()
        {
            Console.WriteLine($"Carré de côté {LongeurCote}");
        }

        public Figure Deformation(double coeffh, double coefffv)
        {
           
        }
    }
}
