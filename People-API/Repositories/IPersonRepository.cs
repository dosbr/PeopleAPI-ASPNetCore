using People_API.Entities;

namespace People_API.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> FindAll();
        Task<Person> FindById(int id);
        Task<Person> Create(Person person);
        Task Update(Person person);
        Task Delete(int id);

    }
}
