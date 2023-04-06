using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebDev.Application.Contracts.Providers;
using WebDev.Web.Common.ViewModels;

namespace WebDev.Web.UI.Pages.Reversi
{
    public class GameModel : PageModel
    {
        private readonly IGameProvider _gameProvider;
        private readonly IMapper _mapper;

        [BindProperty] public GameViewModel? GameViewModel { get; set; }

        public async Task<IActionResult> GetGameDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            if (GameViewModel == null)
            {
                GameViewModel = _mapper.Map<GameViewModel>(await _gameProvider.GetGameAsync(id, cancellationToken));
            }

            return OkObjectResult(GameViewModel);
        }

        public async Task<IActionResult> PostPlayMoveAsync(PlayMoveViewModel model, CancellationToken cancellationToken = default)
        {
            if (model.PlayerId == 0)
            {

            }
        }

        public GameModel(IGameProvider gameProvider,
            IMapper mapper)
        {
            _gameProvider = gameProvider;
            _mapper = mapper;
        }
    }
}
