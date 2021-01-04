using AnnuaireMVVMEntityFrameWork.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;

namespace AnnuaireMVVMEntityFrameWork.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Contact contact;
        private DataContext data;

        public string FirstName
        {
            get => contact.FirstName;
            set
            {
                contact.FirstName = value;
            }
        }

        public string LastName
        {
            get => contact.LastName;
            set
            {
                contact.LastName = value;
            }
        }

        public string Phone
        {
            get => contact.Phone;
            set
            {
                contact.Phone = value;
            }
        }

        public string Mail { get; set; }
        public ObservableCollection<Email> Mails { get; set; }
        public string Search { get; set; }
        public ObservableCollection<Contact> Contacts { get; set; }
        public Contact SelectedContact { get; set; }
        public ICommand AddMailCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public MainViewModel()
        {
            data = new DataContext();
            contact = new Contact();
            Mails = new ObservableCollection<Email>();
            Contacts = new ObservableCollection<Contact>(data.Contacts.Include(c => c.Mails));
            AddMailCommand = new RelayCommand(ActionAddMail);
            ConfirmCommand = new RelayCommand(ActionConfirm);
            DeleteCommand = new RelayCommand(ActionDelete);
            SearchCommand = new RelayCommand(ActionSearch);
        }

        private void ActionAddMail()
        {
            if(Mail != null)
            {
                Mails.Add(new Email() { Mail = Mail });
                Mail = "";
                RaisePropertyChanged("Mail");
            }
        }

        private void ActionSearch()
        {
            Contacts = new ObservableCollection<Contact>(
                data.Contacts.Where(c => c.FirstName.Contains(Search))
                );
            Search = "";
            RaiseAll();
        }

        private void ActionConfirm()
        {
            contact.Mails = Mails.Cast<Email>().ToList();
            data.Contacts.Add(contact);
            data.SaveChanges();
            Contacts.Add(contact);
            contact = new Contact();
            Mails = new ObservableCollection<Email>();
            RaiseAll();
        }
        
        private void ActionDelete()
        {
            if(SelectedContact != null)
            {
                data.Contacts.Remove(SelectedContact);
                Contacts.Remove(SelectedContact);
                data.SaveChanges();
                SelectedContact = null;
                RaiseAll();
            }
        }

        private void RaiseAll()
        {
            foreach (PropertyInfo p in typeof(MainViewModel).GetProperties())
            {
                RaisePropertyChanged(p.Name);
            }
        }
    }
}
