using DAL.Contracts;
using HumanResourceProject.Models;
using Microsoft.EntityFrameworkCore;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class ClientRepository : IClientRepository
    {
        private readonly HospitalityPRO_DbContext _dbContext;

        public ClientRepository(HospitalityPRO_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _dbContext.Clients.ToList();
        }

        public Client GetClientById(int id)
        {
            var client = _dbContext.Clients.FirstOrDefault(c => c.ClientId == id);
            return client;
        }

    }
}
