using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BankAspNetCore.Models
{
    public class Compte
    {


        private int numero;
        private decimal solde;
        private Client client;
        private List<Operation> operations;


        public event Action<decimal, int> ADecouvert;

        [Key]
        public int Numero { get => numero; set => numero = value; }
        public decimal Solde { get => solde; set => solde = value; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }


        public Client Client { get => client; set => client = value; }
        public List<Operation> Operations { get => operations; set => operations = value; }

        public Compte()
        {

        }
        protected Compte(int numero, decimal solde)
        {
            this.numero = numero;
            this.solde = solde;
        }
        public Compte(Client client, decimal solde = 0)
        {
            Client = client;
            Operations = new List<Operation>();
            this.solde = solde;
        }
        public Compte(int numero, Client client, decimal solde = 0) : this(client, solde)
        {
            this.numero = numero;
        }

        public bool Save()
        {
            DataDbContext.Instance.Comptes.Add(this);
            return DataDbContext.Instance.SaveChanges() > 0;
        }

        public static Compte GetCompteById(int id)
        {
            return DataDbContext.Instance.Comptes.Include(c => c.Client)
                .Include(c => c.Operations).FirstOrDefault(c => c.Numero == id);
        }

        public bool Update()
        {
            return DataDbContext.Instance.SaveChanges() > 0;
        }
        public virtual bool Depot(decimal montant)
        {
            Operation o = new Operation(montant, Numero) { Compte = this };
            Operations.Add(o);
            if (Update())
            {
                solde += montant;
                return true;
            }
            return false;
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
            Operation o = new Operation(montant * -1, Numero);
            Operations.Add(o);
            
            if(Update())
            {
                solde -= montant;
                if (solde < 0)
                {
                    if (ADecouvert != null)
                    {
                        ADecouvert(solde, Numero);
                    }
                }
                return true;
            }
            return false;
            
        }

        public override string ToString()
        {
            string retour = $"Numero {Numero}\n";
            retour += Client.ToString() + "\n";
            foreach (Operation o in Operations)
            {
                retour += o.ToString() + "\n";
            }
            retour += $"Solde : {Solde} euros";
            return retour;
        }
    }
}
