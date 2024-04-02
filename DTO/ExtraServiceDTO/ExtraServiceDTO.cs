using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ExtraServiceDTO
{
    public class ExtraServiceDTO
    {
        //public int ServiceId { get; set; }
        public string Type { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
    }
}
