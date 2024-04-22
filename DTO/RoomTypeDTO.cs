using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RoomTypeDTO
    {
        public string Type { get; set; } = null!;
        public double Price { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public string BedType { get; set; }
        public string Features { get; set; }
    }
}
