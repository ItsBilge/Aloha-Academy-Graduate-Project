using Aloha_Academy_Graduate_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace Aloha_Academy_Graduate_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventSearchController : ControllerBase
    {
        private readonly SqlContext _context;

        public EventSearchController()
        {
            _context = new SqlContext();
        }

        [HttpGet("{query}")]
        public IActionResult SearchEvents(string query)
        {
            var events = _context.Activities.Where(e => e.Title.Contains(query)).ToList();
            return Ok(events);
        }
    }
}
