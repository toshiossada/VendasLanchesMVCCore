using System.Linq;
using System.Threading.Tasks;
using Lanches.Web.Context;
using Lanches.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lanches.Web.Areas.Admin.Controllers {
    [Area ("Admin")]
    [Authorize (Roles = "Admin")]
    public class AdminCategoriasController : Controller {
        private readonly AppDbContext _context;

        public AdminCategoriasController (AppDbContext context) {
            _context = context;
        }

        // GET: Admin/AdminCategorias
        public async Task<IActionResult> Index () {
            return View (await _context.Categorias.ToListAsync ());
        }

        // GET: Admin/AdminCategorias/Details/5
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var categoria = await _context.Categorias
                .SingleOrDefaultAsync (m => m.CategoriaId == id);
            if (categoria == null) {
                return NotFound ();
            }

            return View (categoria);
        }

        // GET: Admin/AdminCategorias/Create
        public IActionResult Create () {
            return View ();
        }

        // POST: Admin/AdminCategorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("CategoriaId,CategoriaNome,Descricao")] Categoria categoria) {
            if (ModelState.IsValid) {
                _context.Add (categoria);
                await _context.SaveChangesAsync ();
                return RedirectToAction (nameof (Index));
            }
            return View (categoria);
        }

        // GET: Admin/AdminCategorias/Edit/5
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var categoria = await _context.Categorias.SingleOrDefaultAsync (m => m.CategoriaId == id);
            if (categoria == null) {
                return NotFound ();
            }
            return View (categoria);
        }

        // POST: Admin/AdminCategorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind ("CategoriaId,CategoriaNome,Descricao")] Categoria categoria) {
            if (id != categoria.CategoriaId) {
                return NotFound ();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update (categoria);
                    await _context.SaveChangesAsync ();
                } catch (DbUpdateConcurrencyException) {
                    if (!CategoriaExists (categoria.CategoriaId)) {
                        return NotFound ();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction (nameof (Index));
            }
            return View (categoria);
        }

        // GET: Admin/AdminCategorias/Delete/5
        public async Task<IActionResult> Delete (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var categoria = await _context.Categorias
                .SingleOrDefaultAsync (m => m.CategoriaId == id);
            if (categoria == null) {
                return NotFound ();
            }

            return View (categoria);
        }

        // POST: Admin/AdminCategorias/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id) {
            var categoria = await _context.Categorias.SingleOrDefaultAsync (m => m.CategoriaId == id);
            _context.Categorias.Remove (categoria);
            await _context.SaveChangesAsync ();
            return RedirectToAction (nameof (Index));
        }

        private bool CategoriaExists (int id) {
            return _context.Categorias.Any (e => e.CategoriaId == id);
        }
    }
}