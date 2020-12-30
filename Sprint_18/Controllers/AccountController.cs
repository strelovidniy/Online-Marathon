using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskAuthenticationAuthorization.Models;
using TaskAuthenticationAuthorization.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace TaskAuthenticationAuthorization.Controllers
{
    public class AccountController : Controller
    {
        private ShoppingContext db;

        public AccountController(ShoppingContext context) => db = context;

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = await db.Customers.FirstOrDefaultAsync(u => u.Email == model.Email);

                if (customer == null)
                {
                    customer = new Customer { Email = model.Email, Password = model.Password };

                    var userRole = await db.Roles.FirstOrDefaultAsync(r => r.Name == "buyer");

                    if (userRole != null)
                    {
                        customer.Role = userRole;
                    }

                    db.Customers.Add(customer);
                    
                    await db.SaveChangesAsync();

                    await Authenticate(customer);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = await db.Customers
                    .Include(u => u.Role)
                    .Include(u => u.BuyerType)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                if (customer != null)
                {
                    await Authenticate(customer);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Incorrect login or password");
            }

            return View(model);
        }

        private async Task Authenticate(Customer customer)
        {
            var claims = new List<Claim>
            {
                new Claim("BuyerType", customer.BuyerType.Name ?? "none"),
                new Claim(ClaimTypes.Email, customer.Email),
                new Claim("Id", customer.ID.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, customer.Role?.Name ?? "buyer")
            };
            
            var id = new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimTypes.Email, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}