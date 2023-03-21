using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Data.Interfaces;
using WebDev.Domain.Model.Game;

namespace WebDev.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        public Task<bool> CreateGame(HostGameModel model, CancellationToken cancellationToken)
        {
            // EF Core Magic
        }
    }
}
