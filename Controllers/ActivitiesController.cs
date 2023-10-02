using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aloha_Academy_Graduate_Project.Models;

namespace Aloha_Academy_Graduate_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : Controller
    {
        private readonly SqlContext _context;

        public ActivitiesController()
        {
            _context = new SqlContext();
        }

        // GET: api/Activities
        [HttpGet]
        public IActionResult GetActivities()
        {
            var activities = _context.Activities.ToList();

            return Ok(activities);

        }


        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(int id)
        {
            if (_context.Activities == null)
            {
                return NotFound();
            }
            var activity = await _context.Activities.Where(q => q.Id == id).ToListAsync();

            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }
        //[HttpGet("{locationId}")]
        //public async Task<ActionResult<Activity>> GetLocationId(int id)
        //{
        //    if (_context.Activities == null)
        //    {
        //        return NotFound();
        //    }
        //    var activity = await _context.Activities.Where(q => q.LocationId == id).ToListAsync();

        //    if (activity == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(activity);
        //}

        // PUT: api/Activities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivity(int id, Activity activity)
        {
            if (id != activity.Id)
            {
                return BadRequest();
            }

            _context.Entry(activity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Activities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]

        //public async Task<IActionResult> PostActivity(AddImage addImage)
        //{
        //    Activity activity = new Activity();

        //    if(addImage.ImageUrl != null)
        //    {
        //        var extension = Path.GetExtension(addImage.ImageUrl.FileName);
        //        var newImageName = Guid.NewGuid() + extension;
        //        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", newImageName);
        //        var stream = new FileStream(location, FileMode.Create);
        //        addImage.ImageUrl.CopyTo(stream);
        //        activity.ActivityImage = newImageName;
        //    }
        //    activity.Ticketprice = addImage.Ticketprice;
        //    activity.Title = addImage.Title;
        //    activity.Description = addImage.Description;
        //    activity.ActivityDate = addImage.ActivityDate;

        //    _context.Activities.Add(activity);
        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}

        //public async Task<ActionResult<Activity>> PostActivity(Activity activity)
        //{
        //    if (_context.Activities == null)
        //    {
        //        return Problem("Entity set 'SqlContext.Activities'  is null.");
        //    }
        //    _context.Activities.Add(activity);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetActivity", new { id = activity.Id }, activity);
        //}

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            if (_context.Activities == null)
            {
                return NotFound();
            }
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActivityExists(int id)
        {
            return (_context.Activities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
