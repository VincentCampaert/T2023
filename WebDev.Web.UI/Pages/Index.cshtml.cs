using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using WebDev.Application.Contracts.Providers;
using WebDev.Domain.Model.Application;
using WebDev.Web.Common.ViewModels;

namespace WebApplicatieWebdev.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserProvider _userProvider;
        private readonly IPersonProvider _personProvider;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        [BindProperty] LoginViewModel LoginForm { get; set; }

        public IndexModel(ILogger<IndexModel> logger,
            IUserProvider userProvider,
            IPersonProvider personProvider,
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _logger = logger;
            _userProvider = userProvider;
            _personProvider = personProvider;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnPostLoginAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            if (email.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                ModelState.AddModelError("missingFields", "Email and/or Password fields are not filled in.");
                return Page();
            }

            var result = await _userProvider.VerifyLoginAsync(email, password, cancellationToken);

            if (result == null)
            {
                ModelState.AddModelError("invalidInput", "Email or Password is incorrect.");
                return Page();
            }

            var person = await _personProvider.GetPersonByIdAsync(result.PersonId, cancellationToken);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()),
                new Claim(ClaimTypes.Name, result.Username),
                new Claim(ClaimTypes.Email, result.Email),
                new Claim(ClaimTypes.GivenName, person.DisplayName)
            };

            var identity = new ClaimsIdentity(claims, "cookie");
            var principal = new ClaimsPrincipal(identity);

            await _contextAccessor.HttpContext.SignInAsync(principal);

            return Page();
        }

        public async Task<IActionResult> OnPostRegisterAsync(RegisterUserViewModel model, CancellationToken cancellationToken = default)
        {
            if (!model.RegisterCheck)
            {
                ModelState.AddModelError("noCheck", "Make sure to agree to the terms before you register!");
            }

            if (model.DisplayName.IsNullOrEmpty() ||
                model.UserName.IsNullOrEmpty() ||
                model.Email.IsNullOrEmpty() ||
                model.Password.IsNullOrEmpty() ||
                model.RepeatPassword.IsNullOrEmpty() ||
                model.Password != model.RepeatPassword)
            {
                ModelState.AddModelError("missingField", "All fields must be filled in, passwords must be equal");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var toCreate = _mapper.Map<User>(model);

            var result = await _userProvider.CreateUserAsync(toCreate, model.DisplayName, cancellationToken);

            if (!result)
            {
                ModelState.AddModelError("existingUser", "Email or Username already exists");
            }

            return Page();
        }

        public async Task OnPostLogoutAsync()
        {
            await _contextAccessor.HttpContext.SignOutAsync();
        }

        public void OnGet()
        {

        }
    }
}