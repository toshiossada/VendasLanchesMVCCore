using System.Collections.Generic;
using Lanches.Web.Models;
using Lanches.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lanches.Web.Components {
    public class CarrinhoCompraResumo : ViewComponent {
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraResumo (CarrinhoCompra carrinhoCompra) {
            _carrinhoCompra = carrinhoCompra;
        }

        public IViewComponentResult Invoke () {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            //var itens    = new List<CarrinhoCompraItem>(){
            //     new CarrinhoCompraItem(),
            //     new CarrinhoCompraItem()
            // };

            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraVm =new CarrinhoCompraViewModel(){
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetValorTotal()
            };

            return View(carrinhoCompraVm);
        }
    }
}