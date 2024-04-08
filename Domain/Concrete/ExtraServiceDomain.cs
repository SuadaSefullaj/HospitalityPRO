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
        public ExtraServiceDTO GetByServiceId(int serviceId)
        {
            ExtraService currentData = extraServicesRepository.GetExtraServicesById(serviceId);
            return _mapper.Map<ExtraServiceDTO>(currentData);
        }
        public IList<ExtraServiceDTO> GetAllExtraServices()
        {
            IEnumerable<ExtraService> data = extraServicesRepository.GetAll();
            return _mapper.Map<IList<ExtraServiceDTO>>(data);
        }
        public ExtraService AddExtraService(ExtraServiceDTO request)
        {
            ExtraService extraService = _mapper.Map<ExtraService>(request);
            
            ExtraService addedExtraService = extraServicesRepository.Add(extraService);
            extraServicesRepository.PersistChangesToTrackedEntities();
            return addedExtraService;
        }

       
        public bool UpdateExtraService(int serviceId, ExtraServiceDTO request)
        {
            var currentData = extraServicesRepository.Find(x => x.ServicesId == serviceId).FirstOrDefault();
            if (currentData != null)
            {
                _mapper.Map(request, currentData);
                extraServicesRepository.Update(currentData);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }
        public bool DeleteExtraService(int serviceId)
        {
            var currentData = extraServicesRepository.Find(x => x.ServicesId == serviceId).FirstOrDefault();
            extraServicesRepository.Remove(currentData);
            _unitOfWork.Save();
            return true;
        }

        
    }
}
