using System;
using System.Data.SqlClient;

namespace Annuaire
{
    class Program
    {
        static void Main(string[] args)
        {
            IHM ihm = new IHM();
            ihm.Start();

            //connexion
            string connectionString = @"Data Source=(LocalDb)\Annuaire;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            //préparation query
             string request = "CREATE TABLE contact(id int PRIMARY KEY IDENTITY(1,1),nom varchar(100), prenom varchar(100), telephone varchar(20))";
             SqlCommand command = new SqlCommand(request, connection);

            //executer
             connection.Open();
             int nbRow = command.ExecuteNonQuery();
             command.Dispose();
             connection.Close();

            //insertion via variables demandées
            /*Console.Write("Merci de saisir le nom : ");
            string nom = Console.ReadLine();
            Console.Write("Merci de saisir le prénom : ");
            string prenom = Console.ReadLine();
            Console.Write("Merci de saisir le téléphone ");
            string telephone = Console.ReadLine();*/

            //préparation query
            /*string req = "INSERT INTO contact (nom, prenom, telephone) values (@nom, @prenom, @telephone)";
            SqlCommand command = new SqlCommand(req, connection);*/

            //les paramètres
            /* command.Parameters.Add(new SqlParameter("@nom", nom));
             command.Parameters.Add(new SqlParameter("@prenom", prenom));
             command.Parameters.Add(new SqlParameter("@telephone", telephone));

             //executer
             connection.Open();
             command.ExecuteNonQuery();
             command.Dispose();
             connection.Close();*/

            //requète pour recevoir nom par id
           /* string reqId = "SELECT nom FROM contact where id = 1";
            SqlCommand command = new SqlCommand(reqId, connection);
            string nom = (string)command.ExecuteScalar();
            connection.Open();
            command.ExecuteScalar();
            command.Dispose();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Console.WriteLine($"Nom :{reader.GetString(nom)}");*/



        }
    }
}
