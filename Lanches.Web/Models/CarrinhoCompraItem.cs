using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lanches.Web.Models
{
    public class CarrinhoCompraItem
    {
        public int CarrinhoCompraItemId { get; set; }    
        public Lanche Lanche { get; set; }
        public int Quantidade { get; set; }
        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }
    }
}