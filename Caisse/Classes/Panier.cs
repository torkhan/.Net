using System;
using System.Collections.Generic;
using System.Text;

namespace Caisse.Classes
{
    public class Panier
    {
        private int id;
        
        private decimal total;

        private List<Produit> produits;

        public int Id { get => id; set => id = value; }
        public decimal Total { get => total; }
        public List<Produit> Produits { get => produits; set => produits = value; }

        public Panier()
        {
            Produits = new List<Produit>();
        }

        public void AddProduit(Produit produit)
        {
            Produits.Add(produit);
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal t = 0;
            Produits.ForEach(p => { t += p.Prix; });
            total = t;
        }

        public override string ToString()
        {
            string retour = "";
            Produits.ForEach(p =>
            {
                retour += p.ToString() + "\n";
            });

            retour +="---------Total : " + Total + " euros";
            return retour;
        }
    }
}
