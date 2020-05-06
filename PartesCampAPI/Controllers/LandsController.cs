using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartesCampAPI.Models;
using PartesCampAPI.data;

namespace PartesCampAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandsController : ControllerBase
    {
        private readonly PartesCampContext _context;

        public LandsController(PartesCampContext context)
        {
            _context = context;
        }

        // GET: api/Lands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Land>>> GetLands()
        {
            return await _context.Lands.ToListAsync();
        }

        // GET: api/Lands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Land>> GetLand(int id)
        {
            var land = await _context.Lands.FindAsync(id);

            if (land == null)
            {
                return NotFound();
            }

            return land;
        }

        // PUT: api/Lands/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLand(int id, Land land)
        {
            if (id != land.ID)
            {
                return BadRequest();
            }

            _context.Entry(land).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LandExists(id))
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

        // POST: api/Lands
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Land>> PostLand(Land land)
        {
            _context.Lands.Add(land);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLand", new { id = land.ID }, land);
        }

        // DELETE: api/Lands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Land>> DeleteLand(int id)
        {
            var land = await _context.Lands.FindAsync(id);
            if (land == null)
            {
                return NotFound();
            }

            _context.Lands.Remove(land);
            await _context.SaveChangesAsync();

            return land;
        }

        private bool LandExists(int id)
        {
            return _context.Lands.Any(e => e.ID == id);
        }
    }
}
