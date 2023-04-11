using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Application.Contracts.Providers;
using WebDev.Data.Interfaces;
using WebDev.Domain.Model.Game;

namespace WebDev.Application.Providers
{
    public class PersonProvider : IPersonProvider
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public async Task<Person> GetPersonByIdAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _personRepository.GetPersonByIdAsync(id, cancellationToken);

            if (result != null)
            {
                return _mapper.Map<Person>(result);
            }
            else
            {
                return null;
            }
        }

        public PersonProvider(IPersonRepository personRepository,
            IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }   
    }
}
