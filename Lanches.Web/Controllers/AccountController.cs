using System.Threading.Tasks;
using Lanches.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace Lanches.Web.Controllers {

    public class AccountController : Controller {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController (UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login (string url) {

            return View (new LoginViewModel () {
                ReturnUrl = url
            });

        }

        [HttpPost]
        public async Task<IActionResult> Login (LoginViewModel login) {
            if (!ModelState.IsValid) {
                return View (login);
            } else {
                var user = await _userManager.FindByNameAsync (login.UserName);
                if (user != null) {
                    var result = await _signInManager.PasswordSignInAsync (user, login.Password, false, false);
                    if (result.Succeeded) {
                        if (string.IsNullOrEmpty (login.ReturnUrl)) return RedirectToAction ("Index", "Home");
                        else return RedirectToAction (login.ReturnUrl);
                    }
                } else {
                    ModelState.AddModelError ("", "Usuário não localizado");
                }
            }
            return View (login);
        }

        public IActionResult Register () {

            return View ();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register (LoginViewModel registro) {
            if (ModelState.IsValid) {
                var usuario = new IdentityUser () { UserName = registro.UserName };
                var result = await _userManager.CreateAsync (usuario, registro.Password);

                if (result.Succeeded) {
                    await _userManager.AddToRoleAsync(usuario, "Member");
                    await _signInManager.SignInAsync(usuario, isPersistent: false);
                    
                    return RedirectToAction ("Index", "Home");
                }
            }

            return View (registro);
        }

        [HttpPost]
        public async Task<IActionResult> Logout () {
            await _signInManager.SignOutAsync ();

            return RedirectToAction ("Index", "Home");
        }
    }
}