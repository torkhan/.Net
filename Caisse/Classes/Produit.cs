using System;
using System.Collections.Generic;
using System.Text;

namespace Caisse.Classes
{
    public class Produit
    {
        private int id;

        private string titre;

        private decimal prix;

        private int stock;

        public int Id { get => id; set => id = value; }
        public string Titre { get => titre; set => titre = value; }
        public decimal Prix { get => prix; set => prix = value; }
        public int Stock { get => stock; set => stock = value; }

        public Produit()
        {

        }
        public Produit(int id, string titre, decimal prix, int stock) : this(titre, prix, stock)
        {
            Id = id;     
        }

        public Produit(string titre, decimal prix, int stock)
        {   
            Titre = titre;
            Prix = prix;
            Stock = stock;
        }

        public override string ToString()
        {
            return "Titre : "+ Titre + " Prix : "+ prix;
        }
    }
}
