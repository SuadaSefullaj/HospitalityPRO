using System;
using System.Collections.Generic;

namespace HumanResourceProject.Models
{
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public int SenderClientId { get; set; }
        public int ReceiverClientId { get; set; }
        public int IsRead { get; set; }
        public int ReservationId { get; set; }

        public virtual Client ReceiverClient { get; set; } = null!;
        public virtual Reservation Reservation { get; set; } = null!;
        public virtual Client SenderClient { get; set; } = null!;
    }
}
