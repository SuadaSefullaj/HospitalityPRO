using HumanResourceProject.Models;
using Microsoft.EntityFrameworkCore;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    [DisallowConcurrentExecution]
    public class DeleteInactiveClientsJob : IJob
    {
        private readonly HospitalityPRO_DbContext _dbContext;

        public DeleteInactiveClientsJob(HospitalityPRO_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var sevenMonthsAgo = DateTime.UtcNow.AddMonths(-7);

            var inactiveClients = await _dbContext.Clients
              .Where(c => c.LastLogin < sevenMonthsAgo && c.Role != "Admin")
                .ToListAsync(context.CancellationToken);

            foreach (var client in inactiveClients)
            {
                _dbContext.Clients.Remove(client);
            }

            await _dbContext.SaveChangesAsync(context.CancellationToken);
        }
    }
}
