using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Application.Contracts.Providers;
using WebDev.Data.Interfaces;
using WebDev.Domain.Interfaces;
using WebDev.Domain.Model.Game;

namespace WebDev.Application.Providers
{
    public class GameProvider : IGameProvider
    {
        private readonly IGameService _gameService;
        private readonly IGameRepository _gameRepository;

        public async Task<bool> CloseGameAsync(int gameId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<int> HostGameAsync(HostGameModel model, CancellationToken cancellationToken)
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

        public async Task<GameModel> GetGameAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _gameRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<bool> PlayMoveAsync(PlayMoveModel model, CancellationToken cancellationToken = default)
        {
            try
            {
                await _gameRepository.PlayMoveAsync(model, cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public GameProvider(IGameService gameService,
            IGameRepository gameRepository)
        {
            _gameService = gameService;
            _gameRepository = gameRepository;
        }
    }
}
