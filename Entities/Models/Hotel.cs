using System;
using System.Collections.Generic;

namespace HumanResourceProject.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            Rooms = new HashSet<Room>();
        }

        public int HotelId { get; set; }
        public string Name { get; set; } = null!;
        public string Owner { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int Stars { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
