using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelWPFMVVM.Models
{
    public class Reservation
    {
        private int id;
        private decimal price;
        private ReservationStatus status;
        private int nbPersons;

        public int Id { get => id; set => id = value; }
        public decimal Price { get => price; set => price = value; }
        public ReservationStatus Status { get => status; set => status = value; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<ReservationRoom> Rooms { get; set; }
        public int NbPersons { get => nbPersons; set => nbPersons = value; }

        public override string ToString()
        {
            string re = "";
            re += $"Numéro : {Id}\n";
            re += Customer?.ToString() + "\n";
            Rooms?.ForEach(rr =>
            {
                re += rr.Room?.ToString() +"\n";
            });
            re += $"{Price}€\n";
            
            return re;
        }
    }

    public enum ReservationStatus
    {
        confirmed,
        canceld
    }
}
