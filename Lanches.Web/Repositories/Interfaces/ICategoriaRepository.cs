using System.Collections.Generic;
using Lanches.Web.Models;

namespace Lanches.Web.Repositories
{
    public interface ICategoriaRepository
    {
         IEnumerable<Categoria> Categorias { get; }
    }
}