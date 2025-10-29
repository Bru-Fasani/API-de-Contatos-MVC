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
            Debug.WriteLine($"Criando contato: {contato.Nome}");

            if (ModelState.IsValid)
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
           return View(contato);
        }
    }

}
