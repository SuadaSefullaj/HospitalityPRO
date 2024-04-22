using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ExtraServiceDTO
    {
        public string Type { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
    }
}
