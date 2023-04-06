using AutoMapper;
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
        private readonly IMapper _mapper;

        public async Task<int> CreateGameAsync(HostGameModel model, CancellationToken cancellationToken)
        {
            try
            {
                using (var ctx = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
                {
                    var entity = new Game
                    {
                        Name = model.Name,
                        Player1Id = model.HostId,
                        Private = model.PrivateGame,
                        TurnLength = model.TurnLength,
                        EndDate = model.EndDate
                    };

                    var game = ctx.Games.Add(entity);
                    await ctx.SaveChangesAsync(cancellationToken);
                    return entity.Id;
                }
            }
            catch (DbException ex)
            {
                return 0;
            }
        }

        public async Task<GameModel> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                return null;
            }

            using (var ctx = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                return _mapper.Map<GameModel>(await ctx.Games.FirstOrDefaultAsync(x => x.Id == id, cancellationToken));
            }
        }

        public GameRepository(IDbContextFactory<ReversiContext> dbContextFactory,
            IMapper mapper)
        {
            _dbContextFactory = dbContextFactory;
            _mapper = mapper;
        }
    }
}
