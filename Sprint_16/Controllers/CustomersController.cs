using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sprint_16.Models;

namespace Sprint_16.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ShoppingContext _context;

        private static int _addressSortingCounter = 0;
        private static int _lastNameSortingCounter = 0;

        public CustomersController(ShoppingContext context) => _context = context;

        public async Task<IActionResult> Index() => View(await _context.Customers.ToListAsync());

        public IActionResult Find(string substring) =>
            View("Index", _context.Customers
                .Where(customer => customer.LastName.Contains(substring))
                .ToList());

        public async Task<IActionResult> SortByAddress()
        {
            if (_addressSortingCounter % 2 == 0)
            {
                _addressSortingCounter++;
                return View("Index", await _context.Customers
                    .OrderBy(customer => customer.Address)
                    .ToListAsync());
            }
            else
            {
                _addressSortingCounter++;
                return View("Index", await _context.Customers
                    .OrderByDescending(customer => customer.Address)
                    .ToListAsync());
            }
        }

        public async Task<IActionResult> SortByLastName()
        {
            if (_lastNameSortingCounter % 2 == 0)
            {
                _lastNameSortingCounter++;
                return View("Index", await _context.Customers
                    .OrderBy(customer => customer.LastName)
                    .ToListAsync());
            }
            else
            {
                _lastNameSortingCounter++;
                return View("Index", await _context.Customers
                    .OrderByDescending(customer => customer.LastName)
                    .ToListAsync());
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,Discount")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

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

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,Discount")] Customer customer)
        {
            if (id != customer.Id)
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
                    if (!CustomerExists(customer.Id))
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

            return View(customer);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);

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

        private bool CustomerExists(int id) => _context.Customers.Any(e => e.Id == id);
    }
}
