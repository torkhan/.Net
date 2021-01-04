using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Caisse.Classes
{
    public class DataBase
    {
        private DataSet data;
        private SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\coursM2I;Integrated Security=True");
        private SqlCommand command;
        private SqlDataAdapter produitAdapter;

        private static DataBase _instance = null;

        public static DataBase Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataBase();
                }
                return _instance;
            }
        }

        private DataBase()
        {
            data = new DataSet();
            string request = "SELECT id, titre, prix, stock from produit";
            produitAdapter = new SqlDataAdapter(request, connection);
            string updateRequest = "UPDATE produit set stock = @stock where id=@id";
            SqlCommand updateCommand = new SqlCommand(updateRequest, connection);
            updateCommand.Parameters.Add("@stock", SqlDbType.Int, 11, "stock");
            updateCommand.Parameters.Add("@id", SqlDbType.Int, 11, "id");
            produitAdapter.UpdateCommand = updateCommand;
            connection.Open();
            produitAdapter.Fill(data, "produits");
            connection.Close();
        }

        public Produit GetProduitById(int id)
        {
            Produit produit = null;
            DataTable produits = data.Tables["produits"];
            foreach (DataRow row in produits.Rows)
            {
                if ((int)row["id"] == id)
                {
                    produit = new Produit((int)row["id"], (string)row["titre"], (decimal)row["prix"], (int)row["stock"]);
                    break;
                }
            }
            return produit;
        }

        public List<Produit> GetProduits(string search = null)
        {
            List<Produit> tmpProduits = new List<Produit>();
            DataTable produits = data.Tables["produits"];
            foreach (DataRow row in produits.Rows)
            {
                if(search == null || (search != null && ((string)row["titre"]).Contains(search)))
                {
                    Produit produit = new Produit((int)row["id"], (string)row["titre"], (decimal)row["prix"], (int)row["stock"]);
                    tmpProduits.Add(produit);
                }
                
            }
            return tmpProduits;
        }

        public bool DescStock(int id)
        {
            bool found = false;
            DataTable produits = data.Tables["produits"];
            foreach (DataRow row in produits.Rows)
            {
                if ((int)row["id"] == id)
                {
                    found = true;
                    row["stock"] = (int)row["stock"] - 1;
                    break;
                }
            }
            return found;
        }

        public void UpdateDataBase()
        {
            connection.Open();
            produitAdapter.Update(data, "produits");
            connection.Close();
        }

        public bool SaveProduit(Produit produit)
        {
            string request = "INSERT INTO produit (titre, prix, stock) OUTPUT INSERTED.ID values (@titre, @prix, @stock)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@titre", produit.Titre));
            command.Parameters.Add(new SqlParameter("@prix", produit.Prix));
            command.Parameters.Add(new SqlParameter("@stock", produit.Stock));
            connection.Open();
            produit.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            if (produit.Id > 0)
            {
                SaveProduitDataSet(produit);
            }
            return produit.Id > 0;

        }

        private void SaveProduitDataSet(Produit produit)
        {
            DataTable produits = data.Tables["produits"];
            DataRow row = produits.NewRow();
            row["id"] = produit.Id;
            row["titre"] = produit.Titre;
            row["stock"] = produit.Stock;
            row["prix"] = produit.Prix;
        }
        public bool SavePanier(Panier panier)
        {
            string request = "INSERT INTO panier (total) OUTPUT INSERTED.ID values (@total)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@total", panier.Total));
            connection.Open();
            panier.Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            if (panier.Id > 0)
            {
                panier.Produits.ForEach(p => SavePanierProduit(panier.Id, p.Id));
                return true;
            }
            return false;
        }

        private bool SavePanierProduit(int panierId, int produitId)
        {
            string request = "INSERT INTO panier_produit (panier_id, produit_id) values (@panier_id, @produit_id)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@panier_id", panierId));
            command.Parameters.Add(new SqlParameter("@produit_id", produitId));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }
    }
}
