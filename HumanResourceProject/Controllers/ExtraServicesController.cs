﻿using HospitalityPRO.Model;
using HumanResourceProject.Models;
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
        public ExtraServiceController(HospitalityPRO_DbContext dBContext)
        {
            _dbContext = dBContext;
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
        public async Task<ActionResult> AddExtraService(ExtraService extraService)
        {
            _dbContext.ExtraServices.Add(extraService);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(int serviceId, ExtraService extraService)
        {
            _dbContext.ExtraServices.Update(extraService);
            _dbContext.SaveChanges();
            return Ok();
        }
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
