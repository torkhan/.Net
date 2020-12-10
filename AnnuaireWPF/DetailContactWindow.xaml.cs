using Annuaire;
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

namespace AnnuaireWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DetailContactWindow : Window
    {
        private Contact contact; 
        public DetailContactWindow()
        {
            InitializeComponent();
        }

        public DetailContactWindow(Contact c) : this()
        {
            contact = c;
            blockNom.Text = contact.Nom;
            blockPrenom.Text = contact.Prenom;
            blockTelephone.Text = contact.Telephone;
            listeBoxMails.ItemsSource = Email.GetEmailsByContact(contact.Id);
        }
    }
}
