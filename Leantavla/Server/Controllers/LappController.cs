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
    public class LappController : ControllerBase
    {
        private readonly LenatavlaContext _context;
        public LappController(LenatavlaContext context)
        {
            _context = context;
        }
        // GET: api/<LappController>
        [HttpGet]
        public IEnumerable<Lapp> Get()
        {
            return _context.Lappar.ToList();
        }

        // GET api/<LappController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LappController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LappController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LappController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
