using Financas.Context;
using Financas.Models;
using Microsoft.AspNetCore.Mvc;

namespace Financas.Controllers {
    public class DespesaController : Controller {
        public readonly MoneyContext _context;

        public DespesaController(MoneyContext context) {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Despesa despesa) {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Despesas.Add(despesa);
            _context.SaveChanges();
            return Ok(despesa);
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
