using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Context;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    public class LivrariaController : Controller
    {
        private readonly LivrariaContext _context;

        public LivrariaController(LivrariaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var livro = _context.Livros.ToList();
            return View(livro);

        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Livro livros)
        {
            if (ModelState.IsValid)
            {
                
                _context.Livros.Add(livros);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(livros);
        }

        public IActionResult Editar(int id)
        { 
            var livros = _context.Livros.Find(id);
        if (livros == null)
        
                return RedirectToAction(nameof(Index));
        

            return View(livros);
        }

        [HttpPost]
        public IActionResult Editar(Livro livros)
        {
            var livroBanco = _context.Livros.Find(livros.Id);
            livroBanco.Nome = livros.Nome;
            livroBanco.Descricao = livros.Descricao;
            livroBanco.Editora = livros.Editora;
            livroBanco.Genero = livros.Genero;
            livroBanco.Reservado = livros.Reservado;

            _context.Livros.Update(livroBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var livros = _context.Livros.Find(id);

            if (livros == null)
            
                return RedirectToAction(nameof(Index));
            
                            return View(livros);

        }
          public IActionResult Deletar(int id)
        {
            var livros = _context.Livros.Find(id);

            if (livros == null)
                return RedirectToAction(nameof(Index));

            return View(livros);
        }


        [HttpPost]
        public IActionResult Deletar(Livro livros)
        {
            var livroBanco = _context.Livros.Find(livros.Id);
            _context.Livros.Remove(livroBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet("Pesquisa")]
        public IActionResult Pesquisa(string nome)
{
    var livros = _context.Livros.Where(x => x.Nome.Contains(nome)).ToList();

    if (livros == null || livros.Count == 0)
        return NotFound();

    return View(livros);
}



    }
}