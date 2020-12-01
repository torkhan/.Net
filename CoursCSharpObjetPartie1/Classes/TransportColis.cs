using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    class TransportColis
    {
        private IVolant volant;

        public TransportColis(IVolant v)
        {
            volant = v;
        }

        public void Transporter()
        {
            volant.Voler();
        }
    }
}
