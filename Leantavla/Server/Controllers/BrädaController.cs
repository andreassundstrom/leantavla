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
    public class BrädaController : ControllerBase
    {
        private readonly LeantavlaContext _context;
        public BrädaController(LeantavlaContext context)
        {
            _context = context;
        }


        // GET api/<BrädaController>/5
        [HttpGet("{BrädaId}")]
        public ActionResult<Bräda> Get(int BrädaId)
        {

            var bräda = _context.Bräda
                .Include(p => p.Attributtyper)
                .Include(p => p.Statusar)
                .Include(p => p.Lappar)
                .FirstOrDefault(p => p.BrädaId == BrädaId);
            if(bräda == null)
            {
                return NotFound($"Hittar ingen bräda med Id {BrädaId}");
            }
            return Ok(bräda);
        }

        // POST api/<BrädaController>
        [HttpPost]
        public ActionResult<Bräda> Post([FromBody] Bräda Bräda)
        {
            Bräda.Statusar = new List<Status>
            {
                new Status {Sortering = 1,StatusNamn = "Ny"},
                new Status {Sortering = 1,StatusNamn = "Pågående"},
                new Status {Sortering = 1,StatusNamn = "Avslutad"}
            };

            Bräda.Attributtyper = new List<Attributtyp>
            {
                new Attributtyp{ Attributnamn = "Sammanfattning",Attributbeskrivning = "Kort sammanfattning",Datatyp = Datatyp.StringDatatype},
                new Attributtyp{Attributnamn = "Beskrivning",Attributbeskrivning = "Beskrivning av problemet", Datatyp = Datatyp.StringDatatype},
                new Attributtyp{Attributnamn = "Skapare",Attributbeskrivning = "Vem som skapade lappen",Datatyp = Datatyp.StringDatatype}
            };
            _context.Bräda.Add(Bräda);
            _context.SaveChanges();
            Bräda NyBräda = _context.Bräda
                .Single(p => p.BrädaNamn == Bräda.BrädaNamn);
            NyBräda.Attributtyper = null;
            NyBräda.Statusar = null;
            return Ok(NyBräda);
        }

        // PUT api/<BrädaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BrädaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
