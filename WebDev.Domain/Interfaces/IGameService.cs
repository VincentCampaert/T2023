using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Domain.Model.Game;

namespace WebDev.Domain.Interfaces
{
    public interface IGameService
    {
        public Task<int> HostGameAsync(HostGameModel model, CancellationToken cancellationToken = default);
        public Task<bool> PlayMoveAsync(PlayMoveModel model, CancellationToken cancellationToken = default);
    }
}
