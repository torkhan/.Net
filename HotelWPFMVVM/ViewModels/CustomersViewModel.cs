using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HotelWPFMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace HotelWPFMVVM.ViewModels
{
    class CustomersViewModel : ViewModelBase
    {
        private DataBaseContext data;
        private Customer customer;

        public string FirstName
        {
            get => customer.FirstName;
            set
            {
                customer.FirstName = value;
                RaisePropertyChanged();
            }
        }
        public string LastName
        {
            get => customer.LastName;
            set
            {
                customer.LastName = value;
                RaisePropertyChanged();
            }
        }
        public string Phone
        {
            get => customer.Phone;
            set
            {
                customer.Phone = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Customer> Customers { get; set; }

        public ICommand ConfirmCommand { get; set; }
        
        public CustomersViewModel()
        {
            customer = new Customer();
            data = new DataBaseContext();
            Customers = new ObservableCollection<Customer>(data.Customers);
            ConfirmCommand = new RelayCommand(SaveCustomer);
        }

        private void SaveCustomer()
        {
            data.Customers.Add(customer);
            if(data.SaveChanges() > 0)
            {
                MessageBox.Show("Client enregisté avec l'id : " + customer.Id);
                Customers.Add(customer);
                customer = new Customer();
                RaisePropertyChanged("FirstName");
                RaisePropertyChanged("LastName");
                RaisePropertyChanged("Phone");
            }
        }
    }
}
