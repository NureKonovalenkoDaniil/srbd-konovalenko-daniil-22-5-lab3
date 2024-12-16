using CardiologyApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardiologyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriesController : ControllerBase
    {
        private readonly CardiologyDepartmentContext _context;

        public HistoriesController(CardiologyDepartmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<History>>> GetHistories()
        {
            return await _context.Histories
                .Include(h => h.Patient)
                .Include(h => h.Doctor)
                .Include(h => h.Ward)
                .ToListAsync();
        }
    }
}
