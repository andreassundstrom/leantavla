using Leantavla.Server.Models;
using Leantavla.Shared;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Lapp> Get()
        {
            return _context.Lappar
                .Include(p => p.Status)
                .Include(p => p.Attribut)
                    .ThenInclude(p => p.Attributtyp).ToList();
        }

        // GET api/<LappController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LappController>
        [HttpPost]
        public async Task<StatusCodeResult> Post([FromBody] Lapp lapp)
        {
            foreach(var attribute in lapp.Attribut)
            {
                attribute.AttributtypId = attribute.Attributtyp.AttributtypId;
                attribute.Attributtyp = null;
            }
            lapp.StatusId = 1;
            _context.Lappar.Add(lapp);
            if (await _context.SaveChangesAsync() > 0)
            {
                return Ok();
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
