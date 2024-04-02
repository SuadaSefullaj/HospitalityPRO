using AutoMapper;
using DAL.Concrete;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.ExtraServiceDTO;
using HumanResourceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    internal class ExtraServiceDomain : DomainBase, IExtraServiceDomain
    {
        public ExtraServiceDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }
        private IExtraServicesRepository extraServicesRepository => _unitOfWork.GetRepository<IExtraServicesRepository>();

        public async ExtraService AddExtraService(ExtraServiceDTO request)
        {
            //var extraService = new ExtraService
            //{
            //    Type = request.Type,
            //    Price = request.Price,
            //    Description = request.Description
            //};

            // var addedExtraService = _dbContext.ExtraServices.Add(extraService);
            //await _dbContext.SaveChangesAsync();

           // return addedExtraService.Entity;
           return null;
        }

       
        public async Task<ExtraServiceDTO> UpdateExtraService(int serviceId, ExtraServiceDTO request)
        {
            //var updatedExtraService = await _dbContext.ExtraServices.FindAsync(serviceId);

            //updatedExtraService.Type = request.Type;
            //updatedExtraService.Price = request.Price;
            //updatedExtraService.Description = request.Description;

            //await _dbContext.SaveChangesAsync();

            //return request;
            return null;
        }
        public async Task<bool> DeleteExtraService(Guid serviceId)
        {
            //   var extraServicesRepository = await _dbContext.ExtraServices.FindAsync(serviceId);
            extraServicesRepository.Remove(serviceId);
            return true;

        }

        public ExtraServiceDTO GetByServiceId(int serviceId)
        {
            ExtraService currentData = extraServicesRepository.GetExtraServicesById(serviceId);

            ExtraServiceDTO mapper = _mapper.Map<ExtraServiceDTO>(currentData);
            return mapper;
        }
    }
}
