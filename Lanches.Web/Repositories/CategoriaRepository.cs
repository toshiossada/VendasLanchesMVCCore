using System.Collections.Generic;
using Lanches.Web.Context;
using Lanches.Web.Models;

namespace Lanches.Web.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _contexto;
        public CategoriaRepository(AppDbContext contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<Categoria> Categorias => _contexto.Categorias;
    }
}