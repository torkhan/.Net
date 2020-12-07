using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Annuaire
{
    class Contact
    {
        int id;
        string nom;
        string prenom;
        string telephone;

        private static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\Annuaire;Integrated Security=True");
        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }

        public Contact()
        {

        }
        public Contact(string nom, string prenom, string telephone)
        {
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
        }
        public Contact(int id, string nom, string prenom, string telephone) : this(nom, prenom, telephone)
        {
            Id = id;
        }
        public bool Save()
        {
            string request = "INSERT INTO contact (nom, prenom, telephone) OUTPUT INSERTED.id values (@nom, @prenom, @telephone)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@prenom", Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));

            connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();

            return Id > 0;
        }

        public bool Delete()
        {
            string request = "DELETE from contact where id = @id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", Id));

            connection.Open();
            int nbrow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();

            return nbrow ==1;
        }

        public bool Update()
        {
            string request = "UPDATE contact set nom=@nom, prenom=@prenom, telephone=@telephone where id=@id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@prenom", Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));
            command.Parameters.Add(new SqlParameter("@id", Id));
            connection.Open();
            int nbrow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbrow ==1;
        }

        public static Contact GetContactById(int id)
        {
            Contact contact = null;
            string request = "SELECT id, nom, prenom, telephone from contact where id=@id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                contact = new Contact(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return contact;
        }
        public override string ToString()
        {
            return $"Nom : {Nom}, Prénom : {Prenom}, Téléphone : {Telephone}";
        }
    }
}
