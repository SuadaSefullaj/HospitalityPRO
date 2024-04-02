using DAL.Contracts;
using Domain.Contracts;
using DTO.ExtraServiceDTO;
using HumanResourceProject.Models;
using LamarCodeGeneration.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtraServiceController : ControllerBase
    {
        private readonly IExtraServiceDomain _extraServiceDomain;

        public ExtraServiceController(IExtraServiceDomain extraServiceDomain)
        {
            _extraServiceDomain = extraServiceDomain;
            
        }



        [HttpGet("GetAllServices")]

        public async Task<ActionResult<IEnumerable<ExtraService>>> GetAllServices()
        {
            return null;

        }
        [HttpGet("{serviceId }")]
        public async Task<ActionResult<ExtraService>> GetExtraServiceById(int serviceId)
        {
           var data = _extraServiceDomain.GetByServiceId(serviceId);
            return Ok(data);
        }

        [HttpPost("{ addExtraService }")]
        public async Task<ActionResult<ExtraService>> AddExtraService(ExtraServiceDTO request)
        {
            return null;

        }

        [HttpPut("{ serviceId }")]
        public async Task<ActionResult<ExtraServiceDTO>> Update(int serviceId, ExtraServiceDTO request)
        {
            return null;

        }
        [HttpDelete("{ serviceId }")]
        public async Task<ActionResult<ExtraService>> DeleteExtraService(int serviceId)
        {
            return null;

        }



    }
}
