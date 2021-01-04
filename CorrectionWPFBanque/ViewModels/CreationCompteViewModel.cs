using CorrectionCompteBancaire.Classes;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CorrectionWPFBanque.ViewModels
{
    public class CreationCompteViewModel : ViewModelBase
    {
        private Compte compte;
        private Client client;

        public string Nom { get => client.Nom; set { client.Nom = value; RaisePropertyChanged(); } }
        public string Prenom { get => client.Prenom; set { client.Prenom = value; RaisePropertyChanged(); } }
        public string Telephone { get => client.Telephone; set { client.Telephone = value; RaisePropertyChanged(); } }

        public int Id { get => client.Id; }

        public decimal Solde { get; set; }

        public ICommand CreateCommand { get; set; }

        public string Result { get; set; }

        public CreationCompteViewModel()
        {
            client = new Client();
            CreateCommand = new RelayCommand(ActionCreateCommand);
        }

        private void ActionCreateCommand()
        {
            compte = new Compte(client, Solde);
            if(compte.Save())
            {
                Result = $"Compte crée avec le numéro {compte.Numero}";
                RaisePropertyChanged("Id");
                Clear();
            }
            else
            {
                Result = "Erreur création compte";
            }
            RaisePropertyChanged("Result");
        }

        private void Clear()
        {
            client = new Client();
            RaisePropertyChanged("Nom");
            RaisePropertyChanged("Prenom");
            RaisePropertyChanged("Telephone");
            Solde = 0;
            RaisePropertyChanged("Solde");
        }
    }
}
