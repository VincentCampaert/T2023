using WebDev.Domain.Model.Game;

namespace WebDev.Data.Interfaces
{
    public interface IGameRepository
    {
        public Task<bool> CreateGameAsync(HostGameModel model, CancellationToken cancellationToken = default);
    }
}
