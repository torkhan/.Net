using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace coursWPF.Classes
{
    public class Personne : INotifyPropertyChanged
    {
        private string nom;
        private string prenom;

        public string Nom
        {
            get => nom;
            set
            {
                nom = value;
                RaisePropertyChanged("Nom");
            }
        }
        public string Prenom
        {
            get => prenom;
            set
            {
                prenom = value;
                RaisePropertyChanged("Prenom");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string ToString()
        {
            return Nom + " " + Prenom;
        }
    }
}
