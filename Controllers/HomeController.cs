using System.Data;
using System.Diagnostics;
using IsTakipSistemi.Models;
using Microsoft.AspNetCore.Mvc;

namespace IsTakipSistemi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbConnection _connection;

        public HomeController(IDbConnection connection) 
        {
            _connection = connection;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
