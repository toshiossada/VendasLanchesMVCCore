using System.Linq;
using System.Threading.Tasks;
using Lanches.Web.Context;
using Lanches.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lanches.Web.Areas.Admin.Controllers {
    [Area ("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminLanchesController : Controller {
        private readonly AppDbContext _context;

        public AdminLanchesController (AppDbContext context) {
            _context = context;
        }

        // GET: Admin/AdminLanches
        public async Task<IActionResult> Index () {
            var appDbContext = _context.Lanches.Include (l => l.Categoria);
            return View (await appDbContext.ToListAsync ());
        }

        // GET: Admin/AdminLanches/Details/5
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var lanche = await _context.Lanches
                .Include (l => l.Categoria)
                .SingleOrDefaultAsync (m => m.LancheId == id);
            if (lanche == null) {
                return NotFound ();
            }

            return View (lanche);
        }

        // GET: Admin/AdminLanches/Create
        public IActionResult Create () {
            ViewData["CategoriaId"] = new SelectList (_context.Categorias, "CategoriaId", "CategoriaNome");
            return View ();
        }

        // POST: Admin/AdminLanches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("LancheId,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsLanchePreferido,EmEstoque,CategoriaId")] Lanche lanche) {
            if (ModelState.IsValid) {
                _context.Add (lanche);
                await _context.SaveChangesAsync ();
                return RedirectToAction (nameof (Index));
            }
            ViewData["CategoriaId"] = new SelectList (_context.Categorias, "CategoriaId", "CategoriaNome", lanche.CategoriaId);
            return View (lanche);
        }

        // GET: Admin/AdminLanches/Edit/5
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var lanche = await _context.Lanches.SingleOrDefaultAsync (m => m.LancheId == id);
            if (lanche == null) {
                return NotFound ();
            }
            ViewData["CategoriaId"] = new SelectList (_context.Categorias, "CategoriaId", "CategoriaNome", lanche.CategoriaId);
            return View (lanche);
        }

        // POST: Admin/AdminLanches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind ("LancheId,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsLanchePreferido,EmEstoque,CategoriaId")] Lanche lanche) {
            if (id != lanche.LancheId) {
                return NotFound ();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update (lanche);
                    await _context.SaveChangesAsync ();
                } catch (DbUpdateConcurrencyException) {
                    if (!LancheExists (lanche.LancheId)) {
                        return NotFound ();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction (nameof (Index));
            }
            ViewData["CategoriaId"] = new SelectList (_context.Categorias, "CategoriaId", "CategoriaNome", lanche.CategoriaId);
            return View (lanche);
        }

        // GET: Admin/AdminLanches/Delete/5
        public async Task<IActionResult> Delete (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var lanche = await _context.Lanches
                .Include (l => l.Categoria)
                .SingleOrDefaultAsync (m => m.LancheId == id);
            if (lanche == null) {
                return NotFound ();
            }

            return View (lanche);
        }

        // POST: Admin/AdminLanches/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id) {
            var lanche = await _context.Lanches.SingleOrDefaultAsync (m => m.LancheId == id);
            _context.Lanches.Remove (lanche);
            await _context.SaveChangesAsync ();
            return RedirectToAction (nameof (Index));
        }

        private bool LancheExists (int id) {
            return _context.Lanches.Any (e => e.LancheId == id);
        }
    }
}