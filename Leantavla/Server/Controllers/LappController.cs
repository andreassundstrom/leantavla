using Leantavla.Server.Hubs;
using Leantavla.Server.Models;
using Leantavla.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Leantavla.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LappController : ControllerBase
    {
        private readonly LeantavlaContext _context;
        public LappController(LeantavlaContext context)
        {
            _context = context;
        }
        // GET: api/<LappController>
        [HttpGet]
        public IEnumerable<Lapp> GetBoardNotes(int BrädaId)
        {
            return _context.Lappar
                .Where(p => p.BrädaId == BrädaId)
                .Include(p => p.Status)
                .Include(p => p.Attribut)
                    .ThenInclude(p => p.Attributtyp).ToList();
        }

        // GET api/<LappController>/5
        [HttpGet("{id}")]
        public Lapp Get(int id)
        {
            return _context.Lappar
                .Include(p => p.Status)
                .Include(p => p.Attribut)
                    .ThenInclude(p => p.Attributtyp)
                    .Where(p => p.LappId == id).FirstOrDefault();
        }

        // POST api/<LappController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Lapp lapp)
        {
            
            foreach(var attribute in lapp.Attribut)
            {
                attribute.AttributtypId = attribute.Attributtyp.AttributtypId;
                attribute.Attributtyp = null;
            }
            lapp.StatusId = _context.Status
                .Where(p => p.BrädaId == lapp.BrädaId)
                .OrderBy(p => p.StatusId)
                .First().StatusId;

            _context.Lappar.Add(lapp);

            if (await _context.SaveChangesAsync() > 0)
            {              
                return Ok(lapp.LappId);
            }
            else return StatusCode(500);
            
        }

        // PUT api/<LappController>/5
        [HttpPut]
        public async Task<StatusCodeResult> Put([FromBody] Lapp lapp)
        {
            foreach (var attribute in lapp.Attribut)
            {
                attribute.AttributtypId = attribute.Attributtyp.AttributtypId;
                attribute.Attributtyp = null;
            }
            lapp.Status = null;
            _context.Lappar.Update(lapp);
            if (await _context.SaveChangesAsync() > 0)
            {
                return Ok();
            }
            else return StatusCode(500);

        }

        // DELETE api/<LappController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
