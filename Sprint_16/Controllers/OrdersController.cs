using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sprint_16.Models;

namespace Sprint_16.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ShoppingContext _context;

        public OrdersController(ShoppingContext context) => _context = context;

        public async Task<IActionResult> Index() =>
            View(await _context.Orders.Include(o => o.Customer).Include(o => o.SuperMarket).ToListAsync());

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.SuperMarket)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View("Index");
        }

        public IActionResult Create()
        {
            ViewData["SuperMarketId"] = new SelectList(_context.SuperMarkets, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderDate,CostumerId,SuperMarketId")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["SuperMarketId"] = new SelectList(_context.SuperMarkets, "Id", "Id", order.SuperMarketId);

            return View(order);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            ViewData["SuperMarketId"] = new SelectList(_context.SuperMarkets, "Id", "Id", order.SuperMarketId);

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderDate,CostumerId,SuperMarketId")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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

            ViewData["SuperMarketId"] = new SelectList(_context.SuperMarkets, "Id", "Id", order.SuperMarketId);

            return View(order);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.SuperMarket)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
