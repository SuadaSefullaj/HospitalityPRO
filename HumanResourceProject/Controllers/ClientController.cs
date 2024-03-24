using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HumanResourceProject.Models;
using DAL.ClientRepository;

namespace HumanResourceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet("getAllClients")] 
        public async Task<ActionResult<IEnumerable<Client>>> GetAllClients()
        {
            try
            {
                var clients = await _clientRepository.GetAllClientsAsync();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex); 
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClientById(int id)
        {
            try
            {
                var client = await _clientRepository.GetClientByIdAsync(id);
                if (client == null)
                {
                    return NotFound(); 
                }
                return Ok(client);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex); 
            }
        }
    }
}
