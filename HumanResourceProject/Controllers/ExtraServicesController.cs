﻿using DAL.Contracts;
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
        private readonly IExtraServicesRepository _extraServicesRepository;

        public ExtraServiceController(HospitalityPRO_DbContext dbContext,ExtraService services)
        {
            _dbContext = dbContext;
            _services = services;
        }



        [HttpGet("getAllServices")]

        public async Task<ActionResult<IEnumerable<ExtraService>>> GetAllServices()
        {
            var extraService = await _extraServicesRepository.GetAllServices();
            return Ok(extraService);
        }
        [HttpGet("{serviceId }")]
        public async Task<ActionResult<ExtraService>> GetExtraServiceById(int serviceId)
        {
            var service = await _extraServicesRepository.GetExtraServicesById(serviceId);
            if (service == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_services);
            }
        }

        [HttpPost("{ addExtraService }")]
        public async Task<ActionResult<ExtraService>> AddExtraService(ExtraServiceDTO request)
        {
            var result = await _extraServicesRepository.AddExtraService(request);
            if (request == null)
            {
                 return BadRequest("Failed to add a new Extra Service!!!");
            }
            else
            {
                return Ok(result);
            }
        }

        //[HttpPut]
        //public async Task<ActionResult> Update(int serviceId, ExtraServiceDTO request)
        //{
        //    var result = await _dbContext.ExtraServices.UpdateExtraService(serviceId, request);
        //    _dbContext.SaveChanges();
        //    return Ok();
        ////}
        //[HttpDelete]
        //public async Task<ActionResult<ExtraService>> Delete(int serviceId)
        //{
        //    var service = _dbContext.ExtraServices.FirstOrDefault(x => x.ServicesId == serviceId);
        //    if (service != null)
        //    {
        //        _dbContext.ExtraServices.Remove(service);
        //        _dbContext.SaveChanges();
        //        return Ok();
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}



    }
}