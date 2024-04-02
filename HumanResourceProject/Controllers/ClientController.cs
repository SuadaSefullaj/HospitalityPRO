using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HumanResourceProject.Models;
using Microsoft.AspNetCore.Authorization;
using DAL.Contracts;

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
        [Authorize(Roles = "Admin")]
        public  ActionResult<IEnumerable<Client>> GetAllClients()
        {
            try
            {
                var clients =  _clientRepository.GetAllClients();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex); 
            }
        }

        [HttpGet("{id}")]
        public  ActionResult<Client> GetClientById(int id)
        {
            try
            {
                var client =  _clientRepository.GetClientById(id);
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
