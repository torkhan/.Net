using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire
{
    class CompteBancaire
    {
        private decimal solde;
        private int code ;
        private int nbreDeComptes = 0;
        private List<CompteEpargne> compteEpargnes;


        private Client clients;
        private List<Operation> operations;

        public CompteBancaire()
        {

        }
        public CompteBancaire(decimal solde, int code)
        {
            Solde = solde;
            Code = code;
            Operations = new List<Operation>();
        }

        public decimal Solde { get => solde; set => solde = value; }
        public int Code { get => code; set => code = value; }
        public int NbreDeComptes { get => nbreDeComptes; set => nbreDeComptes = value; }
        internal List<CompteEpargne> CompteEpargnes { get => compteEpargnes; set => compteEpargnes = value; }
        
        internal List<Operation> Operations { get => operations; set => operations = value; }
       public Client Clients { get => clients; set => clients = value; }

        public virtual void CréationCompte()
        {
            nbreDeComptes++;
            code = nbreDeComptes;
            solde = 0;
        }

        public virtual void Depot(decimal montantOperation)
        {
            solde +=  montantOperation;
        }
        public virtual void Retrait (decimal montantOperation)
        {
            solde -= montantOperation;
        }
        public override string ToString()
        {
            return "Le solde de votre compte numéro: " + code + " est de: " + solde + " Euros";
        }
    }
}
