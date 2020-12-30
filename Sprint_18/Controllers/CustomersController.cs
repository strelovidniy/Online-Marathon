using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskAuthenticationAuthorization.Models;

namespace TaskAuthenticationAuthorization.Controllers
{
    [Authorize(Roles = "admin")]
    public class CustomersController : Controller
    {
        private readonly ShoppingContext _context;

        public CustomersController(ShoppingContext context) => _context = context;

        public async Task<IActionResult> Index() => 
            View(await _context.Customers.Include(c => c.BuyerType).Include(c => c.Role).ToListAsync());

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.BuyerType)
                .Include(c => c.Role)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        public IActionResult Create()
        {
            ViewData["BuyerTypeId"] = new SelectList(_context.BuyerTypes, "Id", "Id");
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstName,Email,Password,Address,Discount,RoleId,BuyerTypeId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["BuyerTypeId"] = new SelectList(_context.BuyerTypes, "Id", "Id", customer.BuyerTypeId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", customer.RoleId);

            return View(customer);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            ViewData["BuyerTypeId"] = new SelectList(_context.BuyerTypes, "Id", "Id", customer.BuyerTypeId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", customer.RoleId);

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstName,Email,Password,Address,Discount,RoleId,BuyerTypeId")] Customer customer)
        {
            if (id != customer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["BuyerTypeId"] = new SelectList(_context.BuyerTypes, "Id", "Id", customer.BuyerTypeId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", customer.RoleId);

            return View(customer);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.BuyerType)
                .Include(c => c.Role)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id) => _context.Customers.Any(e => e.ID == id);
    }
}
