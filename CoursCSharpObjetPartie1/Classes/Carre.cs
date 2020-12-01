using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    class Carre : Figure, IDeformable
    {
        double cote;

        public double Cote { get => cote; set => cote = value; }

        public Carre(double posX, double posY, double cote) : base(posX, posY)
        {
            Cote = cote;
        }

        public override void Afficher()
        {
            Console.WriteLine($"Carré de côté {Cote}");
        }

        public Figure Deformation(double coeffH, double coeffV)
        {
            if(coeffH == coeffV)
            {
                return new Carre(PosX, PosY, cote * coeffV);
            }
            else
            {
                return new Rectangle(PosX, PosY, cote * coeffH, cote * coeffV);
            }
        }
    }
}
