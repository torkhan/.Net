using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Annuaire
{
    public class Contact
    {
        int id;
        string nom;
        string prenom;
        string telephone;

        private static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\coursM2I;Integrated Security=True");
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
        public Contact(int id, string nom, string prenom, string telephone) : this(nom,prenom,telephone)
        {
            Id = id;            
        }
        public bool Save()
        {
            string request = "INSERT INTO contact (nom, prenom, telephone) OUTPUT INSERTED.id values (@nom, @prenom, @telephone)";
            //pour mysql
            //string request = "INSERT INTO contact (nom, prenom, telephone) values (@nom, @prenom, @telephone); SELECT LAST_INSERT_ID()";
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
            string request = "DELETE FROM contact where id=@id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
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
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public static Contact GetContactById(int id)
        {
            Contact contact = null;
            string request = "SELECT id, nom, prenom, telephone from contact where id=@id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if(reader.Read())
            {
                contact = new Contact(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return contact;
        }

        public static List<Contact> GetContacts(string search = null)
        {
            List<Contact> contacts = new List<Contact>();
            string request = "SELECT id, nom, prenom, telephone from contact ";
            if(search != null)
            {
                request += "where telephone like @search OR nom like @search OR prenom like @search";
            }
            command = new SqlCommand(request, connection);
            if (search != null)
            {
                command.Parameters.Add(new SqlParameter("@search", search + "%"));
            }
            connection.Open();
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                Contact contact = new Contact(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                contacts.Add(contact);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return contacts;
        }

        public override string ToString()
        {
            return $"Nom : {Nom}, Prénom : {Prenom}, Téléphone : {Telephone}";
        }
    }
}
