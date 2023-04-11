using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Application.Contracts.Providers;
using WebDev.Data.Interfaces;
using WebDev.Domain.Interfaces;
using WebDev.Domain.Model.Application;

namespace WebDev.Application.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public async Task<User> VerifyLoginAsync(string email, string password, CancellationToken cancellationToken)
        {
            var user = await _userRepository.VerifyLoginAsync(email, password, cancellationToken);

            return _mapper.Map<User>(user);
        }

        public async Task<bool> CreateUserAsync(User toCreate, string displayName, CancellationToken cancellationToken)
        {
            var createUser = _mapper.Map<Data.Models.User>(toCreate);

            return await _userService.CreateUserAsync(createUser, displayName, cancellationToken);
        }

        public UserProvider(IUserRepository userRepository,
            IUserService userService,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _userService = userService;
            _mapper = mapper;
        }
    }
}
