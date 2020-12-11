using Microsoft.AspNetCore.Mvc;

namespace Sprint_12.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
