using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebDev.Application.Contracts.Providers;
using WebDev.Domain.Model.Game;
using WebDev.Web.Common.ViewModels;

namespace WebApplicatieWebdev.Pages.Reversi
{
    public class DashboardModel : PageModel
    {
        private readonly IGameProvider _gameProvider;
        private readonly IMapper _mapper;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostHostGameAsync(HostGameViewModel hostGameViewModel, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var model = _mapper.Map<HostGameModel>(hostGameViewModel);
            var result = await _gameProvider.HostGameAsync(model, cancellationToken);

            if (result == 0) // Failed to host game
            {
                ModelState.AddModelError("Host Game", "Something went wrong.");
                return Page();
            }

            // Redirect naar lobby
            return Redirect($"/Reversi/Game/{result}");
        }

        public DashboardModel(IGameProvider gameProvider,
            IMapper mapper)
        {
            _gameProvider = gameProvider;
            _mapper = mapper;
        }   
    }
}
