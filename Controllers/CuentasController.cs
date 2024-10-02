using CRUD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class CuentasController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signInManager;


        public CuentasController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Registro()
        {

            RegistroViewModel registroVM = new RegistroViewModel();
            return View(registroVM);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[AllowAnonymous]


        public async Task<IActionResult> Registro(RegistroViewModel rgViewModel)
        {
            //ViewData["ReturnUrl"] = returnurl;
            //returnurl = returnurl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var usuario = new AppUsuario { UserName = rgViewModel.Email, Email = rgViewModel.Email, Nombre = rgViewModel.Nombre, };
                var resultado = await _userManager.CreateAsync(usuario, rgViewModel.Password);

                if (resultado.Succeeded)
                {
                    //Esta linea es para la asignacion del usuario que se registra al rol "Registrado"
                    //await _userManager.AddToRoleAsync(usuario, "Registrado");
                    await _signInManager.SignInAsync(usuario, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }
                ValidarErrores(resultado);

            }


            return View(rgViewModel);

        }
        private void ValidarErrores(IdentityResult resultado)
        {
            foreach (var error in resultado.Errors)
            {

                ModelState.AddModelError(String.Empty, error.Description);
            }
        }

        [HttpGet]
        [AllowAnonymous]


        public IActionResult Acceso(string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Acceso(AccesoViewModel accViewModel, string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            if (ModelState.IsValid)
            {
                // Lockout on failure is set to true, isPersistent needs to be specified
                var resultado = await _signInManager.PasswordSignInAsync(
                    accViewModel.Email,
                    accViewModel.Password,
                    isPersistent: false, // Set to true if you want the login session to persist across browser restarts
                    lockoutOnFailure: true
                );

                if (resultado.Succeeded)
                {
                    // Redirect to the homepage on successful login
                    return Redirect(returnurl);
                }

                if (resultado.IsLockedOut)
                {
                    return View("Bloqueado");
                }

                ModelState.AddModelError(String.Empty, "Acceso invalido");
            }

            return View(accViewModel);
        }


        //Salir o cerrar sesion de la aplicacion (logout)

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SalirAplicacion()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
