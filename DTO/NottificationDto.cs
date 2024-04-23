using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
	public class NottificationDto
	{
		public int NotificationId { get; set; }
		public int SenderClientId { get; set; }
		public int ReceiverClientId { get; set; }
		public int IsRead { get; set; }
		public int ReservationId { get; set; }

	}
}
