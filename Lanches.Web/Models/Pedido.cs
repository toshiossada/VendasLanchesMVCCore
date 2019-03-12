using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lanches.Web.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public List<PedidoDetalhe> PedodoItens { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name="Nome")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o sobrenome")]
        [Display(Name="Sobrenome")]
        [StringLength(50)]
        public string Sobrenome { get; set; }
        
        [Required(ErrorMessage = "Informe o endereco")]
        [Display(Name="Endereço")]
        [StringLength(100)]
        public string Endereco1 { get; set; }
        
        [Display(Name="Complemento")]
        [StringLength(50)]
        public string Endereco2 { get; set; }

        [Required(ErrorMessage = "Informe o CEP")]
        [Display(Name="CEP")]
        [StringLength(10, MinimumLength = 8)]
        public string Cep { get; set; }

        
        [StringLength(10)]
        public string Estado { get; set; }

        [StringLength(50)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o telefone")]
        [Display(Name="Telefone")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(25)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        [Display(Name="e-Mail")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "O email não possui um formato correto")]
        public string Email { get; set; }

        [BindNever]        
        [ScaffoldColumn(false)]
        public decimal PedidoTotal { get; set; }

        [Display(Name = "Data/Hora da Envio do Pedido")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString  = "{0: dd/MM/yyyy hh:mm", ApplyFormatInEditMode = true)]
        public DateTime PedidoEnviado { get; set; }

        [Display(Name = "Data/Hora da Entrega do Pedido")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString  = "{0: dd/MM/yyyy hh:mm", ApplyFormatInEditMode = true)]
        public DateTime? PedidoEntregue { get; set; }
    }
}