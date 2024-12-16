using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardiologyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreparationsController : ControllerBase
    {
        private readonly CardiologyDepartmentContext _context;

        public PreparationsController(CardiologyDepartmentContext context)
        {
            _context = context;
        }

        [HttpGet("less-than-avg-price")]
        public async Task<ActionResult<int>> GetPreparationsLessThanAvgPrice()
        {
            var connection = _context.Database.GetDbConnection();
            await connection.OpenAsync();

            try
            {
                using var command = connection.CreateCommand();
                command.CommandText = "SELECT dbo.PreparationsLessThanAvgPrice()";
                var result = await command.ExecuteScalarAsync();

                int count = result != null ? Convert.ToInt32(result) : 0;
                return Ok(count);
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

        [HttpGet("cheaper-than/{price}")]
        public async Task<ActionResult<int>> CountPreparationsCheaperThan(decimal price)
        {
            var connection = _context.Database.GetDbConnection();
            await connection.OpenAsync();

            try
            {
                using var command = connection.CreateCommand();
                command.CommandText = $"SELECT dbo.CountPreparationsCheaperThan({price})";
                var result = await command.ExecuteScalarAsync();

                int count = result != null ? Convert.ToInt32(result) : 0;
                return Ok(count);
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

        [HttpGet("largest-usage/{preparationName}")]
        public async Task<IActionResult> GetLargestPreparationUsage(string preparationName)
        {
            var result = await _context.LargestPreparationUsageResults
                .FromSqlInterpolated($"SELECT * FROM dbo.GetLargestPreparationUsage({preparationName})")
                .ToListAsync();

            if (!result.Any())
                return NotFound(new { Message = $"No usage found for preparation {preparationName}." });

            return Ok(result);
        }

    }
}
