using AutoMapper;
using DAL.Contracts;
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
        private readonly IExtraServiceRepository _extraServiceRepository;
        private readonly IMapper _mapper;

        public ExtraServiceDomain(IExtraServiceRepository extraServiceRepository, IMapper mapper)
        {
            _extraServiceRepository = extraServiceRepository;
            _mapper = mapper;
        }

        public IEnumerable<ExtraServiceDTO> GetAllExtraServices()
        {
            var extraServices = _extraServiceRepository.GetAllExtraServices();
            return _mapper.Map<List<ExtraServiceDTO>>(extraServices);
        }

        public ExtraServiceDTO GetExtraService(int id)
        {
            var extraService = _extraServiceRepository.GetExtraService(id);
            return _mapper.Map<ExtraServiceDTO>(extraService);
        }

        public ExtraService AddExtraService(ExtraServiceDTO request)
        {
            var extraService = _mapper.Map<ExtraService>(request);
            return _extraServiceRepository.AddExtraService(extraService);
        }

        public ExtraService UpdateExtraService(int id, ExtraServiceDTO request)
        {
            var extraService = _extraServiceRepository.GetExtraService(id);
            if (extraService != null)
            {
                _mapper.Map(request, extraService);
                _extraServiceRepository.UpdateExtraService(extraService);
            }
            return extraService;
        }

        public void DeleteExtraService(int id)
        {
            _extraServiceRepository.DeleteExtraService(id);
        }
    }
}