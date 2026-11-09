
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SanzoWada.Api.Data;

namespace SanzoWada.Api.Controllers;

[ApiController]
[Route("api/health")]
public class DatabaseHealthController : ControllerBase
{
    private readonly AppDbContext _context;

    public DatabaseHealthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("database")]
    public async Task<IActionResult> CheckDatabase()
    {
        var canConnect = await _context.Database.CanConnectAsync();

        if (canConnect)
        {
            return Ok(new
            {
                status = "Healthy",
                database = "Connected"
            });
        }

        return StatusCode(503, new
        {
            status = "Unhealthy",
            database = "Disconnected"
        });
    }
}
