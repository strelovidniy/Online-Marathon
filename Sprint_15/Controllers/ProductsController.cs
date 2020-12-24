using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sprint_15.Models;
using Sprint_15.Services;

namespace Sprint_15.Controllers
{
    
    public class ProductsController : Controller
    {
        public static List<Product> MyProducts { get; private set; }

        public ProductsController(Data data) => MyProducts = data.Products;

        public IActionResult Index(int filterId, string filterName) => View(MyProducts);

        public IActionResult View(int id)
        {
            var product = MyProducts.Find(p => p.Id == id);

            if (product != null)
            {
                return View(product);
            }

            return View("NotExists");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = MyProducts.Find(p => p.Id == id);

            if (product != null)
            {
                return View(product);
            }

            return View("NotExists");
        } 

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                MyProducts[MyProducts.FindIndex(p => p.Id == product.Id)] = product;
            }

            return View("View", product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                MyProducts.Add(product);
            }

            return View("View", product);
        }

        public IActionResult Create() => View(new Product(){Id = MyProducts.Last().Id + 1});

        public IActionResult Delete(int id)
        {
            MyProducts.Remove( MyProducts.Find(product => product.Id == id));
            return RedirectToAction("Index");
        }

        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
