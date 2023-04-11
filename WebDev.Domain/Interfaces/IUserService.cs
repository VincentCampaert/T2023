using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Data.Models;

namespace WebDev.Domain.Interfaces
{
    public interface IUserService
    {
        public Task<bool> CreateUserAsync(User user, string displayName, CancellationToken cancellationToken = default);
    }
}
