using Microsoft.AspNetCore.Mvc;
using People_API.Repositories;
using People_API.Entities;

namespace People_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository) 
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetPeople() 
        {
            return await _personRepository.FindAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _personRepository.FindById(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson([FromBody] Person person)
        {
            return  await _personRepository.Create(person);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerson(int id)
        {
           var personDelete = await _personRepository.FindById(id);

           if (personDelete == null)
                return NotFound();

           await _personRepository.Delete(personDelete.Id);

           return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> DeletePerson(int id, [FromBody] Person person)
        {

            if (person.Id != id)
                return BadRequest();

            await _personRepository.Update(person);

            return NoContent();
        }


    }
}
