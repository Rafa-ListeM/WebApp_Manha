using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp_Manha.Models;

namespace WebApp_Manha.Controllers
{
    public class HomeController : Controller
    {
        //atributo da classe HomeController
        private readonly ILogger<HomeController> _logger;
        private readonly Contexto db;
        //Construtor da classe
        public HomeController(Contexto db,   ILogger<HomeController> logger)
        {
            _logger = logger;
            this.db = db;
        }

        //Action Result devolve uma tela (Html)
        public IActionResult Index()
        {
            return View( db.Produtos.ToList()  );
        }
        //Mais uma tela no sistema
        public IActionResult BemVindo()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

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