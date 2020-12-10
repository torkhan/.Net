using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Annuaire
{
    public class Email
    {
        private int id;
        private string mail;
        private static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\coursM2I;Integrated Security=True");
        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Mail { get => mail; set => mail = value; }

        public bool Save(int contactId)
        {
            string request = "INSERT INTO email (mail, contact_id) " +
                "OUTPUT INSERTED.ID values (@mail, @contact_id)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@mail", Mail));
            command.Parameters.Add(new SqlParameter("@contact_id", contactId));
            connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return Id > 0;
        }

        public static List<Email> GetEmailsByContact(int contactId)
        {
            List<Email> emails = new List<Email>();
            string request = "SELECT id, mail from email where contact_id=@contact_id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@contact_id", contactId));
            connection.Open();
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                Email e = new Email()
                {
                    Id = reader.GetInt32(0),
                    Mail = reader.GetString(1)
                };
                emails.Add(e);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return emails;
        }

        public override string ToString()
        {
            return Mail;
        }
    }
}
