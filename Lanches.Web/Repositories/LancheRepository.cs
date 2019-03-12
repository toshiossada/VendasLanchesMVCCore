using System.Collections.Generic;
using System.Linq;
using Lanches.Web.Context;
using Lanches.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Lanches.Web.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _contexto;
        public LancheRepository(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Lanche> Lanches => _contexto.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _contexto.Lanches.Where(r => r.IsFavorite).Include(c => c.Categoria);

        public Lanche GetLancheById(int id) => _contexto.Lanches.Find(id);
    }
}