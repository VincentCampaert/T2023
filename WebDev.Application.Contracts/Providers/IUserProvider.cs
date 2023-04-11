using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Domain.Model.Application;

namespace WebDev.Application.Contracts.Providers
{
    public interface IUserProvider
    {
        public Task<User> VerifyLoginAsync(string email, string password, CancellationToken cancellationToken = default);
        public Task<bool> CreateUserAsync(User toCreate, string displayName, CancellationToken cancellationToken = default);
    }
}
