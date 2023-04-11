using WebDev.Data.Interfaces;
using WebDev.Domain.Interfaces;
using WebDev.Domain.Model.Game;

namespace WebDev.Domain.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public async Task<int> HostGameAsync(HostGameModel model, CancellationToken cancellationToken)
        {
            if (model.Name == null)
            {
                var randomWord = "TEST";
                var randomSequence = 1234;

                model.Name = $"{randomWord}#{randomSequence}";
            }

            if (model.EndDate == default)
            {
                model.EndDate = DateTime.Now.AddDays(7);
            }

            if (model.HostId == 0)
            {
                // Current logged in userId
                model.HostId = 1;
            }

            return await _gameRepository.CreateGameAsync(model, cancellationToken);
        }

        public async Task<bool> PlayMoveAsync(PlayMoveModel model, CancellationToken cancellationToken = default)
        {
            if (model.CoordX < 0 || model.CoordX > 7 ||
                model.CoordY < 0 || model.CoordY > 7 ||
                model.PlayerId == 0)
            {
                return false;
            }

            return true;
        }

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
    }
}
