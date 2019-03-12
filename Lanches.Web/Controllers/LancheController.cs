using System;
using System.Collections.Generic;
using System.Linq;
using Lanches.Web.Models;
using Lanches.Web.Repositories;
using Lanches.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lanches.Web.Controllers {
    public class LancheController : Controller {
        private readonly ILancheRepository _lancheRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        public LancheController (ILancheRepository lancheRepository, ICategoriaRepository categoriaRepository) {
            _lancheRepository = lancheRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult List (string categoria) {
            IEnumerable<Lanche> lanches;
            var categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty (categoria)) {
                lanches = _lancheRepository.Lanches.OrderBy (r => r.LancheId);
                categoria = "Todos os lanches";
            } else {
                lanches = _lancheRepository.Lanches.Where (r => r.Categoria.CategoriaNome == categoria).OrderBy (r => r.LancheId);

                categoriaAtual = categoria;
            }

            var lancheListVM = new LancheListViewModel ();
            lancheListVM.Lanches = lanches;
            lancheListVM.CategoriaAtual = categoriaAtual;

            return View (lancheListVM);
        }

        public IActionResult Details (int lancheId) {
            var lanche = _lancheRepository.Lanches.FirstOrDefault (t => t.LancheId == lancheId);
            if (lanche == null) {
                return View ("~/Views/Error/Error.cshtml");
            } else {
                return View (lanche);
            }

        }

        public IActionResult Search(string searchString) {
            var _serachString = searchString;

            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if(String.IsNullOrEmpty(searchString)){
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
            }else{
                lanches = _lancheRepository.Lanches
                    .Where(l => l.Nome.ToLower().Contains(searchString.ToLower()))
                    .OrderBy(l => l.LancheId);
            }

            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel { Lanches = lanches, CategoriaAtual = categoriaAtual });
        }
    }
}