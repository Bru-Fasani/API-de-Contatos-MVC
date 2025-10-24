using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using API_MVC.Context;
using API_MVC.Models;

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

        [HttpPost]
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
    }

}
