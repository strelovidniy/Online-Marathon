using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sprint_15.Models;

namespace Sprint_15.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
