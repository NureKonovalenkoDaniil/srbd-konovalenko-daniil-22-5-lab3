using CardiologyApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardiologyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly CardiologyDepartmentContext _context;

        public DoctorsController(CardiologyDepartmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = await _context.Doctors
                .Include(d => d.Position)
                .ToListAsync();

            return doctors;
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDoctors), new { id = doctor.DoctorId }, doctor);
        }
        [HttpPost("delete-low-ward-beds")]
        public async Task<IActionResult> DeleteDoctorsWithLowWardBeds(int minBeds)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC DeleteDoctorsWithLowWardBeds {minBeds}");
            return NoContent();
        }
    }
}
