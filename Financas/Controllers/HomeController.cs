using Financas.Context;
using Financas.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Financas.Controllers {
    [Authorize]
    public class HomeController : Controller {
        public readonly MoneyContext _context;
        public readonly PasswordHasher<Conta> _passwordHasher;

        public HomeController(MoneyContext context, PasswordHasher<Conta> passwordHasher) {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public IActionResult Index() {
            var userId = HttpContext.User.Claims.Single(x => x.Type == "Id");
            var conta = _context.Contas.Find(Convert.ToInt32(userId.Value));
            conta.Senha = "";
            return View(conta);
        }

        [AllowAnonymous]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(Conta conta) {
            string passwordHashed = _passwordHasher.HashPassword(conta, conta.Senha);
            conta.Senha = passwordHashed;
            _context.Contas.Add(conta);
            _context.SaveChanges();
            return LocalRedirect("/");
        }

        [AllowAnonymous]
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Conta conta, [FromForm] string remember) {
            var contaQuery = from c in _context.Contas
                        where c.Login == conta.Login
                        select new Conta{ Login = c.Login, Senha = c.Senha, Id = c.Id };
            var dbConta = contaQuery.FirstOrDefault();
            string userId = Convert.ToString(dbConta.Id);

            if(dbConta == null) {
                return NotFound("Conta Inexistente.");
            }

            var result = _passwordHasher.VerifyHashedPassword(conta, dbConta.Senha, conta.Senha);

            if(result == PasswordVerificationResult.Failed) {
                return BadRequest("Login ou senha incorretos.");
            }

            if(result == PasswordVerificationResult.SuccessRehashNeeded) {
                string newHashedPassword = _passwordHasher.HashPassword(conta, conta.Senha);
                conta.Senha = newHashedPassword;
                _context.Contas.Update(conta);
                _context.SaveChanges();
            }

            var claims = new ClaimsIdentity(new Claim[] {
                new Claim("Id", userId),
                new Claim(ClaimTypes.NameIdentifier, conta.Login)
            }, CookieAuthenticationDefaults.AuthenticationScheme);

            string redirectUri = HttpContext.Request.Query["ReturnUrl"];

            redirectUri ??= "/";
            var authProperties = new AuthenticationProperties {
                IsPersistent = remember == "true"
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claims), authProperties);

            return LocalRedirect(redirectUri);
        }

        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync();
            return RedirectToAction(actionName: "index", controllerName: "Home");
        }

        public IActionResult Forbidden() {
            return View();
        }
    }
}
