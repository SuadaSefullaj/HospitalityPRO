using HumanResourceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ClientService
{
    public class ClientService : IClientService
    {

        private readonly HospitalityPRO_DbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClientService(IHttpContextAccessor httpContextAccessor, HospitalityPRO_DbContext dbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
        }
        public string GetMyName()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            }
            return result;
        }
    }

  
}
