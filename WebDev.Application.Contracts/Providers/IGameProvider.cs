using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Domain.Model.Game;

namespace WebDev.Application.Contracts.Providers
{
    public interface IGameProvider
    {
        public Task<GameModel> GetGameAsync(int id, CancellationToken cancellationToken = default);
        public Task<int> HostGameAsync(HostGameModel model, CancellationToken cancellationToken = default);
        public Task<bool> CloseGameAsync(int gameId, CancellationToken cancellationToken = default);
        public Task<bool> JoinGameAsync(int gameId, int playerId, CancellationToken cancellationToken = default);
        public Task<bool> LeaveGameAsync(int gameId, int playerId, CancellationToken cancellationToken = default);
        public Task<bool> PlayMoveAsync(PlayMoveModel model, CancellationToken cancellationToken = default);
    }
}
