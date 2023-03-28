using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Data.EntityFramework;
using WebDev.Data.Interfaces;
using WebDev.Data.Models;
using WebDev.Domain.Model.Game;

namespace WebDev.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly IDbContextFactory<ReversiContext> _dbContextFactory;

        public async Task<bool> CreateGameAsync(HostGameModel model, CancellationToken cancellationToken)
        {
            try
            {
                using (var ctx = _dbContextFactory.CreateDbContext())
                {
                    var entity = new Game
                    {
                        Name = model.Name,
                        Player1Id = model.HostId,
                        Private = model.PrivateGame,
                        TurnLength = model.TurnLength,
                        EndDate = model.EndDate
                    };

                    ctx.Games.Add(entity);
                    await ctx.SaveChangesAsync(cancellationToken);
                    return true;
                }
            }
            catch (DbException ex)
            {
                return false;
            }
        }

        public GameRepository(IDbContextFactory<ReversiContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
    }
}
