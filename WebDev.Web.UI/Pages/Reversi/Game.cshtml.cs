using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebDev.Application.Contracts.Providers;
using WebDev.Domain.Model.Game;
using WebDev.Web.Common.ViewModels;

namespace WebDev.Web.UI.Pages.Reversi
{
    public class GameModel : PageModel
    {
        private readonly IGameProvider _gameProvider;
        private readonly IMapper _mapper;

        [BindProperty] public GameViewModel? GameViewModel { get; set; }
        public void OnGet(int id)
        {

        }

        public async Task<IActionResult> OnGetGameDetailsAsync([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            if (GameViewModel == null)
            {
                GameViewModel = _mapper.Map<GameViewModel>(await _gameProvider.GetGameAsync(id, cancellationToken));
            }

            return new OkObjectResult(GameViewModel);
        }

        public async Task<IActionResult> OnPostPlayMoveAsync(PlayMoveViewModel model, CancellationToken cancellationToken = default)
        {
            if (model.PlayerId == 0)
            {
                return new OkObjectResult(false);
            }

            var result = await _gameProvider.PlayMoveAsync(_mapper.Map<PlayMoveModel>(model), cancellationToken);
            return new OkObjectResult(result);
        }

        public GameModel(IGameProvider gameProvider,
            IMapper mapper)
        {
            _gameProvider = gameProvider;
            _mapper = mapper;
        }
    }
}
