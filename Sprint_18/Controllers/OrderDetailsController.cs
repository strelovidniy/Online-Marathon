using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskAuthenticationAuthorization.Models;

namespace TaskAuthenticationAuthorization.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly ShoppingContext _context;

        public OrderDetailsController(ShoppingContext context) => _context = context;

        public async Task<IActionResult> Index() => 
            View(await _context.OrderDetails.Include(o => o.Order).Include(o => o.Product).ToListAsync());

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "ID", "ID");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,ProductId,Quantity")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDetail);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ID", "ID", orderDetail.ProductId);

            return View(orderDetail);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails.FindAsync(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ID", "ID", orderDetail.ProductId);

            return View(orderDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,ProductId,Quantity")] OrderDetail orderDetail)
        {
            if (id != orderDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailExists(orderDetail.Id))
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

            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ID", "ID", orderDetail.ProductId);

            return View(orderDetail);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);

            _context.OrderDetails.Remove(orderDetail);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailExists(int id) => _context.OrderDetails.Any(e => e.Id == id);
    }
}
