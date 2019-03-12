using Microsoft.AspNetCore.Mvc;

namespace Lanches.Web.Controllers {
    public class ContatoController : Controller {

        public IActionResult Index () {
            return View ();
        }
    }
}