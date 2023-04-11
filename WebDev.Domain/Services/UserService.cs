using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Data.Interfaces;
using WebDev.Data.Models;
using WebDev.Domain.Interfaces;

namespace WebDev.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;

        public async Task<bool> CreateUserAsync(User userEntity, string displayName, CancellationToken cancellationToken = default)
        {
            if (await _userRepository.CheckExistUserAsync(userEntity.Email, userEntity.Username, cancellationToken))
            {
                return false;
            }

            var personEntity = new Person
            {
                DisplayName = displayName,
            };

            var person = await _personRepository.CreatePersonAsync(personEntity, cancellationToken);

            var user = await _userRepository.CreateUserAsync(userEntity, person.Id, cancellationToken);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        public UserService(IUserRepository userRepository,
            IPersonRepository personRepository)
        {
            _userRepository = userRepository;
            _personRepository = personRepository;
        }
    }
}
