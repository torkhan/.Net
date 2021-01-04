using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoursEntityFrameWorkCore.Models
{
    [Table("adresses")]
    public class Address
    {
        private int id;
        private string street;
        private string city;
        private string postCode;

        [Key]
        public int Id { get => id; set => id = value; }
        
        [Column("rue")]
        public string Street { get => street; set => street = value; }

        [Column("ville")]
        public string City { get => city; set => city = value; }
        
        [Column("code_postal")]
        public string PostCode { get => postCode; set => postCode = value; }

        public List<AddressPerson> Persons { get; set; }

        public override string ToString()
        {
            return Street +" "+ City +" "+ PostCode;
        }
    }
}
