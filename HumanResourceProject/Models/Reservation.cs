using System;
using System.Collections.Generic;

namespace HumanResourceProject.Models
{
    public partial class Reservation
    {
        public Reservation()
        {
            Notifications = new HashSet<Notification>();
            ReservationServices = new HashSet<ReservationService>();
        }

        public int ReservationId { get; set; }
        public string ReservationStatus { get; set; } = null!;
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public double TotalPrice { get; set; }
        public int ClientId { get; set; }
        public int RoomNumber { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Room RoomNumberNavigation { get; set; } = null!;
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<ReservationService> ReservationServices { get; set; }
    }
}
