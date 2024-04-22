using AutoMapper;
using Domain.Contracts;
using DTO;
using HumanResourceProject.Models;
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

        [HttpGet("getAllExtraService")]
        public ActionResult<IEnumerable<ExtraServiceDTO>> GetExtraServices()
        {
            return Ok(_extraServiceDomain.GetAllExtraServices());
        }

        [HttpGet("{id}")]
        public ActionResult<ExtraServiceDTO> GetExtraService(int id)
        {
            var extraService = _extraServiceDomain.GetExtraService(id);
            if (extraService == null)
                return NotFound();
            return extraService;
        }

        [HttpPost("addExtraService")]
        public ActionResult<ExtraServiceDTO> AddExtraService(ExtraServiceDTO request)
        {
            var extraService = _extraServiceDomain.AddExtraService(request);
            return request;
        }

        [HttpPut("{id}")]
        public ActionResult<ExtraServiceDTO> UpdateExtraService(int id, ExtraServiceDTO request)
        {
            var updatedExtraService = _extraServiceDomain.UpdateExtraService(id, request);
            if (updatedExtraService == null)
                return NotFound();

            return request;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExtraService(int id)
        {
            _extraServiceDomain.DeleteExtraService(id);
            return Ok("This Extra Service has been deleted!");
        }

    }
}
