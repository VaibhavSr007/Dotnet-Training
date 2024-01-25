using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using firstapi.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace firstapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly Ace52024Context _context;

        public BookingController(Ace52024Context context)
        {
            _context = context;
        }

        // GET: api/Booking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VsBookingDetail>>> GetVsBookingDetails()
        {
            return await _context.VsBookingDetails.ToListAsync();
        }

        [HttpGet("AllBookings")]
        public async Task<ActionResult<List<VsBookingDetail>>> GetAllVsBookingDetail(int id)
        {   
        
            var vsBookingDetails = await _context.VsBookingDetails.Include(x=>x.Flight).Where(x=>x.CustomerId == id).Select(x=>x).ToListAsync();

            if (vsBookingDetails == null)
            {
                return NotFound();
            }

            var jsonResult  = JsonConvert.SerializeObject(vsBookingDetails, new JsonSerializerSettings{
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting  = Formatting.Indented
            });


            return Content(jsonResult, "application/json");
        }

        // GET: api/Booking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VsBookingDetail>> GetVsBookingDetail(int id)
        {
            var vsBookingDetail = await _context.VsBookingDetails.Include(x=>x.Flight).Where(x=>x.BookingId == id).Select(x=>x).SingleOrDefaultAsync();
            

            if (vsBookingDetail == null)
            {
                return NotFound();
            }

            var jsonResult  = JsonConvert.SerializeObject(vsBookingDetail, new JsonSerializerSettings{
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting  = Formatting.Indented
            });


            return Content(jsonResult, "application/json");
        }

        // PUT: api/Booking/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVsBookingDetail(int id, VsBookingDetail vsBookingDetail)
        {
            if (id != vsBookingDetail.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(vsBookingDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VsBookingDetailExists(id))
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

        // POST: api/Booking
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VsBookingDetail>> PostVsBookingDetail(VsBookingDetail vsBookingDetail)
        {
            _context.VsBookingDetails.Add(vsBookingDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVsBookingDetail", new { id = vsBookingDetail.BookingId }, vsBookingDetail);
        }

        // DELETE: api/Booking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVsBookingDetail(int id)
        {
            var vsBookingDetail = await _context.VsBookingDetails.FindAsync(id);
            if (vsBookingDetail == null)
            {
                return NotFound();
            }

            _context.VsBookingDetails.Remove(vsBookingDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VsBookingDetailExists(int id)
        {
            return _context.VsBookingDetails.Any(e => e.BookingId == id);
        }
    }
}
