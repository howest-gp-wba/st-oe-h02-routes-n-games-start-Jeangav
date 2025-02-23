using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Games.Web.Models;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<p><h2>Rate-A-Game</h2></p>");
            stringBuilder.AppendLine("<p><a href='/games/all'>Games</a></p>");
            stringBuilder.AppendLine("<p><a href='/developers/all'>Developers</a></p>");
            return Content(stringBuilder.ToString(),"text/html");
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
