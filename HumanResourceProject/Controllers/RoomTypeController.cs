using HumanResourceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;
using AutoMapper;
using Domain.Contracts;
using Domain.Concrete;

namespace HumanResourceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpGet("getAllRoomTypes")]
        public IActionResult GetRoomTypes()
        {
            var roomTypeDTOs = _roomTypeService.GetAllRoomTypes();
            return Ok(roomTypeDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetRoomTypeById(int id)
        {
            var roomTypeDto = _roomTypeService.GetRoomTypeById(id);

            if (roomTypeDto == null)
            {
                return NotFound();
            }

            return Ok(roomTypeDto);
        }

        [HttpPost("createRoomType")]
        public IActionResult CreateRoomType(RoomTypeDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _roomTypeService.CreateRoomType(request);

            return Ok(request);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRoomType(int id, RoomTypeDTO request)
        {
            _roomTypeService.UpdateRoomType(id, request);
            return Ok(request);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoomType(int id)
        {
            _roomTypeService.DeleteRoomType(id);
            return Ok("This room type is deleted!");
        }
    }
}