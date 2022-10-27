using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoCiele.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using ProjetoCiele.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ProjetoCiele.Controllers
{
    public class HomeController : Controller
    {
        private readonly Contexto db;
        private readonly ILogger<HomeController> _logger;
        public IList<Produtos> Produtos;

        public HomeController(ILogger<HomeController> logger, Contexto contexto){
            db = contexto;
            _logger = logger;
        }

        public IActionResult Index()
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
        public async Task OnGetAsync(){
            Produtos = await db.PRODUTOS.ToListAsync<Produtos>();
        }
    }
}
