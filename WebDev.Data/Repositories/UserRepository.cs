using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDev.Data.EntityFramework;
using WebDev.Data.Interfaces;
using WebDev.Data.Models;

namespace WebDev.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<ReversiContext> _dbContextFactory;

        public async Task<User> GetUserByIdAsync(int id, CancellationToken cancellationToken)
        {
            using (var ctx = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                return await ctx.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            }
        }

        public async Task<User> VerifyLoginAsync(string email, string password, CancellationToken cancellationToken, ReversiContext? ctx)
        {
            if (email.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                return null;
            }

            if (ctx == null)
            {
                using (ctx = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
                {
                    return await VerifyLogin(email, password, ctx, cancellationToken);
                }
            } else
            {
                return await VerifyLogin(email, password, ctx, cancellationToken);
            }
            
        }

        private async Task<User> VerifyLogin(string email, string password, ReversiContext ctx, CancellationToken cancellationToken = default)
        {
            var user = await ctx.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

            if (user == null)
            {
                return null;
            }

            if (password == user.Password)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<User> CreateUserAsync(User user, int? personId, CancellationToken cancellationToken)
        {
            if (user == null)
            {
                return null;
            }

            if (personId.HasValue)
            {
                user.PersonId = personId.Value;
            }

            using (var ctx = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var entity = ctx.Add(user);
                await ctx.SaveChangesAsync(cancellationToken);
                return entity.Entity;
            }
        }

        public async Task<bool> CheckExistUserAsync(string email, string username, CancellationToken cancellationToken)
        {
            using (var ctx = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var result = await ctx.Users.Where(x => x.Email == email || x.Username == username).CountAsync(cancellationToken);

                return result > 0;
            }
        }

        public UserRepository(IDbContextFactory<ReversiContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
    }
}
