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
            int id = Convert.ToInt32(userId.Value);
            var query = from conta in _context.Contas
                        where conta.Id == id
                        select new Conta {
                            Saldo = conta.Saldo,
                            TotalDeDespesas = conta.Despesas.Sum(x => x.Valor),
                            Despesas = conta.Despesas,
                            Transacoes = conta.Transacoes,
                            Login = conta.Login,
                            Metas = conta.Metas,
                            BalançoDeSaldoComDespesa = conta.Saldo - conta.Despesas.Sum(x => x.Valor)
                        };
            Conta usuario = query.FirstOrDefault();
            /*
            var query = from contaCalc in
                            from conta in _context.Contas
                            where conta.Id == id
                            join despesa in _context.Despesas on conta.Id equals id
                            select new Conta { 
                                Saldo = conta.Saldo,
                                Despesas = conta.Despesas,
                                TotalDeDespesas = conta.Despesas.Sum(x => x.Valor)
                            }
                        select new Conta { Saldo = contaCalc., };
            */
            //var conta = _context.Contas.Find(Convert.ToInt32(userId.Value));
            return View(usuario);
        }

        public IActionResult Forbidden() {
            return View();
        }
    }
}
