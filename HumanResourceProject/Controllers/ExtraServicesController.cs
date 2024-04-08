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

        public ActionResult<IEnumerable<ExtraService>> GetAllServices()
        {
            var data = _extraServiceDomain.GetAllExtraServices();
            return Ok(data);
        }
        [HttpGet("{serviceId }")]
        public ActionResult<ExtraService> GetExtraServiceById(int serviceId)
        {
           var data = _extraServiceDomain.GetByServiceId(serviceId);
            return Ok(data);
        }

        [HttpPost("{ addExtraService }")]
        public ActionResult<ExtraService> AddExtraService(ExtraServiceDTO request)
        {
            var data = _extraServiceDomain.AddExtraService(request);
            return Ok(data);

        }

        [HttpPut("{ serviceId }")]
        public ActionResult<ExtraServiceDTO> Update(int serviceId, ExtraServiceDTO request)
        {
            var data = _extraServiceDomain.UpdateExtraService(serviceId, request);
            return Ok(data);

        }
        [HttpDelete("{ serviceId }")]
        public ActionResult<ExtraService> DeleteExtraService(int serviceId)
        {
            var data = _extraServiceDomain.DeleteExtraService(serviceId);
            return Ok(data);

        }
        
    }
}
