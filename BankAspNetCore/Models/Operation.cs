using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Text;

namespace BankAspNetCore.Models
{
    public class Operation
    {
       
        private int id;
        private DateTime dateOperation;
        private decimal montant;
        private int compteId;
        

        public int Id { get => id; set => id = value; }
        public DateTime DateOperation { get => dateOperation;}
        public decimal Montant { get => montant;}

        public Compte Compte { get; set; }
        
        [ForeignKey("Compte")]
        public int CompteId { get => compteId; set => compteId = value; }

        public Operation()
        {

        }

        public Operation(decimal montant)
        {
            //id = compteur++;
            dateOperation = DateTime.Now;
            this.montant = montant;

        }

        public Operation(decimal montant, int compteId) : this(montant)
        {
            this.CompteId = compteId;
        }

        public Operation(int numero, DateTime date, decimal montant, int compteId) : this(montant, compteId)
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
