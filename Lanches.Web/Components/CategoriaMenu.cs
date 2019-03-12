using System.Linq;
using Lanches.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lanches.Web.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke () {
            var categorias = _categoriaRepository.Categorias.OrderBy(r => r.CategoriaNome);

            return View(categorias);
        }
    }
}