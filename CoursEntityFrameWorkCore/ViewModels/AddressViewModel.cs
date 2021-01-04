using CoursEntityFrameWorkCore.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CoursEntityFrameWorkCore.ViewModels
{
    public class AddressViewModel : ViewModelBase
    {
        private DataContext data;
        public string Street
        {
            get; set;
        }
        public string City
        {
            get; set;
        }

        public string PostCode
        {
            get; set;
        }

        public ICommand AddAddressCommand { get; set; }

        public AddressViewModel()
        {
            data = new DataContext();
            AddAddressCommand = new RelayCommand(ActionAddAddress);
        }

        private void ActionAddAddress()
        {
            Address address = new Address() { Street = Street, City = City, PostCode = PostCode };
            data.Addresses.Add(address);
            data.SaveChanges();
            MessageBox.Show("Adresse ajoutée");
        }
    }
}
