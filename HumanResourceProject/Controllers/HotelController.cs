using HumanResourceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HumanResourceProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HotelController : ControllerBase
	{
		private readonly HospitalityPRO_DbContext _context;

		public HotelController(HospitalityPRO_DbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetHotelName()
		{
			var hotel = _context.Hotels.FirstOrDefault();
			if (hotel == null)
			{
				return NotFound("Hotel not available");
			}
			else
			{
				return Ok(hotel.Name);
			}
		}

		[HttpPost]
		public IActionResult PostEmriHotelit(Hotel hotel)
		{
			_context.Add(hotel);
			_context.SaveChanges();
			return Ok("Hotel Created");
		}

		[HttpPut]
		public IActionResult PutEmriIHotelit(Hotel hotel1)
		{
			if (hotel1 == null)
			{
				return BadRequest("You haven't provided a valid hotel object.");
			}

			var hotelToUpdate = _context.Hotels.FirstOrDefault(h => h.Name == hotel1.Name);

			if (hotelToUpdate == null)
			{
				return NotFound($"Hotel with name {hotel1.Name} not found.");
			}

			hotelToUpdate.Name = hotel1.Name;
			_context.SaveChanges();

			return Ok($"Hotel with name {hotel1.Name} updated successfully.");
		}
	}
}
