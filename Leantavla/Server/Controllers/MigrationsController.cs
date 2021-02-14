using Leantavla.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leantavla.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MigrationsController : ControllerBase
    {
        private readonly LeantavlaContext _lenatavlaContext;
        public MigrationsController(LeantavlaContext lenatavlaContext)
        {
            _lenatavlaContext = lenatavlaContext;
        }

        [HttpGet]
        public void MigrateDatabase()
        {
            _lenatavlaContext.Database.Migrate();
        }
    }
}
