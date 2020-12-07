using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        private static SqlCommand command;
        private static SqlDataReader reader;

        public event Action<decimal, int> ADecouvert;
        public int Numero { get => numero; }
        public decimal Solde { get => solde; }
        public Client Client { get => client; set => client = value; }
        public List<Operation> Operations { get => operations; set => operations = value; }

        protected Compte(int numero, decimal solde)
        {
            this.numero = numero;
            this.solde = solde;
        }
        public Compte(Client client, decimal solde = 0)
        {
            Client = client;
            //numero = compteur++;
            Operations = new List<Operation>();
            this.solde = solde;
        }
        public Compte(int numero, Client client, decimal solde = 0) : this(client, solde)
        {
            this.numero = numero;
        }

        public bool Save()
        {
            if (Client.Save())
            {
                string request = "INSERT INTO Compte (solde, client_id) OUTPUT INSERTED.ID values (@solde,@client_id)";
                command = new SqlCommand(request, Tools.Connection);
                command.Parameters.Add(new SqlParameter("@solde", Solde));
                command.Parameters.Add(new SqlParameter("@client_id", Client.Id));
                Tools.Connection.Open();
                numero = (int)command.ExecuteScalar();
                command.Dispose();
                Tools.Connection.Close();
                return numero > 0;
            }
            return false;
        }

        public static Compte GetCompteById(int id)
        {
            Compte compte = null;
            int clientId = 0;
            string request = "SELECT solde, client_id from compte where id =@id";
            command = new SqlCommand(request, Tools.Connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            Tools.Connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                compte = new Compte(id, reader.GetDecimal(0));
                clientId = reader.GetInt32(1);
            }
            reader.Close();
            command.Dispose();
            Tools.Connection.Close();
            if (compte != null)
            {
                compte.Client = Client.GetClientById(clientId);
                compte.Operations = Operation.GetOperations(id);
            }
            return compte;
        }

        public bool Update()
        {
            string request = "UPDATE Compte set solde=@solde where id=@id";
            command = new SqlCommand(request, Tools.Connection);
            command.Parameters.Add(new SqlParameter("@solde", Solde));
            command.Parameters.Add(new SqlParameter("@id", Numero));
            Tools.Connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            Tools.Connection.Close();
            return nbRow == 1;
        }
        public virtual bool Depot(decimal montant)
        {
            Operation o = new Operation(montant, Numero);
            if (o.Save())
            {
                Operations.Add(o);
                solde += montant;
                return Update();
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
            if (o.Save())
            {
                Operations.Add(o);
                solde -= montant;
                if (solde < 0)
                {
                    if (ADecouvert != null)
                    {
                        ADecouvert(solde, Numero);
                    }
                }
                return Update();
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
