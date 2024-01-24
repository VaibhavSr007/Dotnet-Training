using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using firstapi.Models;
using firstapi.Repository;

namespace firstapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {

        private readonly IFlightServ<VsFlight> _flserv;
        public FlightController(IFlightServ<VsFlight> flserv){
            _flserv = flserv;
        }

        // GET: api/Flight
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VsFlight>>> GetVsFlights()
        {
            return _flserv.GetAllFlights();
        }

        // GET: api/Flight/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VsFlight>> GetVsFlight(int id)
        {
            var f = _flserv.GetFlightById(id);

            if (f == null)
            {
                return NotFound();
            }

            return f;
        }


        // GET: api/Flight/search?id=src-dest
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<VsFlight>>> GetVsFlight(string id)
        {   

            var vsFlight = _flserv.GetFlightsBySrcDest(id);

            if (vsFlight == null)
            {
                return NotFound();
            }

            return vsFlight;
        }

        // PUT: api/Flight/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVsFlight(int id, VsFlight vsFlight)
        {
            if (id != vsFlight.FlightId)
            {
                return BadRequest();
            }

            _flserv.UpdateFlight(id,vsFlight);

            return NoContent();
        }

        // POST: api/Flight
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VsFlight>> PostVsFlight(VsFlight vsFlight)
        {
            _flserv.AddFlight(vsFlight);

            return CreatedAtAction("GetVsFlight", new { id = vsFlight.FlightId }, vsFlight);
        }

        // DELETE: api/Flight/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVsFlight(int id)
        {
            var vsFlight = _flserv.GetFlightById(id);
            if (vsFlight == null)
            {
                return NotFound();
            }

            _flserv.DeleteFlight(id);

            return NoContent();
        }

    }
}
