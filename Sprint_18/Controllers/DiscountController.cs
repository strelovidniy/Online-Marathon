using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskAuthenticationAuthorization.Models;

namespace TaskAuthenticationAuthorization.Controllers
{
    [Authorize(Policy = "Buyer", Roles = "buyer")]
    public class DiscountController : Controller
    {
        private readonly ShoppingContext _context;

        public DiscountController(ShoppingContext context) => _context = context;
        public IActionResult Index(Customer customer)
        {
            return View();
        }
    }
}