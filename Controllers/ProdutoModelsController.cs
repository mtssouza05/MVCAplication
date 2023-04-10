using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProdutoModelsController : Controller
    {
        private readonly ProdutoContext _context;

        public ProdutoModelsController(ProdutoContext context)
        {
            _context = context;
        }

        // GET: ProdutoModels
        public ActionResult Index()
        {
              return _context.Produto != null ? 
                          View(_context.Produto.ToList()) :
                          Problem("Produto é nulo");
        }

        // GET: ProdutoModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var produto = _context.Produto
                .FirstOrDefault(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: ProdutoModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Nome,Disponivel,Preco")] ProdutoModel produtoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtoModel);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(produtoModel);
        }

        // GET: ProdutoModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var produtoModel = _context.Produto.Where(p=>p.Id == id);
            if (produtoModel == null)
            {
                return NotFound();
            }
            return View(produtoModel);
        }

        // POST: ProdutoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Nome,Disponivel,Preco")] ProdutoModel produtoModel)
        {
            if (id != produtoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtoModel);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoModelExists(produtoModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produtoModel);
        }

        // GET: ProdutoModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var produtoModel =  _context.Produto
                .FirstOrDefault(m => m.Id == id);
            if (produtoModel == null)
            {
                return NotFound();
            }

            return View(produtoModel);
        }

        // POST: ProdutoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (_context.Produto == null)
            {
                return Problem("Entity set 'ProdutoContext.Produto'  is null.");
            }
            var produtoModel = _context.Produto.Find(id);
            if (produtoModel != null)
            {
                _context.Produto.Remove(produtoModel);
            }
            
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoModelExists(int id)
        {
          return (_context.Produto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
