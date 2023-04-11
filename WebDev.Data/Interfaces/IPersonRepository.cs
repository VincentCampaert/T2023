using WebDev.Data.Models;

namespace WebDev.Data.Interfaces
{
    public interface IPersonRepository
    {
        public Task<Person> GetPersonByIdAsync(int id, CancellationToken cancellationToken = default);

        public Task<Person> CreatePersonAsync(Person person, CancellationToken cancellationToken = default);
    }
}
