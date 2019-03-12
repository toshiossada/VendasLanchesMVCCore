using System.Linq;
using Lanches.Web.Models;
using Lanches.Web.Repositories;
using Lanches.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lanches.Web.Controllers {
    public class CarrinhoCompraController : Controller {
        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController (ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra) {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index () {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens ();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraViewModel = new CarrinhoCompraViewModel () {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetValorTotal ()
            };

            return View (carrinhoCompraViewModel);
        }
        
        [Authorize]
        public IActionResult Adicionar (int lancheId) {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault (r => r.LancheId == lancheId);

            if (lancheSelecionado != null) {
                _carrinhoCompra.AdicionarAoCarrinho (lancheSelecionado, 1);
            }

            return RedirectToAction ("Index");
        }
        [Authorize]
        public IActionResult Remover (int lancheId) {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault (r => r.LancheId == lancheId);

            if (lancheSelecionado != null) {
                _carrinhoCompra.RemoverDoCarrinho (lancheSelecionado);
            }

            return RedirectToAction ("Index");
        }
    }
}