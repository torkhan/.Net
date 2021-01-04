using System;
using System.Collections.Generic;
using System.Text;

namespace CoursAspNETCORE.Models
{
    public class Email
    {
        private int id;
        private string mail;

        public int Id { get => id; set => id = value; }
        public string Mail { get => mail; set => mail = value; }

        public override string ToString()
        {
            return Mail;
        }
    }
}
