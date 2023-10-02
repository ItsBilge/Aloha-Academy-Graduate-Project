using Aloha_Academy_Graduate_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aloha_Academy_Graduate_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly SqlContext _context;

        public LocationController()
        {
            _context = new SqlContext();
        }

        [HttpGet]
        public IActionResult GetLocation () 
        {
            var locations = _context.Locations.ToList();

            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetLocationById(int id)
        {
            if (_context.Locations == null)
            {
                return NotFound();
            }
            var location = await _context.Activities.Where(q => q.LocationId == id).ToListAsync();

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }
    }
}
