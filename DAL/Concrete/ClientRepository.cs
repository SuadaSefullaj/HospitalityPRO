using DAL.Contracts;
using HumanResourceProject.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _dbContext.Clients.ToListAsync();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _dbContext.Clients.FirstOrDefaultAsync(c => c.ClientId == id)
                 ?? throw new Exception("Client not found"); ;
        }
    }
}
