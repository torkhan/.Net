using CorrectionWPFBanque.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace CorrectionWPFBanque.ViewModels
{
    public class MainWindowsViewModel : ViewModelBase
    {
        public ICommand InfoCompteCommand { get; set; }
        public ICommand CreationCompteCommand { get; set; }

        public MainWindowsViewModel()
        {
            InfoCompteCommand = new RelayCommand<StackPanel>(ActionInfoCompte);
            CreationCompteCommand = new RelayCommand<StackPanel>(ActionCreationCompte);
        }
        private void ActionInfoCompte(StackPanel result)
        {
            result.Children.Clear();
            result.Children.Add(new InfoCompteControl());
        }

        private void ActionCreationCompte(StackPanel result)
        {
            result.Children.Clear();
            result.Children.Add(new CreationCompteControl());
        }
    }
}
