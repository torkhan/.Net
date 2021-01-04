using System;
using System.Collections.Generic;
using System.Text;

namespace AnnuaireMVVMEntityFrameWork.Models
{
    public class Contact
    {
        private int id;
        private string firstName;
        private string lastName;
        private string phone;
        List<Email> mails;

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Phone { get => phone; set => phone = value; }
        public List<Email> Mails { get => mails; set => mails = value; }
    }
}
