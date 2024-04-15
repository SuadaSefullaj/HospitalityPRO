using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HumanResourceProject.Models;
using DAL.Browsing_Data;
using DTO;
using System.Collections.Generic; 

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


	}
}
