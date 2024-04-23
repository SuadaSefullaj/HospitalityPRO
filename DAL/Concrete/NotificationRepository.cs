using DAL.Contacts;
using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
	public class NotificationRepository : INotificationRepository
	{
		private readonly HospitalityPRO_DbContext _context;

		public NotificationRepository(HospitalityPRO_DbContext context)
        {
			_context = context;
		}
        public bool CreateNotification(Notification notification)
		{
			_context.Add(notification);
			return Save();
		}

		public bool DeleteNotification(Notification notification)
		{
			_context.Remove(notification);
			return Save();
		}

		public ICollection<Notification> GetAllNotifications()
		{
			return _context.Notifications.ToList();
		}

		public Notification GetNotification(int id)
		{
			return _context.Notifications.Where(s => s.NotificationId == id).FirstOrDefault();
		}

		public bool NotificationExists(int notiId)
		{
			if (_context.Notifications.Any(p => p.NotificationId == notiId)) return true;
			else return false;
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}
	}
}
