using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionCompteBancaire.Classes
{
    class Operation
    {
        private static int compteur = 1;
        private int id;
        private DateTime dateOperation;
        private decimal montant;

        public int Id { get => id; }
        public DateTime DateOperation { get => dateOperation;}
        public decimal Montant { get => montant;}

        public Operation(decimal montant)
        {
            id = compteur++;
            dateOperation = DateTime.Now;
            this.montant = montant;

        }

        public Operation(int numero, DateTime date, decimal montant) : this(montant)
        {
            id = numero;
            dateOperation = date;
        }

        public override string ToString()
        {
            return $"Numéro : {Id}, Date Opération : {DateOperation}, Montant : {Montant}";
        }
    }
}
