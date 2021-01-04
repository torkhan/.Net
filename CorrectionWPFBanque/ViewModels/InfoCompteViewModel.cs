using CorrectionCompteBancaire.Classes;
using CorrectionWPFBanque.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CorrectionWPFBanque.ViewModels
{
    public class InfoCompteViewModel : ViewModelBase
    {
        private Compte compte;

        public int Numero { get; set; }
        public string Nom { get => (compte != null) ? compte.Client.Nom : null; }

        public string Prenom { get => (compte != null) ? compte.Client.Prenom : null; }

        public string Telephone { get => (compte != null) ? compte.Client.Telephone : null; }

        public decimal Solde { get => (compte != null) ? compte.Solde : 0; }

        private bool val1;

        private bool val2;

        private Visibility visb1 = Visibility.Collapsed;

        private Visibility visb2 = Visibility.Collapsed;

        public bool Val1
        {
            get => val1;
            set
            {
                val1 = value;
                Visb1 = (val1) ? Visibility.Visible : Visibility.Collapsed;
                RaisePropertyChanged("Visb1");
            }
        }
        public bool Val2
        {
            get => val2;
            set
            {
                val2 = value;
                Visb2 = (val2) ? Visibility.Visible : Visibility.Collapsed;
                RaisePropertyChanged("Visb2");
            }
        }
        public Visibility Visb1 { get => visb1; set => visb1 = value; }
        public Visibility Visb2 { get => visb2; set => visb2 = value; }
        public ObservableCollection<Operation> Operations { get => (compte != null) ? new ObservableCollection<Operation>(compte.Operations) : null; }

        public ICommand SearchCommand { get; set; }
        public ICommand OperationCommand { get; set; }


        public InfoCompteViewModel()
        {
            SearchCommand = new RelayCommand(ActionSearchCommand);
            OperationCommand = new RelayCommand<string>(ActionOperationCommand);
        }

        private void ActionSearchCommand()
        {
            compte = Compte.GetCompteById(Numero);
            if (compte == null)
            {
                MessageBox.Show("Aucun compte avec ce numéro");
            }
            else
            {
                RaisePropertyChanged("Nom");
                RaisePropertyChanged("Prenom");
                RaisePropertyChanged("Telephone");
                RaisePropertyChanged("Solde");
                RaisePropertyChanged("Operations");
            }
        }

        private void ActionOperationCommand(string type)
        {
            if (compte != null)
            {
                OperationWindow window = new OperationWindow(type, compte);
                window.Show();
            }

        }
    }
}
