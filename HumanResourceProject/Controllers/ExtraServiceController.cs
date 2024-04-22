using AutoMapper;
using DTO;
using HumanResourceProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtraServiceController : ControllerBase
    {
        private readonly HospitalityPRO_DbContext _context;
        private readonly IMapper _mapper;

        public ExtraServiceController(HospitalityPRO_DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("getAllExtraService")]
        public ActionResult<IEnumerable<ExtraServiceDTO>> GetExtraServices()
        {
            var extraServices = _context.ExtraServices.ToList();
             return _mapper.Map<List<ExtraServiceDTO>>(extraServices);
         
        }

        [HttpGet("{id}")]
        public ActionResult<ExtraServiceDTO> GetExtraService(int id)
        {
            var extraService = _context.ExtraServices.Find(id);

            if (extraService == null)
            {
                return NotFound();
            }

            return _mapper.Map<ExtraServiceDTO>(extraService);
        }

        [HttpPost("addExtraService")]
        public ActionResult<ExtraService> AddExtraService(ExtraServiceDTO request)
        {
            var extraService = _mapper.Map<ExtraService>(request);

            _context.ExtraServices.Add(extraService);
            _context.SaveChanges();

            return Ok(request);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateExtraService(int id, ExtraServiceDTO request)
        {
            var extraService = _context.ExtraServices.Find(id);

            if (extraService == null)
            {
                return NotFound();
            }

            _mapper.Map(request, extraService);

            _context.SaveChanges();

            return Ok(request);
        }

        [HttpDelete("{id}")]
        public ActionResult<ExtraServiceDTO> DeleteExtraService(int id)
        {
            var extraService = _context.ExtraServices.Find(id);

            if (extraService == null)
            {
                return NotFound();
            }

            _context.ExtraServices.Remove(extraService);
            _context.SaveChanges();

            return Ok("This Extra Service has been deleted!");
        }
    }
}
    
