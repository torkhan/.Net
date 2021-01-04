using Caisse.Classes;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CaisseWPF.ViewModels
{
    public class ProduitsControlViewModel : ViewModelBase
    {
        private Produit produit;
        private ObservableCollection<Produit> produits;

        public string Titre { get => Produit.Titre; set { Produit.Titre = value; RaisePropertyChanged(); } }
        public decimal Prix { get => Produit.Prix; set { Produit.Prix = value; RaisePropertyChanged(); } }
        public int Stock { get => Produit.Stock; set { Produit.Stock = value; RaisePropertyChanged(); } }
        public Produit Produit { get => produit; set { produit = value; RaisePropertyChanged(); } }
        public ObservableCollection<Produit> Produits { get => produits; set { produits = value; RaisePropertyChanged(); } }

        public string Search {get;set;}

        public ICommand ConfirmCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand MouseOverCommand { get; set; }

        public ProduitsControlViewModel()
        {
            Produit = new Produit();
            Produits = new ObservableCollection<Produit>(DataBase.Instance.GetProduits());
            ConfirmCommand = new RelayCommand(ActionConfirmCommand);
            SearchCommand = new RelayCommand(SearchAction);
            MouseOverCommand = new RelayCommand<Button>(MouseOverAction);
        }


        private void MouseOverAction(Button button)
        {
            button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#cd2127"));
        }
        public void SearchAction()
        {
            Produits = new ObservableCollection<Produit>(DataBase.Instance.GetProduits(Search));            
        }

        private void ActionConfirmCommand()
        {
            if (DataBase.Instance.SaveProduit(Produit))
            {
                MessageBox.Show("produit ajouté");
                Produits.Add(Produit);
                //ClearForm();
                Produit = new Produit();
                RaisePropertyChanged("Titre");
                RaisePropertyChanged("Prix");
                RaisePropertyChanged("Stock");
            }
            else
            {
                MessageBox.Show("erreur serveur");
            }
        }
    }
}
