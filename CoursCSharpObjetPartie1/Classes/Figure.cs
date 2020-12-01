using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    abstract class Figure
    {
        double posX;
        double posY;

        public double PosX { get => posX; set => posX = value; }
        public double PosY { get => posY; set => posY = value; }

        protected Figure(double posX, double posY)
        {
            PosX = posX;
            PosY = posY;
        }

        public abstract void Afficher();
    }
}
