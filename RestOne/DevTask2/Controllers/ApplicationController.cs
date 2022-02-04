using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTask2.Models.Contexts;
using DevTask2.Models;
using Microsoft.EntityFrameworkCore;

namespace DevTask2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        ApplicationContext db;
        public ApplicationController(ApplicationContext context)
        {
            db = context;
            if (!db.applications.Any())
            {
                db.applications.Add(new Application());
                db.applications.Add(new Application());
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> Get()
        {
            return await db.applications.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> Get(int id)
        {
            Application app= await db.applications.FirstOrDefaultAsync(x => x.ApplicationId == id);
            if (app == null)
                return NotFound();
            return new ObjectResult(app);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Application>> Post(Application app)
        {
            if (app == null)
            {
                return BadRequest();
            }

            db.applications.Add(app);
            await db.SaveChangesAsync();
            return Ok(app);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Application>> Put(Application app)
        {
            if (app == null)
            {
                return BadRequest();
            }
            if (!db.applications.Any(x => x.ApplicationId == app.ApplicationId))
            {
                return NotFound();
            }

            db.Update(app);
            await db.SaveChangesAsync();
            return Ok(app);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Application>> Delete(int id)
        {
            Application app = db.applications.FirstOrDefault(x => x.ApplicationId == id);
            if (app == null)
            {
                return NotFound();
            }
            db.applications.Remove(app);
            await db.SaveChangesAsync();
            return Ok(app);
        }
    }
}

