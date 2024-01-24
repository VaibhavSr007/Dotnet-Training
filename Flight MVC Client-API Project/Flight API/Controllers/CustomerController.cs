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
    public class CustomerController : ControllerBase
    {
        private readonly Ace52024Context _context;

        public CustomerController(Ace52024Context context)
        {
            _context = context;
        }


        [HttpPost("Login")]
        public async Task<ActionResult> Login(VsCustomer c){

            VsCustomer user = await _context.VsCustomers.Where(x=>x.CustomerEmail == c.CustomerEmail && x.CustomerPass == c.CustomerPass).Select(x=>x).SingleOrDefaultAsync();

            if(user != null){
                var cid = user.CustomerId;
                return Ok(cid);
            }
            else{
                return BadRequest("Invalid Username or Password");
            }
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VsCustomer>>> GetVsCustomers()
        {
            return await _context.VsCustomers.ToListAsync();
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VsCustomer>> GetVsCustomer(int id)
        {
            var vsCustomer = await _context.VsCustomers.FindAsync(id);

            if (vsCustomer == null)
            {
                return NotFound();
            }

            return vsCustomer;
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVsCustomer(int id, VsCustomer vsCustomer)
        {
            if (id != vsCustomer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(vsCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VsCustomerExists(id))
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

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VsCustomer>> PostVsCustomer(VsCustomer vsCustomer)
        {
            _context.VsCustomers.Add(vsCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVsCustomer", new { id = vsCustomer.CustomerId }, vsCustomer);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVsCustomer(int id)
        {
            var vsCustomer = await _context.VsCustomers.FindAsync(id);
            if (vsCustomer == null)
            {
                return NotFound();
            }


            var bookingRowDel = await _context.VsBookingDetails.Where(x=>x.CustomerId == id).ToListAsync();
            if(bookingRowDel != null){
                _context.VsBookingDetails.RemoveRange(bookingRowDel);
            }
            _context.VsCustomers.Remove(vsCustomer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VsCustomerExists(int id)
        {
            return _context.VsCustomers.Any(e => e.CustomerId == id);
        }
    }
}
