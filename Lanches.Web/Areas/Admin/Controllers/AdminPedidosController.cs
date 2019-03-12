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
    [Authorize (Roles = "Admin")]
    public class AdminPedidosController : Controller {
        private readonly AppDbContext _context;

        public AdminPedidosController (AppDbContext context) {
            _context = context;
        }

        // GET: Admin/AdminPedidos
        public async Task<IActionResult> Index () {
            return View (await _context.Pedidos.ToListAsync ());
        }

        // GET: Admin/AdminPedidos/Details/5
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var pedido = await _context.Pedidos
                .SingleOrDefaultAsync (m => m.PedidoId == id);
            if (pedido == null) {
                return NotFound ();
            }

            return View (pedido);
        }

        // GET: Admin/AdminPedidos/Create
        public IActionResult Create () {
            return View ();
        }

        // POST: Admin/AdminPedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("PedidoId,Nome,Sobrenome,Endereco1,Endereco2,Cep,Estado,Cidade,Telefone,Email,PedidoEnviado,PedidoEntregueEm")] Pedido pedido) {
            if (ModelState.IsValid) {
                _context.Add (pedido);
                await _context.SaveChangesAsync ();
                return RedirectToAction (nameof (Index));
            }
            return View (pedido);
        }

        // GET: Admin/AdminPedidos/Edit/5
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var pedido = await _context.Pedidos.SingleOrDefaultAsync (m => m.PedidoId == id);
            if (pedido == null) {
                return NotFound ();
            }
            return View (pedido);
        }

        // POST: Admin/AdminPedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind ("PedidoId,Nome,Sobrenome,Endereco1,Endereco2,Cep,Estado,Cidade,Telefone,Email,PedidoEnviado,PedidoEntregueEm")] Pedido pedido) {
            if (id != pedido.PedidoId) {
                return NotFound ();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update (pedido);
                    await _context.SaveChangesAsync ();
                } catch (DbUpdateConcurrencyException) {
                    if (!PedidoExists (pedido.PedidoId)) {
                        return NotFound ();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction (nameof (Index));
            }
            return View (pedido);
        }

        // GET: Admin/AdminPedidos/Delete/5
        public async Task<IActionResult> Delete (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var pedido = await _context.Pedidos
                .SingleOrDefaultAsync (m => m.PedidoId == id);
            if (pedido == null) {
                return NotFound ();
            }

            return View (pedido);
        }

        // POST: Admin/AdminPedidos/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id) {
            var pedido = await _context.Pedidos.SingleOrDefaultAsync (m => m.PedidoId == id);
            _context.Pedidos.Remove (pedido);
            await _context.SaveChangesAsync ();
            return RedirectToAction (nameof (Index));
        }

        private bool PedidoExists (int id) {
            return _context.Pedidos.Any (e => e.PedidoId == id);
        }
    }
}