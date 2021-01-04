using Caisse.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CaisseWPF.UserControls
{
    /// <summary>
    /// Logique d'interaction pour VenteControl.xaml
    /// </summary>
    public partial class VenteControl : UserControl
    {
        Panier panier;
        ObservableCollection<Produit> produitsPanier;
        public VenteControl()
        {
            InitializeComponent();
            panier = new Panier();
            produitsPanier = new ObservableCollection<Produit>(panier.Produits);
            listViewProduits.ItemsSource = produitsPanier;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (Int32.TryParse(codeBox.Text, out id))
            {
                Produit p = DataBase.Instance.GetProduitById(id);
                if (p != null)
                {
                    panier.AddProduit(p);
                    produitsPanier.Add(p);
                    DataBase.Instance.DescStock(p.Id);
                    totalBlock.Content = panier.Total + " euros";
                    codeBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Aucun produit avec cet id");
                }
            }
            else
            {
                MessageBox.Show("Erreur de code");
            }
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if(DataBase.Instance.SavePanier(panier))
            {
                MessageBox.Show("Panier validé");
                panier = new Panier();
                produitsPanier = new ObservableCollection<Produit>(panier.Produits);
                listViewProduits.ItemsSource = produitsPanier;
                totalBlock.Content = "0 euros";
            }
            else
            {
                MessageBox.Show("Erreur serveur");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            DataBase.Instance.UpdateDataBase();
            MessageBox.Show("Mise à jour effectuée");
        }


    }
}
