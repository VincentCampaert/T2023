using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Data.EntityFramework;
using WebDev.Data.Models;

namespace WebDev.Data.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUserByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task<User> VerifyLoginAsync(string email, string password, CancellationToken cancellationToken = default, ReversiContext? ctx = null);
        public Task<User> CreateUserAsync(User user, int? personId = null, CancellationToken cancellationToken = default);
        public Task<bool> CheckExistUserAsync(string email, string displayName, CancellationToken cancellationToken = default);
    }
}
