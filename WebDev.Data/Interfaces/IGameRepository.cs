using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Domain.Model.Game;

namespace WebDev.Data.Interfaces
{
    public interface IGameRepository
    {
        public Task<bool> CreateGame(HostGameModel model, CancellationToken cancellationToken = default);
    }
}
