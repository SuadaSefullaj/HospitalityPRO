using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class RefreshToken
    {
        [Key]
        public int TokenId { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
