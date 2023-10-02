using Aloha_Academy_Graduate_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aloha_Academy_Graduate_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly SqlContext _context;

        public CategoriesController()
        {
            _context = new SqlContext();
        }

        // GET: Categories
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityCategory(int id)
        {
            if (_context.Activities == null)
            {
                return NotFound();
            }
            var activity = await _context.Activities.Where(q => q.CategoryId == id).ToListAsync();

            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }
    }
}
