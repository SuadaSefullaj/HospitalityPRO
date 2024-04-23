using System;
using System.Collections.Generic;

namespace HumanResourceProject.Models
{
    public partial class RoomType
    {
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        public int TypeId { get; set; }
        public string Type { get; set; } = null!;
        public double Price { get; set; }
        public string Capacity { get; set; } // Changed from int to string
        public string Description { get; set; } // Added
        public string BedType { get; set; } // Added
        public string Features { get; set; } // Added

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
