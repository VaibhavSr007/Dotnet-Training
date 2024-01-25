using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using firstapi.Models;

namespace firstapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student007Controller : ControllerBase
    {
        private readonly Ace52024Context _context;

        public Student007Controller(Ace52024Context context)
        {
            _context = context;
        }

        // GET: api/Student007
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student007>>> GetStudent007s()
        {
            return await _context.Student007s.ToListAsync();
        }

        // GET: api/Student007/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student007>> GetStudent007(int id)
        {
            var student007 = await _context.Student007s.FindAsync(id);

            if (student007 == null)
            {
                return NotFound();
            }

            return student007;
        }

        // PUT: api/Student007/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent007(int id, Student007 student007)
        {
            if (id != student007.Sid)
            {
                return BadRequest();
            }

            _context.Entry(student007).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Student007Exists(id))
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

        // POST: api/Student007
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student007>> PostStudent007(Student007 student007)
        {
            _context.Student007s.Add(student007);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Student007Exists(student007.Sid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudent007", new { id = student007.Sid }, student007);
        }

        // DELETE: api/Student007/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent007(int id)
        {
            var student007 = await _context.Student007s.FindAsync(id);
            if (student007 == null)
            {
                return NotFound();
            }

            _context.Student007s.Remove(student007);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Student007Exists(int id)
        {
            return _context.Student007s.Any(e => e.Sid == id);
        }
    }
}
