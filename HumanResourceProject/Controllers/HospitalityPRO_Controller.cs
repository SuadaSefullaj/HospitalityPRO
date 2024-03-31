using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HumanResourceProject.Models;



namespace HospitalityPRO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalityPRO_Controller : ControllerBase
    {
        private readonly HospitalityPRO_DbContext _dbContext;

        public HospitalityPRO_Controller(HospitalityPRO_DbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Client>>> GetHospitality()
        {
            return Ok(await _dbContext.Clients.ToListAsync());
            return Ok(await _dbContext.Reservations.ToListAsync());
            return Ok(await _dbContext.Rooms.ToListAsync());
            return Ok(await _dbContext.RoomTypes.ToListAsync());
            return Ok(await _dbContext.ReservationServices.ToListAsync());
            return Ok(await _dbContext.ExtraServices.ToListAsync());
            return Ok(await _dbContext.Notifications.ToListAsync());
        }
    }
}