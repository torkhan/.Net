using CorrectionCompteBancaire.Classes;
using CorrectionWPFBanque.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CorrectionWPFBanque.ViewModels
{
    public class OperationViewModel : ViewModelBase
    {
        private Compte compte;
        private OperationWindow _w; 
        public string Type { get; set; }

        public int Numero { get => compte.Numero; }

        public decimal Montant { get; set; }

        public ICommand ConfirmCommand { get; set; }

        public OperationViewModel(string t, Compte c, OperationWindow w)
        {
            Type = t;
            RaisePropertyChanged("Type");
            compte = c;
            _w = w;
            ConfirmCommand = new RelayCommand(ActionConfirmCommand);
        }

        private void ActionConfirmCommand()
        {
            if(Type == "Depot")
            {
                if (compte.Depot(Montant))
                {
                    MessageBox.Show("Dépôt effectué");
                    _w.Close();
                }
                else
                {
                    MessageBox.Show("Erreur dépôt");
                }
            }
            else if(Type == "Retrait")
            {
                if(compte.Retrait(Montant))
                {
                    MessageBox.Show("Retrait effectué");
                    _w.Close();
                }
                else
                {
                    MessageBox.Show("Erreur retrait");
                }
            }
        }
    }
}
