using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionCompteBancaire.Classes
{
    class CompteEpargne : Compte
    {
        decimal taux;
        public decimal Taux { get => taux; set => taux = value; }

        decimal soldeInitial;

        int nbreAnnee;

        public event Action<decimal, int> DoubleEpargne;
        public CompteEpargne(Client client, decimal taux, decimal solde = 0) : base(client, solde)
        {
            Taux = taux;
            soldeInitial = solde;
            nbreAnnee = 0;
        }

        public void CalculeInteret()
        {
            Depot(Solde * Taux / 100);
            nbreAnnee++;
            if(Solde >= 2*soldeInitial)
            {
                DoubleEpargne?.Invoke(Solde, nbreAnnee);
            }
        }

    }
}
