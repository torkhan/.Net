using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CorrectionCompteBancaire.Classes
{
    class Operation
    {
        private static int compteur = 1;
        private int id;
        private DateTime dateOperation;
        private decimal montant;
        private int compteId;
        private static SqlCommand command;

        private static SqlDataReader reader;

        public int Id { get => id; }
        public DateTime DateOperation { get => dateOperation; }
        public decimal Montant { get => montant; }

        public Operation(decimal montant)
        {
            //id = compteur++;
            dateOperation = DateTime.Now;
            this.montant = montant;

        }

        public Operation(decimal montant, int compteId) : this(montant)
        {
            this.compteId = compteId;
        }

        public Operation(int numero, DateTime date, decimal montant, int compteId) : this(montant, compteId)
        {
            id = numero;
            dateOperation = date;
        }

        public bool Save()
        {
            string request = "INSERT INTO Operation (compte_id,date_operation, montant) OUTPUT INSERTED.ID " +
                "values(@compte_id,@date_operation,@montant)";
            command = new SqlCommand(request, Tools.Connection);
            command.Parameters.Add(new SqlParameter("@compte_id", compteId));
            command.Parameters.Add(new SqlParameter("@date_operation", dateOperation));
            command.Parameters.Add(new SqlParameter("@montant", montant));
            Tools.Connection.Open();
            id = (int)command.ExecuteScalar();
            command.Dispose();
            Tools.Connection.Close();
            return id > 0;
        }

        public static List<Operation> GetOperations(int compteId)
        {
            List<Operation> operations = new List<Operation>();
            string request = "SELECT id, date_operation, montant from Operation " +
                "where compte_id = @compteId";

            command = new SqlCommand(request, Tools.Connection);
            command.Parameters.Add(new SqlParameter("@compteId", compteId));
            Tools.Connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Operation o = new Operation(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDecimal(2), compteId);
                operations.Add(o);
            }
            reader.Close();
            command.Dispose();
            Tools.Connection.Close();
            return operations;
        }
        public override string ToString()
        {
            return $"Numéro : {Id}, Date Opération : {DateOperation}, Montant : {Montant}";
        }
    }
}
