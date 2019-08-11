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
    public class PeopleController : ControllerBase
    {
        private readonly BugtrackerRepository bugtrackerRepository;

        public PeopleController(BugtrackerRepository bugtrackerRepository)
        {
            this.bugtrackerRepository = bugtrackerRepository ?? throw new ArgumentNullException(nameof(bugtrackerRepository));
        }

        // GET: api/People
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return bugtrackerRepository.GetAllPeople();
        }

        // GET: api/People/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            return Ok(this.bugtrackerRepository.GetPersonById(id));
        }

        // POST: api/People
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            this.bugtrackerRepository.AddPerson(person);
            this.bugtrackerRepository.SaveChanges();

            return this.CreatedAtRoute("Get", new { id = person.Id }, person);
        }        

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            this.bugtrackerRepository.DeletePerson(id);
            return Ok();
        }        
    }
}
