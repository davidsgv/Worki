using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Worki.Models;
using Worki.Service;

namespace Worki.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioService usuarioService;

        public HomeController(ILogger<HomeController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> PostLogin([FromForm] LoginRequest request)
        {
            var result = await usuarioService.AuthenticateAsync(request.Email, request.Password);

            if (result)
            {
                return Redirect("/Perfil/Perfil");
            }

            ViewBag.ErrorMessage = "Verifique Usuario y/o Password";
            return View("Index");
        }


        [HttpPost]
        public async Task<IActionResult> PostRegister([FromForm] RegisterRequest request)
        {
            var result = await usuarioService.InsertAsync(request, request.UsuPassword);

            if (result != null)
                ViewBag.ResultMessage = "Se ha registrado en nuestra plataforma";
            else
                ViewBag.ResultMessage = "El correo ingresado ya esta registrado";

            return View("Index");
        }


        [Authorize(Roles = "ADMINISTRADOR,USUARIO")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}