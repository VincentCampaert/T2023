using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Domain.Model.Game;

namespace WebDev.Application.Contracts.Providers
{
    public interface IPersonProvider
    {
        public Task<Person> GetPersonByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
