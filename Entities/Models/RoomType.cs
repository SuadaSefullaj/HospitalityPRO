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
        public int Capacity { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
