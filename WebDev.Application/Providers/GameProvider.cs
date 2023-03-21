using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Application.Contracts.Providers;
using WebDev.Domain.Interfaces;
using WebDev.Domain.Model.Game;

namespace WebDev.Application.Providers
{
    public class GameProvider : IGameProvider
    {
        private readonly IGameService _gameService;

        public async Task<bool> CloseGameAsync(int gameId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> HostGameAsync(HostGameModel model, CancellationToken cancellationToken)
        {
            var result = await _gameService.HostGameAsync(model, cancellationToken);
            return result;
        }

        public async Task<bool> JoinGameAsync(int gameId, int playerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LeaveGameAsync(int gameId, int playerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public GameProvider(IGameService gameService)
        {
            _gameService = gameService;
        }
    }
}
