using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire
{
    class Operation
    {
        public CompteBancaire compteBancaire;
        private int numero;
        private decimal montantOperation;

        public Operation(CompteBancaire compteBancaire, int numero, decimal montantOperation)
        {
            this.compteBancaire = compteBancaire;
            this.numero = numero;
            this.montantOperation = montantOperation;
        }

        internal CompteBancaire CompteBancaire { get => compteBancaire; set => compteBancaire = value; }
        public int Numero { get => numero; set => numero = value; }
        public decimal MontantOperation { get => montantOperation; set => montantOperation = value; }
    }
}
