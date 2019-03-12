using Lanches.Web.Models;
using Lanches.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lanches.Web.Controllers {
    public class PedidoController : Controller {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController (IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra) {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Checkout () {

            return View ();

        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout (Pedido pedido) {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            if(_carrinhoCompra.CarrinhoCompraItens.Count == 0){
                ModelState.AddModelError("", "Seu carrinho essta vazio");
            }else{
                if(ModelState.IsValid)
                {
                    _pedidoRepository.CriarPedido(pedido);
                    _carrinhoCompra.LimparCarrinho();

                    return RedirectToAction("CheckoutCompleto");
                }
            }

            return View(pedido);
        }

        public IActionResult CheckoutCompleto(){
            ViewBag.CheckoutCompletoMessage = "Obrigado pelo seu pedido :)";

            return View();
        }
    }
}