using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RoomDTO
    {
        public int RoomNumber { get; set; }
        public string Availability { get; set; } = null!;
        public int TypeId { get; set; }

        public string Type { get; set; } = null!;
        public double Price { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public string BedType { get; set; }
        public string Features { get; set; }
    }
}
