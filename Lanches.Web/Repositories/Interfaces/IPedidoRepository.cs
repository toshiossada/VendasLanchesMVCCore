using Lanches.Web.Models;

namespace Lanches.Web.Repositories
{
    public interface IPedidoRepository
    {
        void CriarPedido(Pedido pedido);
    }
}