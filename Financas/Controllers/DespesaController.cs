using Financas.Context;
using Financas.Models;
using Microsoft.AspNetCore.Mvc;

namespace Financas.Controllers {
    public class DespesaController : Controller {
        public readonly MoneyContext _context;

        public DespesaController(MoneyContext context) {
            _context = context;
        }

        public IActionResult Create() {
            return PartialView();
        }

        [HttpPost]
        public IActionResult Create(Despesa despesa) {
            var userId = HttpContext.User.Claims.Single(x => x.Type == "Id");
            int id = Convert.ToInt32(userId.Value);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            Conta conta = _context.Contas.Find(id);
            conta.Despesas ??= new List<Despesa>();
            conta.Despesas.Add(despesa);

            _context.Contas.Update(conta);
            _context.SaveChanges();
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public IActionResult Delete(int id) {
            var dbConta = _context.Despesas.Find(id);

            if(dbConta == null) 
                return NotFound();

            _context.Despesas.Remove(dbConta);
            _context.SaveChanges();
            return Ok();
        }

        public IActionResult Edit(Despesa despesa) {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Despesas.Update(despesa);
            _context.SaveChanges();
            return Ok();
        }
    }
}
