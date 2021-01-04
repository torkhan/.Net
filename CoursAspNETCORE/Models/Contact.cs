using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace CoursAspNETCORE.Models
{
    public class Contact
    {
        private int id;
        private string firstName;
        private string lastName;
        private string phone;
        private string avatar;
        List<Email> mails;

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Phone { get => phone; set => phone = value; }
        public List<Email> Mails { get => mails; set => mails = value; }
        public string Avatar { get => avatar; set => avatar = value; }

        public static List<Contact> GetContacts()
        {
            DataContext data = new DataContext();
            return new List<Contact>(data.Contacts.Include(c => c.Mails));
        }

        public static Contact GetContactById(int id)
        {
            DataContext data = new DataContext();
            return data.Contacts.Include(c => c.Mails).FirstOrDefault(c => c.Id == id);
        }

        public bool Save()
        {
            DataContext data = new DataContext();
            data.Contacts.Add(this);
            return data.SaveChanges() > 0;

        }

        public bool Delete()
        {
            DataContext data = new DataContext();
            data.Contacts.Remove(this);
            return data.SaveChanges() > 0;
        }

        public static bool AddMail(Email email, int contactId)
        {
            DataContext data = new DataContext();
            Contact contact = data.Contacts.Include(c => c.Mails).FirstOrDefault(c => c.Id == contactId);
            contact.Mails.Add(email);
            return data.SaveChanges() > 0;
        }

        public static bool RemoveMail(int emailId, int contactId)
        {
            DataContext data = new DataContext();
            Contact contact = data.Contacts.Include(c => c.Mails).FirstOrDefault(c => c.Id == contactId);
            contact.Mails.Remove(contact.Mails.Find(e => e.Id == emailId));
            return data.SaveChanges() > 0;
        }

        public static bool UpdateContact(Contact tmpContact)
        {
            DataContext data = new DataContext();
            Contact contact = data.Contacts.FirstOrDefault(c => c.Id == tmpContact.Id);
            contact.FirstName = tmpContact.FirstName;
            contact.LastName = tmpContact.LastName;
            contact.Phone = tmpContact.Phone;
            return data.SaveChanges() > 0;
        }

        public static List<Contact> SearchContacts(string search)
        {
            DataContext data = new DataContext();
            return new List<Contact>(
                data.Contacts.Include(c => c.Mails).Where(
                    c => c.Phone.Contains(search) ||c.FirstName.Contains(search) || c.LastName.Contains(search)
                    )
                );
        }
    }
}
