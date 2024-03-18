using HumanResourceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HospitalityPRO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalityPRO_Controller : ControllerBase
    {
        private readonly HospitalityPRO_DbContext _context;

        public HospitalityPRO_Controller(HospitalityPRO_DbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Client>>> GetHospitality()
        {
            return Ok(await _context.Clients.ToListAsync());
            return Ok(await _context.Reservations.ToListAsync());
            return Ok(await _context.Rooms.ToListAsync());
            return Ok(await _context.RoomTypes.ToListAsync());
            return Ok(await _context.ReservationServices.ToListAsync());
            return Ok(await _context.ExtraServices.ToListAsync());
            return Ok(await _context.Notifications.ToListAsync());
        }
    }
}
