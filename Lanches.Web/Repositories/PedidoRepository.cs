using System;
using Lanches.Web.Context;
using Lanches.Web.Models;

namespace Lanches.Web.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext appDbContext, CarrinhoCompra carrinhoCompra)
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _appDbContext.Pedidos.Add(pedido);

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItens;
            foreach (var item in carrinhoCompraItens)
            {
                var pedidoDetalhe = new PedidoDetalhe(){
                    Quantidade = item.Quantidade,
                    LancheId = item.Lanche.LancheId,
                    PedidoId = pedido.PedidoId,
                    Preco = item.Lanche.Preco
                };

                _appDbContext.PedidoDetalhes.Add(pedidoDetalhe);
            }

            _appDbContext.SaveChanges();
        }
    }
}