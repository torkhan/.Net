using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoursEntityFrameWorkCore.Models
{
   [Table("personnes")]
    public class Person
    {
        private int id;
        private string firstName;
        private string lastName;
        private string phone;

        [Key]
        public int Id { get => id; set => id = value; }
        
        [Column("nom")]
        public string FirstName { get => firstName; set => firstName = value; }
        
        [Column("prenom")]
        public string LastName { get => lastName; set => lastName = value; }
        
        [Column("telephone")]
        [MaxLength(10)]
        public string Phone { get => phone; set => phone = value; }

        //[Column("adresse_id")]
        //[ForeignKey("Address")]
        //public int AddressId { get; set; }

        public List<AddressPerson> Addresses { get; set; }

        public Person()
        {
        }
    }
}
