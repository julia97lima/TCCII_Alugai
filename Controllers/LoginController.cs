using Alugai.Data;
using Alugai.Models.Services;
using Alugai.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;

namespace Alugai.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        // POST: LoginController/FazerLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(IFormCollection collection)
        {
            try
            {
                var loginViewModel = new LoginViewModel
                {
                    Cpf = collection["Cpf"],
                    Senha = collection["Senha"]
                };

                if (_loginService.LoginValido(loginViewModel))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.SerialNumber, _loginService.LimparInjecao(loginViewModel.Cpf)),
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Details", "Usuario");
                }
                else
                {
                    TempData["fail"] = "CPF/Senha incorreto(s)";
                    return View(loginViewModel);
                }
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Home", "Index");
        }

    }
}
