using AutoMapper;
using DTO.ExtraServiceDTO;
using DTO.UserDTO;
using Entities.Models;
using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappings
{
    public class GeneralProfile : Profile
    {
        #region User
        public GeneralProfile()
        {
           CreateMap<User, UserDTO>().ReverseMap();
           CreateMap<ExtraServiceDTO, ExtraService>();
        }

        #endregion


    }
}
