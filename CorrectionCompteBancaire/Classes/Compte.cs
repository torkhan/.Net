using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionCompteBancaire.Classes
{
    class Compte
    {
        private static int compteur = 1;

        private int numero;
        private decimal solde;
        private Client client;
        private List<Operation> operations;

        public event Action<decimal, int> ADecouvert;
        public int Numero { get => numero; }
        public decimal Solde { get => solde; }
        public Client Client { get => client; set => client = value; }
        public List<Operation> Operations { get => operations; set => operations = value; }

        public Compte(Client client, decimal solde = 0)
        {
            Client = client;
            numero = compteur++;
            Operations = new List<Operation>();
            this.solde = solde;
        }
        public Compte(int numero,Client client, decimal solde = 0) : this(client, solde)
        {
            this.numero = numero;
        }
        public virtual bool Depot(decimal montant)
        {
            Operation o = new Operation(montant);
            Operations.Add(o);
            solde += montant;
            return true;
        }

        public virtual bool Retrait(decimal montant)
        {
            //if(Solde >= montant)
            //{
            //    Operation o = new Operation(montant * -1);
            //    Operations.Add(o);
            //    solde -= montant;
            //    return true;
            //}
            //return false;
            Operation o = new Operation(montant * -1);
            Operations.Add(o);
            solde -= montant;
            if(solde < 0)
            {
                if(ADecouvert != null)
                {
                    ADecouvert(solde, Numero);
                }
            }
            return true;

        }

        public override string ToString()
        {
            string retour = $"Numero {Numero}\n";
            retour += Client.ToString() + "\n";
            foreach(Operation o in Operations)
            {
                retour += o.ToString() + "\n";
            }
            retour += $"Solde : {Solde} euros";
            return retour;
        }
    }
}
