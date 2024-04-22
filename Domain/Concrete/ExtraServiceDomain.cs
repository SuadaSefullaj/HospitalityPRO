using AutoMapper;
using Domain.Contracts;
using DTO;
using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class ExtraServiceDomain : IExtraServiceDomain
    {
        private readonly HospitalityPRO_DbContext _dbContext;
        private readonly IMapper _mapper;

        public ExtraServiceDomain(HospitalityPRO_DbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public IEnumerable<ExtraServiceDTO> GetAllExtraServices()
        {
            var extraServices = _dbContext.ExtraServices.ToList();
            return _mapper.Map<List<ExtraServiceDTO>>(extraServices);
        }

        public ExtraServiceDTO GetExtraService(int id)
        {
            var extraService = _dbContext.ExtraServices.Find(id);
            return _mapper.Map<ExtraServiceDTO>(extraService);
        }

        public ExtraService AddExtraService(ExtraServiceDTO request)
        {
            var extraService = _mapper.Map<ExtraService>(request);
            _dbContext.ExtraServices.Add(extraService);
            _dbContext.SaveChanges();
            return extraService;
        }
        public ExtraService UpdateExtraService(int id, ExtraServiceDTO request)
        {
            var extraService = _dbContext.ExtraServices.Find(id);
            if (extraService != null)
            {
                _mapper.Map(request, extraService);
                _dbContext.SaveChanges();
            }
            return extraService;
        }


        public void DeleteExtraService(int id)
        {
            var extraService = _dbContext.ExtraServices.Find(id);
            if (extraService != null)
            {
                _dbContext.ExtraServices.Remove(extraService);
                _dbContext.SaveChanges();
            }
        }
    }
}