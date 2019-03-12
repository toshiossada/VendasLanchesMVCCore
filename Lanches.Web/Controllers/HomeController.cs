using Lanches.Web.Repositories;
using Lanches.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lanches.Web.Controllers {
    public class HomeController : Controller {
        private readonly ILancheRepository _lancheRepository;

        public HomeController (ILancheRepository lancheRepository) {
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index () {
            var homeVm = new HomeViewModel () {
                LanchesPreferidos = _lancheRepository.LanchesPreferidos
            };

            return View (homeVm);
        }

        public IActionResult AccessDenied () {
            return View();
        }
    }
}