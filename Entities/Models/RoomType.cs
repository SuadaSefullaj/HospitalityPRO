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
        public string Capacity { get; set; }
        public string Description { get; set; }
        public string BedType { get; set; }
        public string Features { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
