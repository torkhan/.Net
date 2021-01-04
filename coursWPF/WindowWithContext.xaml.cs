using coursWPF.Classes;
using coursWPF.ViewModels;
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

namespace coursWPF
{
    /// <summary>
    /// Logique d'interaction pour WindowWithContext.xaml
    /// </summary>
    public partial class WindowWithContext : Window
    {
        //public Personne Personne { get; set; }
        //public Adresse Adresse { get; set; }

        private WindowWithContextViewModel vm;
        public WindowWithContext()
        {
            InitializeComponent();
            vm = new WindowWithContextViewModel();
            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(vm.Nom + " "+ vm.Prenom + " "+ vm.Rue + " "+ vm.Ville);
        }
    }
}
