using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly BibliotecaContext _DBContext;

        public HomeController(BibliotecaContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }
    }
}