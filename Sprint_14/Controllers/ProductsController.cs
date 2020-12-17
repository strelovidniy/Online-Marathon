using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsWithRouting.Models;
using ProductsWithRouting.Services;
using System.Linq;

namespace ProductsWithRouting.Controllers
{
    public class ProductsController : Controller
    {
        private List<Product> myProducts;

        public ProductsController(Data data) => myProducts = data.Products;

        [Route("~/Products/Index/{filterId:int?}")]
        [Route("~/Items/Index/{filterId:int?}")]
        [Route("~/Products/Index/{filterName?}")]
        [Route("~/Items/Index/{filterName?}")]
        [Route("~/Products")]
        [Route("~/Items")]
        public IActionResult Index(int filterId, string filterName)
        {
            if (filterId == 0 && filterName == null)
            {
                return View(myProducts);
            }

            if (filterId == 0)
            {
                return View(myProducts.Where(x => x.Name == filterName));
            }
            
            var filteredProducts = myProducts.Where(x => x.Id == filterId).ToList();
                
            if (filteredProducts.Any())
            {
                return View(filteredProducts);
            }

            return RedirectToAction("Error404");
        }

        [Route("~/Products/{id}")]
        public IActionResult View(int id) => View(myProducts.Find(product => product.Id == id));

        [HttpGet]
        public IActionResult Edit(int id) => View(myProducts.Find(product => product.Id == id));

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            myProducts[myProducts.FindIndex(x => x.Id == product.Id)] = product;
            return RedirectToAction("Index");
        }

        [Route("products/new")]
        [Route("products/create")]
        [HttpPost]
        public IActionResult Create(Product product)
        {
            myProducts.Add(product);
            return RedirectToAction("Index");
        }

        [Route("products/new")]
        [Route("products/create")]
        public IActionResult Create() => View(new Product {Id = myProducts.Count + 1});

        public IActionResult Delete(int id)
        {
            myProducts.Remove(myProducts.Find(product => product.Id == id));
            return RedirectToAction("Index");
        }

        public IActionResult Error() => 
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        public IActionResult Error404() => View();
    }
}
