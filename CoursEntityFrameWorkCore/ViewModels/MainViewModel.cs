using CoursEntityFrameWorkCore.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CoursEntityFrameWorkCore.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Person person;
        private Address lastSelectedAddress;

        public Person SelectedPerson { get; set; }

        private DataContext data;
        public string FirstName { get => person.FirstName; set { person.FirstName = value; RaisePropertyChanged(); } }
        public string LastName { get => person.LastName; set { person.LastName = value; RaisePropertyChanged(); } }
        public string Phone { get => person.Phone; set { person.Phone = value; RaisePropertyChanged(); } }


        public string Search { get; set; }

        public ObservableCollection<Person> Persons { get; set; }

        public ObservableCollection<Address> Addresses { get; set; }

        public IList PersonAddresses
        {
            get;set;
        }
        public ICommand ConfirmCommand { get; set; }
        public ICommand SelectCommand { get; set; }

        public ICommand SelectedAddressCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand AddAddressCommand { get; set; }
        public MainViewModel()
        {
            data = new DataContext();
            Persons = new ObservableCollection<Person>(data.Persons.Include(p => p.Addresses));
            Addresses = new ObservableCollection<Address>(data.Addresses);
            person = new Person();
            person.Addresses = new List<AddressPerson>();
            ConfirmCommand = new RelayCommand(ActionConfirm);
            SelectCommand = new RelayCommand(ActionSelect);
            DeleteCommand = new RelayCommand(ActionDelete);
            SearchCommand = new RelayCommand(ActionSearch);
            AddAddressCommand = new RelayCommand(ActionAddAddress);
            SelectedAddressCommand = new RelayCommand<Address>(ActionSelectedAddress);
            PersonAddresses = new List<Address>();
            SelectedPerson = null;
        }

        private void ActionAddAddress()
        {
            AddressWindow w = new AddressWindow();
            w.Show();
        }
        private void ActionConfirm()
        {
            if (SelectedPerson == null)
            {
                data.Persons.Add(person);
                Persons.Add(person);
                MessageBox.Show("Insert");
            }
            else
            {
                MessageBox.Show("Update");
            }
            data.SaveChanges();
            person = new Person();
            foreach (PropertyInfo p in typeof(MainViewModel).GetProperties())
            {
                RaisePropertyChanged(p.Name);
            }
        }

        private void ActionSelectedAddress(Address address)
        {
            person.Addresses.Add(new AddressPerson() { Address = address, Person = person }) ;
        }

        private void ActionSelect()
        {
            person = SelectedPerson;
            if (person.Addresses == null)
                person.Addresses = new List<AddressPerson>();
            //RaisePropertyChanged("FirstName");
            //RaisePropertyChanged("LastName");
            //RaisePropertyChanged("Phone");
            //RaisePropertyChanged("Street");
            //RaisePropertyChanged("City");
            //RaisePropertyChanged("PostCode");
            foreach (PropertyInfo p in typeof(MainViewModel).GetProperties())
            {
                RaisePropertyChanged(p.Name);
            }
        }
        private void ActionDelete()
        {
            if (SelectedPerson != null)
            {
                data.Persons.Remove(SelectedPerson);
                data.SaveChanges();
                Persons.Remove(SelectedPerson);
            }
        }

        private void ActionSearch()
        {
            Persons = new ObservableCollection<Person>(data.Persons.Where(p => p.FirstName.Contains(Search) || p.LastName.Contains(Search)));
            RaisePropertyChanged("Persons");
        }
    }
}
