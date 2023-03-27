using WebDev.Data.Interfaces;
using WebDev.Domain.Interfaces;
using WebDev.Domain.Model.Game;

namespace WebDev.Domain.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public async Task<bool> HostGameAsync(HostGameModel model, CancellationToken cancellationToken)
        {
            return await _gameRepository.CreateGameAsync(model, cancellationToken);
        }

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
    }
}
