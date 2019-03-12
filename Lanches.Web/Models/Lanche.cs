using System.ComponentModel.DataAnnotations;

namespace Lanches.Web.Models
{
    public class Lanche
    {    
       public int LancheId { get; set; }
       [StringLength(100)]
       public string Nome { get; set; }
       [StringLength(100)]
       public string DescricaoCurta { get; set; }
       [StringLength(255)]
       public string DescricaoLonga { get; set; }
       public decimal Preco { get; set; }
       [StringLength(200)]
       public string ImgUrl { get; set; }
       [StringLength(200)]
       public string ImagemThumbnailUrl { get; set; }
       public bool IsFavorite { get; set; }
       public bool EmEstoque { get; set; }
       public int CategoriaId { get; set; }
       public virtual Categoria Categoria { get; set; }
    }
}