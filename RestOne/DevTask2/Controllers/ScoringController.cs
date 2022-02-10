using Microsoft.AspNetCore.Mvc;
using DevTask2.Utilities;
using DevTask2.Models.Contexts;
using DevTask2.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevTask2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoringController : ControllerBase
    {
        ApplicationContext db;

        public ScoringController(ApplicationContext context)
        {
            db = context;
        }

        // GET api/<ScoringController>/5
        [HttpGet("evaluate")]
        public bool Get()
        {
            return Func.RandBool(40);
        }     
        
        // GET api/<ScoringController>/5
        [HttpGet("evaluate/{id}")]
        public async Task<ActionResult<bool>> Get(int id)
        {
            Application app = await db.applications.FirstOrDefaultAsync(x => x.ApplicationId == id);
            if (app == null)
                return NotFound();
            return new ObjectResult(app.ScoringStatus);
        }

    }
}
