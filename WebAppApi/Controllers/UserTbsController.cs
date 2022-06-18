using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppApi.Data;
using WebAppApi.Models;

namespace WebAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTbsController : ControllerBase
    {
        private readonly my_brandContext _context;

        public UserTbsController(my_brandContext context)
        {
            _context = context;
        }

        // GET: api/UserTbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTb>>> GetUserTbs()
        {
          if (_context.UserTbs == null)
          {
              return NotFound();
          }
            return await _context.UserTbs.ToListAsync();
        }

        // GET: api/UserTbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTb>> GetUserTb(int id)
        {
          if (_context.UserTbs == null)
          {
              return NotFound();
          }
            var userTb = await _context.UserTbs.FindAsync(id);

            if (userTb == null)
            {
                return NotFound();
            }

            return userTb;
        }

        // PUT: api/UserTbs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTb(int id, UserTb userTb)
        {
            if (id != userTb.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTbExists(id))
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

        // POST: api/UserTbs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserTb>> PostUserTb(UserTb userTb)
        {
          if (_context.UserTbs == null)
          {
              return Problem("Entity set 'my_brandContext.UserTbs'  is null.");
          }
            _context.UserTbs.Add(userTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserTbExists(userTb.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserTb", new { id = userTb.UserId }, userTb);
        }

        // DELETE: api/UserTbs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserTb(int id)
        {
            if (_context.UserTbs == null)
            {
                return NotFound();
            }
            var userTb = await _context.UserTbs.FindAsync(id);
            if (userTb == null)
            {
                return NotFound();
            }

            _context.UserTbs.Remove(userTb);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserTbExists(int id)
        {
            return (_context.UserTbs?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
