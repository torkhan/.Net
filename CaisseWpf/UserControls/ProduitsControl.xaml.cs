using Caisse.Classes;
using CaisseWPF.ViewModels;
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
    /// Logique d'interaction pour ProduitsControl.xaml
    /// </summary>
    public partial class ProduitsControl : UserControl
    {
        //private DataBase _data;
        //private ObservableCollection<Produit> produits;
        private ProduitsControlViewModel vm;
        public ProduitsControl()
        {
            InitializeComponent();
            vm = new ProduitsControlViewModel();
            DataContext = vm;
            //produits = new ObservableCollection<Produit>(DataBase.Instance.GetProduits());
            //listViewProduits.ItemsSource = produits;
        }

        //public ProduitsControl(DataBase data)
        //{
        //    _data = data;
        //}

        //private void Confirm_Click(object sender, RoutedEventArgs e)
        //{
        //    //Produit p = new Produit();
        //    //p.Titre = titreBox.Text;
        //    //p.Prix = Convert.ToDecimal(prixBox.Text);
        //    //p.Stock = Convert.ToInt32(stockBox.Text);
        //    if (DataBase.Instance.SaveProduit(vm.Produit))
        //    {
        //        MessageBox.Show("produit ajouté");
        //        vm.Produits.Add(vm.Produit);
        //        //ClearForm();
        //        vm.Produit = new Produit();
        //    }
        //    else
        //    {
        //        MessageBox.Show("erreur serveur");
        //    }
        //}

        //private void Search_Click(object sender, RoutedEventArgs e)
        //{
        //    //produits = new ObservableCollection<Produit>(DataBase.Instance.GetProduits(searchBox.Text));
        //    //listViewProduits.ItemsSource = produits;
        //    vm.SearchAction();
        //}

        //private void ClearForm()
        //{
        //    //titreBox.Text = "";
        //    //prixBox.Text = "";
        //    //stockBox.Text = "";
        //}
    }
}
