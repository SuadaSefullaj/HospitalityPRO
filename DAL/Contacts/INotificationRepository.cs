using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contacts
{
	public interface INotificationRepository
	{
		ICollection<Notification> GetAllNotifications();	
		Notification GetNotification(int id);
		bool NotificationExists(int notiId);

		bool CreateNotification(Notification notification);
		bool DeleteNotification(Notification notification);
		bool Save();
	}
}
