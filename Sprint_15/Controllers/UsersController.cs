using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Sprint_15.Models;
using Sprint_15.Services;

namespace Sprint_15.Controllers
{
    public class UsersController : Controller
    {
        private List<User> users;

        public UsersController(Data data) => users = data.Users;

        public IActionResult Index(string id) => View("Index", users);
    }
}
