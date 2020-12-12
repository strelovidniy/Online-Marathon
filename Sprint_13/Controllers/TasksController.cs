using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Sprint_13.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Greetings() => View();

        public IActionResult ProductInfo() => View();

        public IActionResult SuperMarkets()
        {
            ViewBag.Supermarkets = new List<string>
            {
                "WellMart",
                "Silpo",
                "ATB",
                "Furshet",
                "Metro"
            };

            return View();
        }

        public IActionResult ShoppingList() =>
            View(new Dictionary<string, int>
            {
                {"Milk", 2},
                {"Bread", 2},
                {"Cake", 1},
                {"Ice Cream", 5},
                {"Cola", 10}
            });

        [HttpGet]
        public IActionResult ShoppingCart()
        {
            ViewBag.Supermarkets = new List<string>
            {
                "WellMart", 
                "Silpo",
                "ATB", 
                "Furshet", 
                "Metro"
            };
            
            ViewBag.Days = new List<DateTime>
            {
                DateTime.Today,
                DateTime.Today.AddDays(1),
                DateTime.Today.AddDays(2)
            };

            ViewBag.ShoppingList = new Dictionary<string, int>
            {
                { "Milk", 2 },
                { "Bread", 2 },
                { "Cake", 1 },
                { "Ice Cream", 5 },
                { "Cola", 10 },
            };

            return View();
        }

        [HttpPost]
        public IActionResult ShoppingCart(string fullname, string address) => 
            Content($"Your products will be shipped at: {address}. Bon appetite, {fullname}!");

        public IActionResult SprintTasks() => View();

        public IActionResult TimeToBuy() => View();
    }
}
