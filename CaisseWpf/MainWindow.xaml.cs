using Caisse.Classes;
using CaisseWPF.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CaisseWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VenteControl venteControl;
        private ProduitsControl produitsControl;
        //private DataBase data;
        public MainWindow()
        {
            InitializeComponent();
            
            venteControl = new VenteControl();
            produitsControl = new ProduitsControl();
            ResultPanel.Children.Add(venteControl);
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            if(sender is MenuItem m)
            {
                ResultPanel.Children.Clear();
                switch(m.Header)
                {
                    case "Vente":
                        ResultPanel.Children.Add(venteControl);
                        break;
                    case "Gestion de produits":
                        produitsControl = new ProduitsControl();
                        ResultPanel.Children.Add(produitsControl);
                        break;
                }
            }
        }
    }
}
