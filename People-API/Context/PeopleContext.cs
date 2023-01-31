using Microsoft.EntityFrameworkCore;
using People_API.Entities;

namespace People_API.Context
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<Person> People { get; set; }
    }
}
