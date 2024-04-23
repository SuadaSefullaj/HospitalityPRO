using AutoMapper;
using DAL.Concrete;
using DAL.Contacts;
using DTO;
using HumanResourceProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationRepository _notificationRepository;
		private readonly IMapper _mapper;

		public NotificationController(INotificationRepository notificationRepository, IMapper mapper)
        {
			_notificationRepository = notificationRepository;
			_mapper = mapper;
		}
		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<NottificationDto>))]
		public IActionResult GetNotifications()
		{
			var noti = _mapper.Map<List<NottificationDto>>(_notificationRepository.GetAllNotifications());

			return Ok(noti);
		}
		[HttpGet("{notificationId}")]
		[ProducesResponseType(200, Type = typeof(Notification))]
		[ProducesResponseType(400)]
		public IActionResult GetNotification(int notificationId)
		{
			if(!_notificationRepository.NotificationExists(notificationId))	
				return NotFound();
			var notification = _mapper.Map<NottificationDto>(_notificationRepository.GetNotification(notificationId));
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return Ok(notification);

		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(422)]
		public IActionResult CreateNotification([FromBody] NottificationDto notificationDto)
		{

			if (notificationDto == null)
			{
				return BadRequest("Invalid data provided.");
			}


			Guid newGuid = Guid.NewGuid();
			int notificationid = newGuid.GetHashCode();
			if (notificationid < 0)
			{
				notificationid = notificationid * -1;
			}

			var notification = new Notification
			{
				NotificationId = notificationid,
				IsRead = 1,

				
			};


			if (!_notificationRepository.CreateNotification(notification))
			{
				return StatusCode(500, "Failed to save browsing data.");
			}
			
			return Ok("Notification u krijua me sukses");
		}



	}

	}

