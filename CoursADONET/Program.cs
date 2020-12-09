using System;
using System.Data;
using System.Data.SqlClient;

namespace CoursADONET
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(LocalDb)\coursM2I;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            #region cours ADO.NET ModeConnecte
            //Connexion à la base de donnée



            /*//Executer les requetes => on utilise un objet de Command
            //Préparation de la commande
            //string request = "INSERT INTO personne (nom, prenom, telephone) values ('ado', 'net', 'core')";
            //string request = "INSERT INTO personne (nom, prenom, telephone) OUTPUT INSERTED.id values ('ado', 'net', 'core')";
            string request = "SELECT * from personne";
            SqlCommand command = new SqlCommand(request, connection);
            //ouverture de la connexion
            connection.Open();
            //1ere maniere d'executer la commande => executer une requete sans retour
            //int nbRow = command.ExecuteNonQuery();
            //2eme maniere d'executer la commande => executer une requete avec la récupération d'une seule valeur
            //int id = (int)command.ExecuteScalar();
            //3eme maniere d'executer la commande => executer une requete pour récupérer un ensemble de resultat
            SqlDataReader reader = command.ExecuteReader();
            //Lire la totalité des données
            while(reader.Read())
            {
                Console.WriteLine($"Personne Id : {reader.GetInt32(0)}, Nom : {reader.GetString(1)}, Prénom : {reader.GetString(2)}");
            }
            //Fermeture du reader
            reader.Close();
            //Liberer la connexion pour avoir la possibilité de l'utilier avec une autre commande
            command.Dispose();
            //Fermeture de la connexion
            connection.Close();*/

            //Executer les requetes avec des variables => on utilise une requete préparée avec des paramètres
            /* Console.Write("Merci de saisir le nom : ");
             string nom = Console.ReadLine();
             Console.Write("Merci de saisir le prénom : ");
             string prenom = Console.ReadLine();
             Console.Write("Merci de saisir le téléphone ");
             string telephone = Console.ReadLine();

             string request = "INSERT INTO personne (nom, prenom, telephone) values (@nom, @prenom, @telephone)";
             SqlCommand command = new SqlCommand(request, connection);
             //Ajouter les paramètres de la commande
             command.Parameters.Add(new SqlParameter("@nom", nom));
             command.Parameters.Add(new SqlParameter("@prenom", prenom));
             command.Parameters.Add(new SqlParameter("@telephone", telephone));

             //Executer la commande
             connection.Open();
             command.ExecuteNonQuery();
             command.Dispose();
             connection.Close();*/
            #endregion

            #region cours ADO.NET Mode déconnecté
            DataSet data = new DataSet();
            string request = "SELECT id, nom, prenom, telephone, dateInscription from personne";
            
            //Récuperation des données et le stockage dans un dataSet
            SqlDataAdapter adapter = new SqlDataAdapter(request, connection);            
            

            //Indiquer les commandes à utiliser pour l'insertion, la modification, la suppression
            
            //insertion
            string insertRequest = "INSERT INTO personne (nom, prenom, telephone, dateInscription) values" +
                "(@nom, @prenom, @telephone, @dateInscription)";
            SqlCommand insertCommand = new SqlCommand(insertRequest, connection);
            insertCommand.Parameters.Add("@nom", SqlDbType.VarChar, 100, "nom");
            insertCommand.Parameters.Add("@prenom", SqlDbType.VarChar, 100, "prenom");
            insertCommand.Parameters.Add("@telephone", SqlDbType.VarChar, 10, "telephone");
            insertCommand.Parameters.Add("@dateInscription", SqlDbType.DateTime, 0, "dateInscription");
            adapter.InsertCommand = insertCommand;

            //update 
            string updateRequest = "UPDATE personne set " +
                "nom=@nom, prenom=@prenom, telephone=@telephone, dateInscription=@dateInscription where id=@id";
            
            SqlCommand updateCommand = new SqlCommand(updateRequest, connection);
            updateCommand.Parameters.Add("@nom", SqlDbType.VarChar, 100, "nom");
            updateCommand.Parameters.Add("@prenom", SqlDbType.VarChar, 100, "prenom");
            updateCommand.Parameters.Add("@telephone", SqlDbType.VarChar, 10, "telephone");
            updateCommand.Parameters.Add("@dateInscription", SqlDbType.DateTime, 0, "dateInscription");
            updateCommand.Parameters.Add("@id", SqlDbType.Int, 11, "id");
            adapter.UpdateCommand = updateCommand;

            //Delete
            string deleteRequest = "DELETE FROM personne where id=@id";
            SqlCommand deleteCommand = new SqlCommand(deleteRequest, connection);
            deleteCommand.Parameters.Add("@id", SqlDbType.Int, 11, "id");
            adapter.DeleteCommand = deleteCommand;

            connection.Open();
            adapter.Fill(data, "personne");
            connection.Close();

            string choix;
            do
            {
                Console.WriteLine("1-- Lire les données");
                Console.WriteLine("2-- Ajouter des données");
                Console.WriteLine("3-- Modifier des données");
                Console.WriteLine("4-- Supprimer des données");
                choix = Console.ReadLine();
                DataTable personnes = data.Tables["personne"];
                int id = 0;
                switch (choix)
                {
                    case "1":
                        //Lecture des données à partir du DataSet
                        foreach (DataRow row in personnes.Rows)
                        {
                            if(row.RowState != DataRowState.Deleted)
                                Console.WriteLine($"{row["nom"]}, {row["prenom"]}, {row["telephone"]}, {row["dateInscription"]}");
                        }
                        break;
                    case "2":
                        //Ecrire des données dans le dataSet
                        DataRow newRow = personnes.NewRow();
                        newRow["nom"] = Console.ReadLine();
                        newRow["prenom"] = Console.ReadLine();
                        newRow["telephone"] = Console.ReadLine();
                        newRow["dateInscription"] = DateTime.Now;
                        personnes.Rows.Add(newRow);
                        break;
                    case "3":
                        id = Convert.ToInt32(Console.ReadLine());
                        foreach(DataRow row in personnes.Rows)
                        {
                            if((int)row["id"] == id && row.RowState != DataRowState.Deleted)
                            {
                                row["nom"] = Console.ReadLine();
                                row["prenom"] = Console.ReadLine();
                                row["telephone"] = Console.ReadLine();
                                row["dateInscription"] = DateTime.Now;
                                break;
                            }
                        }
                        break;
                    case "4":
                        id = Convert.ToInt32(Console.ReadLine());
                        
                        foreach (DataRow row in personnes.Rows)
                        {
                            if ((int)row["id"] == id)
                            {
                                row.Delete();
                                break;
                            }
                        }
                        break;
                    case "0":
                        adapter.Update(personnes);
                        break;
                }
            } while (choix != "X");

            

           
            #endregion
        }
    }
}
