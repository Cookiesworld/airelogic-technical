using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AireLogic.Api.Entities;
using AireLogic.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AireLogic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugsController : ControllerBase
    {
        private readonly IBugtrackerRepository bugtrackerRepository;

        public BugsController(IBugtrackerRepository bugtrackerRepository)
        {
            this.bugtrackerRepository = bugtrackerRepository ?? throw new ArgumentNullException(nameof(bugtrackerRepository));
        }

        // GET: api/Bugs
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Bug>), StatusCodes.Status200OK)]
        public IEnumerable<Bug> Get()
        {
            return bugtrackerRepository.GetAllBugs();
        }

        // GET: api/Bugs/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Bug), StatusCodes.Status200OK)]
        public IActionResult Get(Guid id)
        {
            return Ok(this.bugtrackerRepository.GetBugById(id));
        }

        // POST: api/Bugs
        [HttpPost]
        public IActionResult Post([FromBody] Bug bug)
        {
            if (bug == null)
            {
                throw new ArgumentNullException(nameof(bug));
            }

            this.bugtrackerRepository.AddBug(bug);
            this.bugtrackerRepository.SaveChanges();

            return this.CreatedAtRoute("Get", new { id = bug.Id }, bug);
        }

        // DELETE: api/Bugs/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            this.bugtrackerRepository.DeleteBug(id);
            return Ok();
        }        
    }
}
