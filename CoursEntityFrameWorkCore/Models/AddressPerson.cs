using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoursEntityFrameWorkCore.Models
{
    public class AddressPerson
    {
        private int id;
        private int addressId;
        private int personId;

        public int Id { get => id; set => id = value; }

        [ForeignKey("Address")]
        public int AddressId { get => addressId; set => addressId = value; }

        [ForeignKey("Person")]
        public int PersonId { get => personId; set => personId = value; }

        public Person Person { get; set; }

        public Address Address { get; set; }
    }
}
