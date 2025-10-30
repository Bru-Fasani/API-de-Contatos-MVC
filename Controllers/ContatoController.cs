using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using API_MVC.Context;
using API_MVC.Models;
using System.Diagnostics;

namespace API_MVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaDbContext _context;
        public ContatoController(AgendaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var contatos = _context.Contatos.ToList();
            return View(contatos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CriarNovoContato(Contato contato)
        {

            if (ModelState.IsValid)
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contato);
        }

        public IActionResult Edit(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
                return NotFound();

            return View(contato);
        }

        [HttpPost]
        public IActionResult Edit(Contato contato)
        {
            
            if (ModelState.IsValid)
            {
                _context.Contatos.Update(contato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(contato);

        }
    }
}
