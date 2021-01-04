using coursWPF.Controls;
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
    /// Logique d'interaction pour SpecialControl.xaml
    /// </summary>
    public partial class SpecialControl : Window
    {
        private FormulaireControl formulaireControl;
        private ListePersonnesControl listePersonnesControl;
        public SpecialControl()
        {
            InitializeComponent();
            formulaireControl = new FormulaireControl();
            listePersonnesControl = new ListePersonnesControl();
        }

        private void Formulaire_Click(object sender, RoutedEventArgs e)
        {
            stack.Children.Clear();
            stack.Children.Add(formulaireControl);
        }

        private void ListePersonne_Click(object sender, RoutedEventArgs e)
        {
            stack.Children.Clear();     
            stack.Children.Add(listePersonnesControl);
        }
    }
}
