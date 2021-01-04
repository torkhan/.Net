using System;
using System.Collections.Generic;
using System.Text;

namespace HotelWPFMVVM.Models
{
    public class Room
    {
        private int id;
        private int number;
        private decimal cost;
        private RoomStatus status;
        private int capacity;

        public int Id { get => id; set => id = value; }
        public int Number { get => number; set => number = value; }
        public decimal Cost { get => cost; set => cost = value; }
        public RoomStatus Status { get => status; set => status = value; }
        public int Capacity { get => capacity; set => capacity = value; }

        public List<ReservationRoom> Reservations { get; set; }
        public override string ToString()
        {
            return $"{Number}, {Cost}€, {Capacity}, {Status.ToString()}";
        }
    }

    public enum RoomStatus
    {
        free,
        busy
    }
}
