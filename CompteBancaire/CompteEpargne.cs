using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire
{
    class CompteEpargne : CompteBancaire
    {
        private decimal TauxInteret = 2;

        public CompteEpargne(decimal solde, int code,decimal tauxInteret) :base(solde, code)
        {
            TauxInteret = tauxInteret;
        }
        public void CalculInteret(decimal solde)
        {
            decimal interets = (solde * TauxInteret) / 100;
             solde += interets;
        }
    }
}
