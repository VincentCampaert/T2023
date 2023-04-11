using WebDev.Domain.Model.Game;

namespace WebDev.Data.Interfaces
{
    public interface IGameRepository
    {
        public Task<int> CreateGameAsync(HostGameModel model, CancellationToken cancellationToken = default);
        public Task<GameModel> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task PlayMoveAsync(PlayMoveModel model, CancellationToken cancellationToken = default);
    }
}
