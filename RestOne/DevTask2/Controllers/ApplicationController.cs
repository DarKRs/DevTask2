using DevTask2.Models;
using DevTask2.Models.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTask2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        ApplicationContext db;
        ScoringController sc;
        public ApplicationController(ApplicationContext context, ScoringController scoringController)
        {
            db = context;
            sc = scoringController;
            if (!db.applications.Any())
            {
                db.applications.Add(new Application());
                db.applications.Add(new Application());
                db.SaveChanges();
            }
        }

        // Invoke-RestMethod http://localhost/api/application -Method GET
        [HttpGet("status")]
        public async Task<ActionResult<IEnumerable<ApplicationDTO>>> Get()
        {
            return await db.applications.Select(x => (ApplicationDTO)x).ToListAsync();
        }

        // GET api/application/5
        // Invoke-RestMethod http://localhost/api/application/id -Method GET
        [HttpGet("status/{id}")]
        public async Task<ActionResult<Application>> Get(int id)
        {
            Application app = await db.applications.FirstOrDefaultAsync(x => x.ApplicationId == id);
            if (app == null)
                return NotFound();
            return new ObjectResult((ApplicationDTO)app);
        }

        // POST api/application
        //Invoke-RestMethod http://localhost/api/application/ -Method POST -Body (@{AppNum = "Test";....;...} | ConvertTo-Json) -ContentType "application/json; charset=utf-8"
        [HttpPost("create")]
        public async Task<ActionResult<Application>> Post(Application app)
        {
            if (app == null)
            {
                return BadRequest();
            }

            db.applications.Add(app);
            await db.SaveChangesAsync();
            app.SetScoring(sc.Get(), DateTime.Today);
            db.Update(app);
            await db.SaveChangesAsync();
            return Ok(app);
        }

        // PUT api/application/
        //Invoke-RestMethod http://localhost/api/application/ -Method PUT -Body (@{id = 3; AppNum = "TestEdited";....;...} | ConvertTo-Json) -ContentType "application/json"
        [HttpPut("edit")]
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

        // DELETE api/application/5
        [HttpDelete("delete/{id}")]
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

