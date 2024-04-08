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
            var clients = await _dbContext.Clients.ToListAsync();
            var reservations = await _dbContext.Reservations.ToListAsync();
            var rooms = await _dbContext.Rooms.ToListAsync();
            var roomTypes = await _dbContext.RoomTypes.ToListAsync();
            var reservationServices = await _dbContext.ReservationServices.ToListAsync();
            var extraServices = await _dbContext.ExtraServices.ToListAsync();
            var notifications = await _dbContext.Notifications.ToListAsync();

            var hospitalityData = new
            {
                Clients = clients,
                Reservations = reservations,
                Rooms = rooms,
                RoomTypes = roomTypes,
                ReservationServices = reservationServices,
                ExtraServices = extraServices,
                Notifications = notifications
            };

            return Ok(hospitalityData);
        }
    }
}