using System;
using System.Collections.Generic;

namespace HumanResourceProject.Models
{
    public partial class Room
    {
        public Room()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int RoomNumber { get; set; }
        public string Availability { get; set; } = null!;
        public int HotelId { get; set; }
        public int TypeId { get; set; }

        public virtual Hotel Hotel { get; set; } = null!;
        public virtual RoomType Type { get; set; } = null!;
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
