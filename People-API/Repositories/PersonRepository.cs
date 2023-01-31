using Microsoft.EntityFrameworkCore;
using People_API.Context;
using People_API.Entities;

namespace People_API.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public readonly PeopleContext _context;

        public PersonRepository(PeopleContext context) 
        {
            _context = context;
        }

        public async Task<Person> Create(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
            
            return person;
        }

    
        public async Task<IEnumerable<Person>> FindAll()
        {
           return await _context.People.ToListAsync<Person>();
        }

        public async Task Update(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Person> FindById(int id)
        {
            return await _context.People.FindAsync(id);
        }

        public async Task Delete(int id)
        {
            var PersonDelete = await _context.People.FindAsync(id);
            
            if(PersonDelete != null)
            {
              _context.People.Remove(PersonDelete);
            }

            await _context.SaveChangesAsync();
        }

    }
}
