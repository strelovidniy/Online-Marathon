using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductsWithRouting.Models;
using System.Diagnostics;
using ProductsWithRouting.Services;

namespace ProductsWithRouting.Controllers
{
    public class UsersController : Controller
    {
        private List<User> myUsers;
        private string password;

        public UsersController(Data data)
        {
            myUsers = data.Users;
            password = data.adminPassword;
        }

        [Route("users/index/{id}")]
        public IActionResult Index(string id) 
        {
            if (id == password)
            {
                return View(myUsers);
            }
            
            return RedirectToAction("Unauthorized");
        }

        public IActionResult Unauthorized() => View();

        public IActionResult Error() => 
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
