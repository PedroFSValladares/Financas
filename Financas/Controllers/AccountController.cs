using Financas.Context;
using Financas.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;

namespace Financas.Controllers {
    public class AccountController : Controller {
        public readonly MoneyContext _context;
        public readonly PasswordHasher<Conta> _passwordHasher;

        public AccountController(MoneyContext context, PasswordHasher<Conta> passwordHasher) {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        [Route("Account/Login")]
        public async Task<IActionResult> LoginPost() {
            string bodyJson = Encoding.UTF8.GetString(HttpContext.Request.BodyReader.ReadAsync().Result.Buffer);
            var conta = JsonConvert.DeserializeObject<LoginModel>(bodyJson);
            var contaQuery = from c in _context.Contas
                             where c.Login == conta.Login
                             select new Conta { Login = c.Login, Senha = c.Senha, Id = c.Id };
            var dbConta = contaQuery.FirstOrDefault();

            if(dbConta == null) {
                return NotFound("Conta Inexistente.");
            }

            string userId = Convert.ToString(dbConta.Id);

            var result = _passwordHasher.VerifyHashedPassword(dbConta, dbConta.Senha, conta.Senha);

            if(result == PasswordVerificationResult.Failed) {
                return BadRequest("Login ou senha incorretos.");
            }

            if(result == PasswordVerificationResult.SuccessRehashNeeded) {
                string newHashedPassword = _passwordHasher.HashPassword(dbConta, conta.Senha);
                dbConta.Senha = newHashedPassword;
                _context.Contas.Update(dbConta);
                _context.SaveChanges();
            }

            var claims = new ClaimsIdentity(new Claim[] {
                new Claim("Id", userId),
                new Claim(ClaimTypes.NameIdentifier, dbConta.Login)
            }, CookieAuthenticationDefaults.AuthenticationScheme);

            string redirectUri = HttpContext.Request.Query["ReturnUrl"];

            redirectUri ??= "/";
            var authProperties = new AuthenticationProperties {
                IsPersistent = conta.Remember
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claims), authProperties);

            return LocalRedirect("/");
        }

        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Conta conta) {
            string passwordHashed = _passwordHasher.HashPassword(conta, conta.Senha);
            conta.Senha = passwordHashed;
            _context.Contas.Add(conta);
            _context.SaveChanges();
            return LocalRedirect("/");
        }
    }
}
