using CorrectionCompteBancaire.Classes;
using CorrectionWPFBanque.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CorrectionWPFBanque.Views
{
    /// <summary>
    /// Logique d'interaction pour Operation.xaml
    /// </summary>
    public partial class OperationWindow : Window
    {
        public OperationWindow()
        {
            InitializeComponent();
        }

        public OperationWindow(string type, Compte compte) : this()
        {
            DataContext = new OperationViewModel(type, compte, this);
        }
    }
}
