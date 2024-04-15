using System;
using System.Collections.Generic;

namespace HumanResourceProject.Models
{
    public  class BrowsingData
    {
        public int BrowsingId { get; set; }

        public string ActionType { get; set; } = null!;
        public DateTime Time { get; set; }
        public string ReservationDetails { get; set; } = null!;
    }
}
