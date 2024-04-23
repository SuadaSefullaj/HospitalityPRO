using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class BrowsingDataDto
	{
		public int BrowsingId { get; set; }
		public string ActionType { get; set; } = null!;
		public DateTime Time { get; set; }
		public string ReservationDetails { get; set; } = null!;
	}
}
