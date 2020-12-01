using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionCompteBancaire.Classes
{
    class ComptePayant : Compte
    {
        decimal coutOperation;
        
        public decimal CoutOperation { get => coutOperation; set => coutOperation = value; }
        public ComptePayant(Client client, decimal coutOperation, decimal solde = 0) : base(client, solde)
        {
            CoutOperation = coutOperation;
        }

        public override bool Depot(decimal montant)
        {
            if(montant >= CoutOperation)
            {
                base.Depot(montant);
                return base.Retrait(CoutOperation);
            }
            else
            {
                if(base.Retrait(coutOperation))
                {
                    return base.Depot(montant);
                }
                else
                {
                    return false;
                }
            }
        }

        public override bool Retrait(decimal montant)
        {
            if(base.Retrait(CoutOperation))
            {
                if(base.Retrait(montant))
                {
                    return true;
                }else
                {
                    base.Depot(CoutOperation);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
