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
        private readonly ExtraService _services;
        private readonly HospitalityPRO_DbContext _dbContext;

        public ExtraServiceController(HospitalityPRO_DbContext dbContext,ExtraService services)
        {
            _dbContext = dbContext;
            _services = services;
        }



        [HttpGet]
        public async Task<ActionResult> GetAllServices()
        {
            var extraService = _services.GetType();
            return Ok(extraService);
        }
        public async Task<ActionResult> GetExtraServiceById(int serviceId)
        {
            var service = await _dbContext.ExtraServices.FindAsync(serviceId);
            if (service == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_services);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddExtraService(ExtraServiceDTO request)
        {
            _dbContext.ExtraServices.Add(new ExtraService { Type = request.Type });
            _dbContext.SaveChanges();
            if (request == null)
            {
                return BadRequest("Failed to add a new Extra Service!!!");
            }
            else
            {
                return Ok(request);
            }
        }

        //[HttpPut]
        //public async Task<ActionResult> Update(int serviceId, ExtraServiceDTO request)
        //{
        //    var result = await _dbContext.ExtraServices.UpdateExtraService(serviceId, request);
        //    _dbContext.SaveChanges();
        //    return Ok();
        //}
        [HttpDelete]
        public async Task<ActionResult> Delete(int serviceId)
        {
            var service = _dbContext.ExtraServices.FirstOrDefault(x => x.ServicesId == serviceId);
            if (service != null)
            {
                _dbContext.ExtraServices.Remove(service);
                _dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }



    }
}
