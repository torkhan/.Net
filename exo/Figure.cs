using System;
using System.Collections.Generic;
using System.Text;

namespace exo
{
    abstract class Figure
        
    {
        double posX;
        double posY;
        double centre;

        public Figure()
        {
        }

        protected Figure(double posX, double posY)
        {
            PosX = posX;
            PosY = posY;
          
        }

        public double PosX { get => posX; set => posX = value; }
        public double PosY { get => posY; set => posY = value; }
        

        public abstract void Affiche();
        

    }
}
