using System;
using System.Collections.Generic;

namespace HumanResourceProject.Models
{
    public partial class BrowsingDatum
    {
        public int BrowsingId { get; set; }
        public string ActionType { get; set; } = null!;
        public DateTime Time { get; set; }
        public string ReservationDetails { get; set; } = null!;
    }
}
