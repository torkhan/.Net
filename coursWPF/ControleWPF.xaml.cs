using coursWPF.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace coursWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ControleWPF : Window
    {
        private ObservableCollection<Personne> personnes;

        private bool isEdit = false;
        private Personne personneToEdit;
        public ControleWPF()
        {
            InitializeComponent();
            personnes = new ObservableCollection<Personne>();
            listePersonnes.ItemsSource = personnes;
        }

        private void ValidClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(pChefEntreprise.IsChecked.ToString());
            if(!isEdit)
            {
                Personne p = new Personne()
                {
                    Nom = textNom.Text,
                    Prenom = textPrenom.Text
                };

                personnes.Add(p);
            }
            else
            {
                personneToEdit.Nom = textNom.Text;
                personneToEdit.Prenom = textPrenom.Text;
                isEdit = false;
            }
            
            textNom.Text = "";
            textPrenom.Text = "";
        }

        private void DetailClick(object sender, RoutedEventArgs e) 
        {
            if(listePersonnes.SelectedItem is Personne p)
            {
                textNom.Text = p.Nom;
                textPrenom.Text = p.Prenom;
                personneToEdit = p;
                isEdit = true;
                PersonneWindow window = new PersonneWindow(p);
                window.Show();
            }
        }

        private void SupprimerClick(object sender, RoutedEventArgs e)
        {
            if (listePersonnes.SelectedItem is Personne p)
            {
                personnes.Remove(p);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((sender as MenuItem).Header.ToString());
        }
    }
}
