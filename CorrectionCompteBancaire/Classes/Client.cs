using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CorrectionCompteBancaire.Classes
{
    class Client
    {
        private int id;
        private string nom;
        private string prenom;
        private string telephone;

        private static SqlCommand command;
        private static SqlDataReader reader;

        public string Nom
        {
            get => nom; set
            {
                if (Tools.CheckName(value))
                    nom = value;
                else
                    throw new Exception("Erreur nom");
            }
        }
        public string Prenom
        {
            get => prenom; set
            {
                if (Tools.CheckName(value))
                    prenom = value;
                else
                    throw new Exception("Erreur prénom");
            }
        }
        public string Telephone
        {
            get => telephone; set
            {
                if (Tools.CheckPhone(value))
                    telephone = value;
                else
                    throw new Exception("Erreur téléphone");
            }
        }

        public int Id { get => id; set => id = value; }

        public Client()
        {

        }
        public Client(string nom, string prenom, string telephone)
        {
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
        }

        public Client(int id, string nom, string prenom, string telephone) : this(nom, prenom, telephone)
        {
            this.id = id;
        }

        public bool Save()
        {
            string request = "INSERT INTO Client (nom, prenom, telephone) OUTPUT INSERTED.Id values (@nom, @prenom, @telephone)";
            command = new SqlCommand(request, Tools.Connection);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@prenom", Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));
            Tools.Connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            Tools.Connection.Close();
            return Id > 0;
        }

        public static Client GetClientById(int id)
        {
            Client client = null;
            string request = "SELECT nom, prenom, telephone FROM Client where id = @id";
            command = new SqlCommand(request, Tools.Connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            Tools.Connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                client = new Client(id, reader.GetString(0), reader.GetString(1), reader.GetString(2));
            }
            reader.Close();
            command.Dispose();
            Tools.Connection.Close();
            return client;
        }

        public override string ToString()
        {
            return $"Nom : {Nom}, Prénom : {Prenom}, Téléphone : {Telephone}";
        }


    }
}
