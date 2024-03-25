using System;
using System.Collections.Generic;

namespace HumanResourceProject.Models
{
    public partial class ReservationService
    {
        public int ReservationServicesId { get; set; }
        public int ReservationId { get; set; }
        public int ServicesId { get; set; }

        public virtual Reservation Reservation { get; set; } = null!;
        public virtual ExtraService Services { get; set; } = null!;
    }
}
