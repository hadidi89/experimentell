using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewsPartialsViewsMVVM.Services;
using ViewsPartialsViewsMVVM.ViewModels.AccountViewModel;

namespace ViewsPartialsViewsMVVM.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _auth;

        public AccountController(AuthService auth)
        {
            _auth = auth;
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewData["Title"] = "Account";
            return View();
        }

        public IActionResult Register()
        {
            ViewData["Title"] = "Register";
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterAccountViewModel model)
        {
            ViewData["Title"] = "Register Accuont";

            if (ModelState.IsValid)
            {
                if(await _auth.RegisterAsync(model))
                return RedirectToAction("login", "account");

                ModelState.AddModelError("", "A user with that e-mail already exists.");
            }

            return View(model);
        }

        public IActionResult Login()
        {
            ViewData["Title"] = "Login";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginAccountViewModel model)
        {
            ViewData["Title"] = "Login";

            if (ModelState.IsValid)
            {
                if (await _auth.LoginAsync(model))
                    return RedirectToAction("index", "account");

                ModelState.AddModelError("", "Incorrect e-mail or password.");
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            if(await _auth.LogoutAsync(User))
            {
                return RedirectToAction("index", "home");
            }
            return RedirectToAction("login", "account");
        }
    }
}
