using Annuaire;
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

namespace AnnuaireWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();
            contacts = new ObservableCollection<Contact>(Contact.GetContacts());
            listeViewContacts.ItemsSource = contacts;
        }


        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact(boxNom.Text, boxPrenom.Text, boxTelephone.Text);
            if(contact.Save())
            {
                result.Text = "Contact ajouté";
                contacts.Add(contact);
            }
            else
            {
                result.Text = "Erreur ajout de contact";
            }
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            contacts = new ObservableCollection<Contact>(Contact.GetContacts(searchBox.Text));
            listeViewContacts.ItemsSource = contacts;
        }
    }
}
