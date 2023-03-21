using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Data.Interfaces;
using WebDev.Domain.Interfaces;
using WebDev.Domain.Models;

namespace WebDev.Domain.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public Task<bool> HostGameAsync(HostGameModel model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
    }
}
