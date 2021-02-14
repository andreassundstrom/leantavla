using Leantavla.Server.Models;
using Leantavla.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Leantavla.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributtypController : ControllerBase
    {
        private readonly LeantavlaContext _context;
        public AttributtypController(LeantavlaContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Attributtyp> Get()
        {
            return _context.Attributtyper.ToList();
        }

        [HttpGet("status")]
        public IEnumerable<Status> GetStatus()
        {
            return _context.Status.ToList();
        }

        // GET api/<AttributtypController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AttributtypController>
        [HttpPost]
        public async Task Post([FromBody] Attributtyp attributtyp)
        {
            _context.Attributtyper.Add(attributtyp);
            await _context.SaveChangesAsync();
        }

        // PUT api/<AttributtypController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AttributtypController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
