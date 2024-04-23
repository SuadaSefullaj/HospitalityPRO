using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HumanResourceProject.Models;
using DTO;
using System.Collections.Generic;
using DAL.Contacts;

namespace HumanResourceProject.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class BrowsingDataController : ControllerBase 
	{
		private readonly IBrowsingDataRepository _browsingDataReopository;
		private readonly IMapper _mapper;

		public BrowsingDataController(IBrowsingDataRepository browsingDataReopository, IMapper mapper)
		{
			_browsingDataReopository = browsingDataReopository;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<BrowsingDataDto>))] 
		public IActionResult GetData()
		{
			var data = _mapper.Map<List<BrowsingDataDto>>(_browsingDataReopository.GetAllData());

			return Ok(data); 
		}

		[HttpGet("{browsingdataId}")]
		[ProducesResponseType(200, Type = typeof(BrowsingDataDto))]
		[ProducesResponseType(400)]
		public IActionResult GetData(int browsingdataId) 
		{
			if (!_browsingDataReopository.DataExists(browsingdataId))
			{
				return NotFound();
			}
			var data1 = _mapper.Map<BrowsingDataDto>(_browsingDataReopository.GetData(browsingdataId));

			return Ok(data1); 
		}
		 [HttpPost]
[ProducesResponseType(201)]
[ProducesResponseType(400)]
[ProducesResponseType(422)]
public IActionResult CreateData([FromBody] BrowsingDataDto dataCreateDto)
{
    if (dataCreateDto == null)
    {
        return BadRequest("Invalid data provided.");
    }

    
    Guid newGuid = Guid.NewGuid();
    int browsingId = newGuid.GetHashCode();
	if(browsingId < 0)
			{
				browsingId = browsingId * -1;
			}
   
    var browsingData = new BrowsingData
    {
        BrowsingId = browsingId,
        ActionType = dataCreateDto.ActionType,
        Time = DateTime.Now,
		reservationDetails = dataCreateDto.ReservationDetails
	};

    
    if (!_browsingDataReopository.CreateData(browsingData))
    {
        return StatusCode(500, "Failed to save browsing data.");
    }

    return Ok("Data u krijua");
	}

		[HttpDelete("{dataId}")]
		[ProducesResponseType(400)]
		[ProducesResponseType(204)]
		[ProducesResponseType(404)]
		public IActionResult DeleteOwner(int dataId)
		{
			if (!_browsingDataReopository.DataExists(dataId))
			{
				return NotFound();
			}

			var dataToDelete = _browsingDataReopository.GetData(dataId);

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (!_browsingDataReopository.DeleteData(dataToDelete))
			{
				ModelState.AddModelError("", "Something went wrong deleting owner");
			}

			return Ok("Data u fshi");
		}

	}
}
