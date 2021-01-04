using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelWPFMVVM.Models
{
    public class ReservationRoom
    {
        private int id;

        private int reservationId;

        private int roomId;

        public int Id { get => id; set => id = value; }
        
        [ForeignKey("Reservation")]
        public int ReservationId { get => reservationId; set => reservationId = value; }
        
        [ForeignKey("Room")]
        public int RoomId { get => roomId; set => roomId = value; }

        public Room Room { get; set; }
        public Reservation Reservation { get; set; }
    }
}
