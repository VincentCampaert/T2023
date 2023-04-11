using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Data.EntityFramework;
using WebDev.Data.Interfaces;
using WebDev.Data.Models;

namespace WebDev.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDbContextFactory<ReversiContext> _dbContextFactory; 

        public async Task<Person> GetPersonByIdAsync(int id, CancellationToken cancellationToken)
        {
            using (var ctx = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                return await ctx.Persons.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            }
        }

        public async Task<Person> CreatePersonAsync(Person person, CancellationToken cancellationToken = default)
        {
            if (person == null)
            {
                return null;
            }

            using (var ctx = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var entity = ctx.Persons.Add(person);
                await ctx.SaveChangesAsync(cancellationToken);
                return entity.Entity;
            }
        }

        public PersonRepository(IDbContextFactory<ReversiContext> dbContextFactory)
        {

        }
    }
}
