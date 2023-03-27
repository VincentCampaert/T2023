using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebCommon.ViewModels;
using WebDev.Application.Contracts.Providers;
using WebDev.Web.Common.ViewModels;

namespace WebDev.Web.UI.Pages.Reversi
{
    public class HostGameModel : PageModel
    {
        [BindProperty] public HostGameViewModel HostGame { get; set; }

        private readonly IGameProvider _gameProvider;
        private readonly IMapper _mapper;

        public void OnGet()
        {
        }

        public async Task<bool> OnPostAsync(CancellationToken cancellationToken = default)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<Domain.Model.Game.HostGameModel>(HostGame);
                return await _gameProvider.HostGameAsync(model, cancellationToken);
            }

            return false;
        }

        public HostGameModel(IGameProvider gameProvider)
        {
            _gameProvider = gameProvider;
        }
    }
}
