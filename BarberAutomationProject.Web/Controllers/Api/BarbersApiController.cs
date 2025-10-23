using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarberAutomationProject.Web.Data;
using Microsoft.AspNetCore.Authorization;

namespace BarberAutomationProject.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Uses JWT automatically
    public class BarbersApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BarbersApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BarbersApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetBarbers()
        {
            var barbers = await _context.Barbers
                .Include(b => b.Services)
                .Include(b => b.Availabilities)
                .Select(b => new
                {
                    b.Id,
                    b.Name,
                    b.PhoneNumber,
                    Services = b.Services.Select(s => new
                    {
                        s.Id,
                        s.Name,
                        s.Price,
                        s.DurationInMinutes
                    }),
                    Availabilities = b.Availabilities.Select(a => new
                    {
                        a.Id,
                        a.AvailableFrom,
                        a.AvailableTo,
                        a.IsBooked,
                        DayOfWeek = a.AvailableFrom.DayOfWeek.ToString(),
                        TimeSlot = a.AvailableFrom.ToString("HH:mm") + " - " + a.AvailableTo.ToString("HH:mm")
                    }).OrderBy(a => a.AvailableFrom)
                })
                .ToListAsync();

            return Ok(barbers);
        }

        // GET: api/BarbersApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetBarber(int id)
        {
            var barber = await _context.Barbers
                .Include(b => b.Services)
                .Include(b => b.Availabilities)
                .Where(b => b.Id == id)
                .Select(b => new
                {
                    b.Id,
                    b.Name,
                    b.PhoneNumber,
                    Services = b.Services.Select(s => new
                    {
                        s.Id,
                        s.Name,
                        s.Price,
                        s.DurationInMinutes
                    }),
                    Availabilities = b.Availabilities.Select(a => new
                    {
                        a.Id,
                        a.AvailableFrom,
                        a.AvailableTo,
                        a.IsBooked,
                        DayOfWeek = a.AvailableFrom.DayOfWeek.ToString(),
                        TimeSlot = a.AvailableFrom.ToString("HH:mm") + " - " + a.AvailableTo.ToString("HH:mm")
                    }).OrderBy(a => a.AvailableFrom)
                })
                .FirstOrDefaultAsync();

            if (barber == null)
            {
                return NotFound();
            }

            return Ok(barber);
        }

        // GET: api/BarbersApi/5/availabilities?date=2025-10-23
        [HttpGet("{id}/availabilities")]
        public async Task<ActionResult<IEnumerable<object>>> GetBarberAvailabilities(int id, [FromQuery] DateTime? date = null)
        {
            var targetDate = date ?? DateTime.Today;

            var availabilities = await _context.BarberAvailabilities
                .Where(ba => ba.BarberId == id &&
                             ba.AvailableFrom.Date == targetDate.Date &&
                             !ba.IsBooked)
                .Select(ba => new
                {
                    ba.Id,
                    ba.AvailableFrom,
                    ba.AvailableTo,
                    ba.IsBooked,
                    TimeSlot = ba.AvailableFrom.ToString("HH:mm") + " - " + ba.AvailableTo.ToString("HH:mm")
                })
                .OrderBy(ba => ba.AvailableFrom)
                .ToListAsync();

            return Ok(availabilities);
        }
    }
}